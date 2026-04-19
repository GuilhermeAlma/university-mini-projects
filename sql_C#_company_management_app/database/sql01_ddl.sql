-- Criar tabela Cliente
CREATE TABLE Cliente (
    nif CHAR(9) UNIQUE NOT NULL,
    no_cliente INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    telemovel VARCHAR(15),
    CHECK (LEN(nif) = 9)
);

-- Criar tabela Funcionario
CREATE TABLE Funcionario (
    no_funcionario INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    telemovel VARCHAR(15),
    salario DECIMAL(10, 2)
);

-- Criar tabela Viatura
CREATE TABLE Viatura (
    matricula VARCHAR(255) PRIMARY KEY,
    marca VARCHAR(255),
    categoria VARCHAR(255),
    capacidade_carga DECIMAL(10, 2)
);

-- Criar tabela Material
CREATE TABLE Material (
    codigo INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    tipo_material VARCHAR(255),
    preco DECIMAL(10, 2),
    qnt_armazem INT DEFAULT 0,
    local_armazem VARCHAR(255),
    CHECK (tipo_material IN ('Eletricidade', 'Canalização')),
    CHECK (qnt_armazem >= 0)
);

-- Criar tabela Fatura_servico
CREATE TABLE Fatura_servico (
    no_fatura_servico INT PRIMARY KEY IDENTITY(1,1),
    nif_cliente CHAR(9),
    valor DECIMAL(10, 2) NOT NULL,
    iva DECIMAL(10, 2) NOT NULL,
    data_servico DATE NOT NULL,
    FOREIGN KEY (nif_cliente) REFERENCES Cliente(nif)
);

-- Criar tabela Servico
CREATE TABLE Servico (
    no_interno INT PRIMARY KEY IDENTITY(1,1),
	no_cliente INT,
    no_fatura_servico INT,
    local_servico VARCHAR(255) NOT NULL,
    estado_atual VARCHAR(255) NOT NULL,
    data_hora_i DATE NOT NULL,
    data_hora_f DATE,
    FOREIGN KEY (no_cliente) REFERENCES Cliente(no_cliente),
    FOREIGN KEY (no_fatura_servico) REFERENCES Fatura_servico(no_fatura_servico),
    CHECK (estado_atual IN ('Em Andamento', 'Concluído', 'Cancelado')),
    CHECK (
        (estado_atual != 'Concluído' AND estado_atual != 'Cancelado' AND data_hora_f IS NULL) OR
        (estado_atual IN ('Concluído', 'Cancelado') AND data_hora_f IS NOT NULL AND data_hora_f >= data_hora_i)
    )
);

-- Criar tabela Encomenda
CREATE TABLE Encomenda (
    no_encomenda INT PRIMARY KEY IDENTITY(1,1),
    estado VARCHAR(255) NOT NULL,
    data_encomenda DATE NOT NULL,
    CHECK (estado IN ('Pendente', 'Em Trânsito', 'Entregue'))
);

-- Criar tabela Fornecedor
CREATE TABLE Fornecedor (
    nif CHAR(9) PRIMARY KEY,
    no_fornecedor INT NOT NULL UNIQUE,
    nome VARCHAR(255) NOT NULL,
    morada VARCHAR(255),
    email VARCHAR(255),
    CHECK (LEN(nif) = 9)
);

-- Criar tabela Fatura_encomenda
CREATE TABLE Fatura_encomenda (
    no_fatura_enc INT PRIMARY KEY IDENTITY(1,1),
    nif_fornecedor CHAR(9),
    no_encomenda INT,
    valor DECIMAL(10, 2) NOT NULL,
    iva DECIMAL(10, 2),
    data_fatura_enc DATE NOT NULL,
    FOREIGN KEY (no_encomenda) REFERENCES Encomenda(no_encomenda),
    FOREIGN KEY (nif_fornecedor) REFERENCES Fornecedor(nif)
);

-- Criar tabela Fornece (entidade associativa entre Fornecedor e Encomenda)
CREATE TABLE Fornece (
    no_fornecedor INT,
    no_encomenda INT,
    PRIMARY KEY (no_fornecedor, no_encomenda),
    FOREIGN KEY (no_fornecedor) REFERENCES Fornecedor(no_fornecedor),
    FOREIGN KEY (no_encomenda) REFERENCES Encomenda(no_encomenda)
);

-- Criar tabela Presta (entidade associativa entre Funcionario e Servico)
CREATE TABLE Presta (
    no_funcionario INT,
    no_servico INT,
    PRIMARY KEY (no_funcionario, no_servico),
    FOREIGN KEY (no_funcionario) REFERENCES Funcionario(no_funcionario),
    FOREIGN KEY (no_servico) REFERENCES Servico(no_interno)
);

-- Criar tabela Contem (entidade associativa entre Encomenda e Material)
CREATE TABLE Contem (
    no_encomenda INT,
    codigo_material INT,
    quantidade INT,
    PRIMARY KEY (no_encomenda, codigo_material),
    FOREIGN KEY (no_encomenda) REFERENCES Encomenda(no_encomenda),
    FOREIGN KEY (codigo_material) REFERENCES Material(codigo)
);

-- Criar tabela Utiliza (entidade associativa entre Servico e Viatura)
CREATE TABLE Utiliza (
    no_servico INT,
    matricula VARCHAR(255),
    PRIMARY KEY (no_servico, matricula),
    FOREIGN KEY (no_servico) REFERENCES Servico(no_interno),
    FOREIGN KEY (matricula) REFERENCES Viatura(matricula)
);

-- Criar tabela MaterialServico (entidade associativa entre Material e Servico)
CREATE TABLE MaterialServico (
    no_servico INT,
    codigo_material INT,
    quantidade INT,
    PRIMARY KEY (no_servico, codigo_material),
    FOREIGN KEY (no_servico) REFERENCES Servico(no_interno),
    FOREIGN KEY (codigo_material) REFERENCES Material(codigo)
);



