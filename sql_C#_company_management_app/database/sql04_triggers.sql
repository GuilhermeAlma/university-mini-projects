
----------------------------------------------------------------------------
-- Triggers
----------------------------------------------------------------------------
-- Trigger para criar fatura automaticamente ao marcar o serviço como concluído
drop TRIGGER trg_criar_fatura
CREATE TRIGGER trg_criar_fatura
ON Servico
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE estado_atual = 'Concluído')
    BEGIN
        -- Variables for storing data
        DECLARE @no_servico INT;
        DECLARE @data_hora_i DATE;
        DECLARE @data_hora_f DATE;
        DECLARE @no_cliente INT;
        DECLARE @nif_cliente CHAR(9);
        DECLARE @valor DECIMAL(10, 2);
        DECLARE @iva DECIMAL(10, 2) = 23; -- Example IVA of 23%
        DECLARE @dias INT;
        DECLARE @preco_por_dia DECIMAL(10, 2) = 100.00; -- Example price per day
        DECLARE @custo_material DECIMAL(10, 2);
        DECLARE @no_fatura_servico INT;

        -- Cursor to iterate over inserted rows
        DECLARE inserted_cursor CURSOR FOR
        SELECT no_interno, data_hora_i, data_hora_f, no_cliente
        FROM inserted
        WHERE estado_atual = 'Concluído';

        OPEN inserted_cursor;
        FETCH NEXT FROM inserted_cursor INTO @no_servico, @data_hora_i, @data_hora_f, @no_cliente;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Fetch nif_cliente based on no_cliente
            SELECT @nif_cliente = nif FROM Cliente WHERE no_cliente = @no_cliente;

            SET @dias = DATEDIFF(DAY, @data_hora_i, @data_hora_f);
            SET @valor = @dias * @preco_por_dia;

            -- Calculate material costs
            SELECT @custo_material = ISNULL(SUM(m.preco * ms.quantidade), 0)
            FROM Material m
            JOIN MaterialServico ms ON m.codigo = ms.codigo_material
            WHERE ms.no_servico = @no_servico;

            -- Calculate total value with IVA
            SET @valor = @valor + (@custo_material * @iva / 100);

            -- Insert into Fatura_servico and get the generated no_fatura_servico
            INSERT INTO Fatura_servico (nif_cliente, valor, iva, data_servico)
            VALUES (@nif_cliente, @valor, @iva, @data_hora_f);

            SET @no_fatura_servico = SCOPE_IDENTITY();

            -- Update the Servico table to associate the fatura with the service
            UPDATE Servico
            SET no_fatura_servico = @no_fatura_servico
            WHERE no_interno = @no_servico;

            FETCH NEXT FROM inserted_cursor INTO @no_servico, @data_hora_i, @data_hora_f, @no_cliente;
        END;

        CLOSE inserted_cursor;
        DEALLOCATE inserted_cursor;
    END
END; -- working


-- Trigger para evitar alterações em serviços concluídos ou cancelados
CREATE TRIGGER trg_check_servico
ON Servico
INSTEAD OF UPDATE
AS
BEGIN
    DECLARE @no_interno INT;
    DECLARE @estado_atual VARCHAR(255);

    -- Check for each row in the inserted table
    DECLARE inserted_cursor CURSOR FOR
    SELECT no_interno, estado_atual
    FROM inserted;

    OPEN inserted_cursor;
    FETCH NEXT FROM inserted_cursor INTO @no_interno, @estado_atual;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Check the current state of the service
        IF EXISTS (SELECT 1 FROM Servico WHERE no_interno = @no_interno AND estado_atual IN ('Concluído', 'Cancelado'))
        BEGIN
            RAISERROR('Não se pode fazer alterações a serviços concluídos ou cancelados.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        FETCH NEXT FROM inserted_cursor INTO @no_interno, @estado_atual;
    END;

    CLOSE inserted_cursor;
    DEALLOCATE inserted_cursor;

    -- Perform the update
    UPDATE Servico
    SET estado_atual = inserted.estado_atual,
        no_cliente = inserted.no_cliente,
        data_hora_i = inserted.data_hora_i,
        data_hora_f = inserted.data_hora_f,
        local_servico = inserted.local_servico
    FROM inserted
    WHERE Servico.no_interno = inserted.no_interno;
END; -- working

-- Trigger para evitar alterações indevidas no estado de uma encomenda
CREATE TRIGGER trg_check_encomenda
ON Encomenda
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica transições válidas
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.no_encomenda = d.no_encomenda
        WHERE (d.estado = 'Pendente' AND i.estado NOT IN ('Pendente', 'Em Trânsito'))
           OR (d.estado = 'Em Trânsito' AND i.estado NOT IN ('Em Trânsito', 'Entregue'))
           OR (d.estado = 'Entregue' AND i.estado <> 'Entregue')
    )
    BEGIN
        -- Se uma transição inválida é detectada, lança um erro e desfaz a transação
        RAISERROR ('Transição de estado inválida.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END; -- working



-- Trigger para adicionar materiais ao armazém quando uma encomenda for entregue
CREATE TRIGGER trg_add_material_to_warehouse
ON Encomenda
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE estado = 'Entregue' AND (SELECT estado FROM deleted) != 'Entregue')
    BEGIN
        UPDATE Material
        SET qnt_armazem = qnt_armazem + c.quantidade
        FROM Material m
        JOIN Contem c ON m.codigo = c.codigo_material
        JOIN inserted i ON c.no_encomenda = i.no_encomenda
        WHERE i.estado = 'Entregue';
    END
END; -- working


-- trg_move_material refeito, porém acaba por não ser necessário sendo que a funcionalidade
-- foi implementada em stored procedures
DROP TRIGGER IF EXISTS trg_move_material;
CREATE TRIGGER trg_move_material
ON MaterialServico
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Verifica inserções
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        -- Verifica se a quantidade no armazém é suficiente
        IF EXISTS (SELECT 1
                   FROM inserted i
                            JOIN Material m ON i.codigo_material = m.codigo
                   WHERE m.qnt_armazem < i.quantidade)
        BEGIN
            RAISERROR('Material insuficiente no armazém para o material %d. Favor criar uma nova encomenda.', 16, 1, @codigo_material);
            ROLLBACK TRANSACTION;
            RETURN;
        END;
    END

    -- Verifica exclusões e atualizações
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Atualiza a quantidade no armazém
        UPDATE m
        SET qnt_armazem = qnt_armazem + d.quantidade
        FROM Material m
                 JOIN deleted d ON m.codigo = d.codigo_material;
    END
END;
