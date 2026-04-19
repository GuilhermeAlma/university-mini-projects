----------------------------------------------------------------------------
-- Procedures
----------------------------------------------------------------------------


-- AllocationForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_servicos_andamento
AS
BEGIN
    SELECT no_interno, CONCAT(no_interno, ' - ', local_servico) AS display
    FROM Servico
    WHERE estado_atual = 'Em Andamento';
END;


CREATE PROCEDURE carregar_funcionarios
AS
BEGIN
    SELECT no_funcionario, CONCAT(no_funcionario, ' - ', nome) AS display
    FROM Funcionario;
END;

CREATE PROCEDURE carregar_veiculos
AS
BEGIN
    SELECT matricula, CONCAT(matricula, ' - ', marca) AS display
    FROM Viatura;
END;

CREATE PROCEDURE alocar_funcionario
    @no_funcionario INT,
    @no_servico INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Presta WHERE no_funcionario = @no_funcionario AND no_servico = @no_servico)
    BEGIN
        INSERT INTO Presta (no_funcionario, no_servico)
        VALUES (@no_funcionario, @no_servico);
    END
    ELSE
    BEGIN
        RAISERROR('Funcionário já alocado ao serviço', 16, 1);
    END
END;

CREATE PROCEDURE alocar_veiculo
    @no_servico INT,
    @matricula VARCHAR(255)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Utiliza WHERE no_servico = @no_servico AND matricula = @matricula)
    BEGIN
        INSERT INTO Utiliza (no_servico, matricula)
        VALUES (@no_servico, @matricula);
    END
    ELSE
    BEGIN
        RAISERROR('Viatura já alocada ao serviço', 16, 1);
    END
END;

CREATE PROCEDURE carregar_materiais_servico
    @no_servico INT
AS
BEGIN
    SELECT 
        m.codigo AS 'Código de Material', 
        m.nome AS 'Nome', 
        ms.quantidade AS 'Quantidade Alocada', 
        m.preco AS 'Preço Unitário', 
        (m.preco * ms.quantidade) AS 'Preço Total', 
        m.qnt_armazem AS 'Quantidade em Armazém', 
        m.local_armazem AS 'Local do Armazém'
    FROM 
        Material m
    JOIN 
        MaterialServico ms ON m.codigo = ms.codigo_material
    WHERE 
        ms.no_servico = @no_servico;
END;

CREATE PROCEDURE carregar_funcionarios_servico
    @no_servico INT
AS
BEGIN
    SELECT f.no_funcionario, CONCAT(f.no_funcionario, ' - ', f.nome) AS display
    FROM Presta p
    JOIN Funcionario f ON p.no_funcionario = f.no_funcionario
    WHERE p.no_servico = @no_servico;
END;

CREATE PROCEDURE carregar_veiculos_servico
    @no_servico INT
AS
BEGIN
    SELECT v.matricula, CONCAT(v.matricula, ' - ', v.marca) AS display
    FROM Utiliza u
    JOIN Viatura v ON u.matricula = v.matricula
    WHERE u.no_servico = @no_servico;
END;

CREATE PROCEDURE listar_materiais
AS
BEGIN
    SELECT codigo, nome
    FROM Material;
END;

-- Remove material de um serviço e devolve ao armazém
CREATE PROCEDURE mover_material_servico_armazem
    @no_servico INT,
    @codigo_material INT,
    @quantidade INT
AS
BEGIN
    DECLARE @quantidadeAtual INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verifica a quantidade atual do material no serviço
        SELECT @quantidadeAtual = quantidade
        FROM MaterialServico
        WHERE no_servico = @no_servico AND codigo_material = @codigo_material;

        IF @quantidadeAtual >= @quantidade
        BEGIN
            -- Atualiza ou remove a quantidade de material no serviço
            IF @quantidadeAtual = @quantidade
            BEGIN
                DELETE FROM MaterialServico
                WHERE no_servico = @no_servico AND codigo_material = @codigo_material;
            END
            ELSE
            BEGIN
                UPDATE MaterialServico
                SET quantidade = quantidade - @quantidade
                WHERE no_servico = @no_servico AND codigo_material = @codigo_material;
            END

            -- Atualiza a quantidade de material no armazém
            UPDATE Material
            SET qnt_armazem = qnt_armazem + @quantidade
            WHERE codigo = @codigo_material;
        END
        ELSE
        BEGIN
            RAISERROR('Quantidade insuficiente no serviço.', 16, 1);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

