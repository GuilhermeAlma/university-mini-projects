-- Inserir dados de trabalho na tabela Cliente
INSERT INTO Cliente (nif, nome, telemovel)
VALUES ('268435794', 'Noe', '912345678'),
        ('268435795', 'Miguel', '912345679'),
        ('268435796', 'Ricardo', '912345680'),
        ('268435797', 'João', '912345681'),
        ('268435798', 'Pedro', '912345682'),
        ('268435799', 'Rui', '912345683'),
        ('268435800', 'Tiago', '912345684'),
        ('268435801', 'Carlos', '912345685'),
        ('268435802', 'Manuel', '912345686'),
        ('268435803', 'António', '912345687');

-- Inserir dados de trabalho na tabela Material (só há eletricidade, canalização)
INSERT INTO Material (codigo, nome, tipo_material, preco, qnt_armazem, local_armazem)
VALUES (1, 'Cabo Elétrico', 'Eletricidade', 10.00, 100, 'Armazém A'),
        (2, 'Tubo PVC', 'Canalização', 5.00, 200, 'Armazém B'),
        (3, 'Fio Elétrico', 'Eletricidade', 15.00, 150, 'Armazém A'),
        (4, 'Tubo Cobre', 'Canalização', 7.00, 250, 'Armazém B'),
        (5, 'Tomada', 'Eletricidade', 20.00, 50, 'Armazém A'),
        (6, 'Sifão', 'Canalização', 10.00, 100, 'Armazém B'),
        (7, 'Interruptor', 'Eletricidade', 25.00, 75, 'Armazém A'),
        (8, 'Torneira', 'Canalização', 15.00, 125, 'Armazém B'),
        (9, 'Lâmpada', 'Eletricidade', 30.00, 25, 'Armazém A'),
        (10, 'Tubo PPR', 'Canalização', 20.00, 150, 'Armazém B');


-- Inserir dados de trabalho na tabela Fornecedor
INSERT INTO Fornecedor (nif, no_fornecedor, nome, morada, email)
VALUES ('123456789', 1, 'Só Cabos', 'Rua dos Cabos, 123', 'cabeleio@eletric.com'),
        ('123456790', 2, 'Tubos e Canos', 'Rua dos Tubos, 456', 'mete@agua.pt');

-- Inserir dados de trabalho na tabela Funcionario
INSERT INTO Funcionario Values ('Manel', '912372659', '1301'),
                                ('Ricardo', '912372660', '1302'),
                                ('João', '912372661', '1303'),
                                ('Pedro', '912372662', '1304'),
                                ('Rui', '912372663', '1305');

-- Inserir dados de trabalho na tabela Viatura
INSERT INTO Viatura Values ('SA-23-DA', 'Toyota', 'Carrinha', '3.2'),
                            ('SA-24-DA', 'Ford', 'Carro', '0.2'),
                            ('SA-25-DA', 'Mercedes', 'Carrinha', '3.5'),
                            ('SA-26-DA', 'Opel', 'Carro', '0.3');