-- Remove material do armazém e aloca a um serviço
CREATE PROCEDURE mover_material_armazem_servico
    @no_servico INT,
    @codigo_material INT,
    @quantidade INT
AS
BEGIN
    DECLARE @quantidadeAtual INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verifica a quantidade atual do material no armazém
        SELECT @quantidadeAtual = qnt_armazem
        FROM Material
        WHERE codigo = @codigo_material;

        IF @quantidadeAtual >= @quantidade
        BEGIN
            -- Atualiza a quantidade de material no armazém
            UPDATE Material
            SET qnt_armazem = qnt_armazem - @quantidade
            WHERE codigo = @codigo_material;

            -- Atualiza ou remove a quantidade de material no serviço
            IF EXISTS (SELECT 1 FROM MaterialServico WHERE no_servico = @no_servico AND codigo_material = @codigo_material)
            BEGIN
                UPDATE MaterialServico
                SET quantidade = quantidade + @quantidade
                WHERE no_servico = @no_servico AND codigo_material = @codigo_material;
            END
            ELSE
            BEGIN
                INSERT INTO MaterialServico (no_servico, codigo_material, quantidade)
                VALUES (@no_servico, @codigo_material, @quantidade);
            END
        END
        ELSE
        BEGIN
            RAISERROR('Quantidade insuficiente no armazém.', 16, 1);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
----------------------------------------------------------------------------

-- CreateOrderForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_fornecedores
AS
BEGIN
    SELECT nif, nome
    FROM Fornecedor;
END;

-- Criação da encomenda e da fatura associada
CREATE PROCEDURE criar_encomenda_com_fatura
    @nif_fornecedor CHAR(9),
    @data_encomenda DATE,
    @materiais NVARCHAR(MAX) -- Lista de materiais no formato 'codigo_material:quantidade,codigo_material:quantidade,...'
AS
BEGIN
    DECLARE @no_encomenda INT;
    DECLARE @no_fornecedor INT;
    DECLARE @valor_total DECIMAL(10, 2) = 0;
    DECLARE @iva DECIMAL(10, 2) = 0;
    DECLARE @codigo_material INT;
    DECLARE @quantidade INT;
    DECLARE @preco DECIMAL(10, 2);
    DECLARE @pos INT;
    DECLARE @str NVARCHAR(100);
    
    -- Iniciar uma transação
    BEGIN TRANSACTION;

    -- Inserir a nova encomenda
    INSERT INTO Encomenda (estado, data_encomenda)
    VALUES ('Pendente', @data_encomenda);
    
    -- Obter o ID da nova encomenda
    SET @no_encomenda = SCOPE_IDENTITY();
    
    -- Obter o número do fornecedor
    SELECT @no_fornecedor = no_fornecedor
    FROM Fornecedor
    WHERE nif = @nif_fornecedor;
    
    -- Verificar se o fornecedor existe
    IF @no_fornecedor IS NULL
    BEGIN
        RAISERROR('Fornecedor não encontrado.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Inserir a relação entre fornecedor e encomenda
    INSERT INTO Fornece (no_fornecedor, no_encomenda)
    VALUES (@no_fornecedor, @no_encomenda);
    
    -- Inserir materiais na encomenda
    SET @pos = CHARINDEX(',', @materiais);
    
    WHILE @pos > 0
    BEGIN
        SET @str = SUBSTRING(@materiais, 1, @pos - 1);
        SET @materiais = SUBSTRING(@materiais, @pos + 1, LEN(@materiais) - @pos);
        SET @pos = CHARINDEX(':', @str);
        SET @codigo_material = CONVERT(INT, SUBSTRING(@str, 1, @pos - 1));
        SET @quantidade = CONVERT(INT, SUBSTRING(@str, @pos + 1, LEN(@str) - @pos));
        
        -- Obter o preço do material
        SELECT @preco = preco
        FROM Material
        WHERE codigo = @codigo_material;
        
        IF @preco IS NULL
        BEGIN
            RAISERROR('Material com código %d não encontrado.', 16, 1, @codigo_material);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Inserir na tabela Contem com a quantidade
        INSERT INTO Contem (no_encomenda, codigo_material, quantidade)
        VALUES (@no_encomenda, @codigo_material, @quantidade);
        
        -- Calcular o valor total da encomenda
        SET @valor_total = @valor_total + (@preco * @quantidade);
        
        SET @pos = CHARINDEX(',', @materiais);
    END;
    
    -- Processar o último item
    IF LEN(@materiais) > 0
    BEGIN
        SET @pos = CHARINDEX(':', @materiais);
        SET @codigo_material = CONVERT(INT, SUBSTRING(@materiais, 1, @pos - 1));
        SET @quantidade = CONVERT(INT, SUBSTRING(@materiais, @pos + 1, LEN(@materiais) - @pos));
        
        -- Obter o preço do material
        SELECT @preco = preco
        FROM Material
        WHERE codigo = @codigo_material;
        
        IF @preco IS NULL
        BEGIN
            RAISERROR('Material com código %d não encontrado.', 16, 1, @codigo_material);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Inserir na tabela Contem com a quantidade
        INSERT INTO Contem (no_encomenda, codigo_material, quantidade)
        VALUES (@no_encomenda, @codigo_material, @quantidade);
        
        -- Calcular o valor total da encomenda
        SET @valor_total = @valor_total + (@preco * @quantidade);
    END;
    
    -- Calcular o IVA (supondo uma taxa de IVA de 23%)
    SET @iva = @valor_total * 0.23;
    
    -- Inserir a fatura da encomenda
    INSERT INTO Fatura_encomenda (nif_fornecedor, no_encomenda, valor, iva, data_fatura_enc)
    VALUES (@nif_fornecedor, @no_encomenda, @valor_total, @iva, GETDATE());
    
    -- Commit da transação
    COMMIT TRANSACTION;
END;
----------------------------------------------------------------------------

-- InvoiceForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_faturas_servico
AS
BEGIN
    SELECT 
        fs.no_fatura_servico AS 'No Fatura',
        c.nif AS 'NIF do Cliente',
        c.nome AS 'Nome do Cliente',
        s.local_servico AS 'Local do Serviço',
        s.data_hora_i AS 'Data Início do Serviço',
        s.data_hora_f AS 'Data Término do Serviço',
        fs.valor AS 'Valor Total',
        fs.iva AS 'Taxa de IVA'
    FROM 
        Fatura_servico fs
    JOIN 
        Servico s ON fs.no_fatura_servico = s.no_fatura_servico
    JOIN 
        Cliente c ON fs.nif_cliente = c.nif
    WHERE
        s.no_fatura_servico = fs.no_fatura_servico;
END;

CREATE PROCEDURE carregar_faturas_encomenda
AS
BEGIN
    SELECT 
        no_fatura_enc,
        nif_fornecedor,
        valor,
        iva,
        data_fatura_enc 
    FROM 
        Fatura_encomenda;
END;
----------------------------------------------------------------------------

-- OrderForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_encomendas
AS
BEGIN
    SELECT no_encomenda, estado, data_encomenda
    FROM Encomenda;
END;

CREATE PROCEDURE carregar_detalhes_encomenda
    @no_encomenda INT
AS
BEGIN
    SELECT c.codigo_material, m.nome, c.quantidade
    FROM Contem c
    JOIN Material m ON c.codigo_material = m.codigo
    WHERE c.no_encomenda = @no_encomenda;
END;

CREATE PROCEDURE atualizar_estado_encomenda
    @no_encomenda INT,
    @novo_estado VARCHAR(255)
AS
BEGIN
    UPDATE Encomenda
    SET estado = @novo_estado
    WHERE no_encomenda = @no_encomenda;
END;
----------------------------------------------------------------------------

-- ServiceForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_todos_servicos
AS
BEGIN
    SELECT * FROM Servico;
END;

CREATE PROCEDURE carregar_clientes
AS
BEGIN
    SELECT no_cliente, nome FROM Cliente;
END;

CREATE PROCEDURE listar_servicos_por_estado
    @estado VARCHAR(255)
AS
BEGIN
    SELECT *
    FROM Servico
    WHERE estado_atual = @estado;
END;

CREATE PROCEDURE listar_servicos_por_estado
    @estado VARCHAR(50)
AS
BEGIN
    SELECT * FROM Servico WHERE estado_atual = @estado;
END;

CREATE PROCEDURE criar_servico
    @no_cliente INT,
    @local_servico VARCHAR(255),
    @estado_atual VARCHAR(50),
    @data_hora_i DATETIME
AS
BEGIN
    INSERT INTO Servico (no_cliente, local_servico, estado_atual, data_hora_i)
    VALUES (@no_cliente, @local_servico, @estado_atual, @data_hora_i);
END;

CREATE PROCEDURE atualizar_estado_servico
    @no_interno INT,
    @estado_atual VARCHAR(50),
    @data_hora_f DATETIME
AS
BEGIN
    UPDATE Servico
    SET estado_atual = @estado_atual, data_hora_f = @data_hora_f
    WHERE no_interno = @no_interno;
END;
----------------------------------------------------------------------------

-- WarehouseForm
----------------------------------------------------------------------------
CREATE PROCEDURE carregar_materiais
AS
BEGIN
    SELECT codigo, nome, tipo_material, qnt_armazem, local_armazem
    FROM Material;
END;

CREATE PROCEDURE remover_material
    @codigo INT,
    @quantidade INT
AS
BEGIN
    UPDATE Material
    SET qnt_armazem = qnt_armazem - @quantidade
    WHERE codigo = @codigo AND qnt_armazem >= @quantidade;

    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Quantidade insuficiente no armazém.', 16, 1);
    END
END;




/* Não utilizado
CREATE PROCEDURE criar_encomenda
    @nif_fornecedor CHAR(9),
    @data_encomenda DATE,
    @materiais NVARCHAR(MAX) -- Lista de materiais no formato 'codigo_material:quantidade,codigo_material:quantidade,...'
AS
BEGIN
    DECLARE @no_encomenda INT;
    
    -- Inserir a nova encomenda
    INSERT INTO Encomenda (estado, data_encomenda)
    VALUES ('Pendente', @data_encomenda);
    
    -- Obter o ID da nova encomenda
    SET @no_encomenda = SCOPE_IDENTITY();
    
    -- Inserir a relação entre fornecedor e encomenda
    INSERT INTO Fornece (no_fornecedor, no_encomenda)
    SELECT no_fornecedor, @no_encomenda
    FROM Fornecedor
    WHERE nif = @nif_fornecedor;
    
    -- Inserir materiais na encomenda
    DECLARE @pos INT;
    DECLARE @str NVARCHAR(100);
    DECLARE @codigo_material INT;
    DECLARE @quantidade INT;
    
    SET @pos = CHARINDEX(',', @materiais);
    
    WHILE @pos > 0
    BEGIN
        SET @str = SUBSTRING(@materiais, 1, @pos - 1);
        SET @materiais = SUBSTRING(@materiais, @pos + 1, LEN(@materiais) - @pos);
        SET @pos = CHARINDEX(':', @str);
        SET @codigo_material = CONVERT(INT, SUBSTRING(@str, 1, @pos - 1));
        SET @quantidade = CONVERT(INT, SUBSTRING(@str, @pos + 1, LEN(@str) - @pos));
        
        -- Inserir na tabela Contem com a quantidade
        INSERT INTO Contem (no_encomenda, codigo_material, quantidade)
        VALUES (@no_encomenda, @codigo_material, @quantidade);
        
        SET @pos = CHARINDEX(',', @materiais);
    END;
    
    -- Processar o último item
    IF LEN(@materiais) > 0
    BEGIN
        SET @pos = CHARINDEX(':', @materiais);
        SET @codigo_material = CONVERT(INT, SUBSTRING(@materiais, 1, @pos - 1));
        SET @quantidade = CONVERT(INT, SUBSTRING(@materiais, @pos + 1, LEN(@materiais) - @pos));
        
        INSERT INTO Contem (no_encomenda, codigo_material, quantidade)
        VALUES (@no_encomenda, @codigo_material, @quantidade);
    END;
END;

*/



















