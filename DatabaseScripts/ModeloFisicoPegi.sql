-- CRIAÇÃO DAS TABELAS

CREATE TABLE Usuario (
    IdUsuario INTEGER PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(50),
    Sobrenome VARCHAR(150),
    Login VARCHAR(30),
    Senha VARCHAR(30),
    Email VARCHAR(50),
    Ativo BIT
);

CREATE TABLE Conta (
    IdConta INTEGER PRIMARY KEY IDENTITY(1,1),
    NomeConta VARCHAR(50),
    Saldo DECIMAL(12,2),
    fk_Usuario_IdUsuario INTEGER,
    fk_TipoConta_IdTipoConta INTEGER
);

CREATE TABLE TipoConta (
    IdTipoConta INTEGER PRIMARY KEY IDENTITY(1,1),
    TipoConta VARCHAR(20)
);

CREATE TABLE Lancamentos (
    IdLancamento INTEGER PRIMARY KEY IDENTITY(1,1),
    Descricao VARCHAR(150),
    Valor DECIMAL(12,2),
    DataLancamento DATETIME,
    fk_Conta_IdConta INTEGER,
    fk_TipoLancamento_IdTipoLancamento INTEGER
);

CREATE TABLE TipoLancamento (
    IdTipoLancamento INTEGER PRIMARY KEY IDENTITY(1,1),
    TipoLancamento VARCHAR(20)
);

-- ADICIONANDO REFERÊNCIA AS FOREIGN KEYS
 
ALTER TABLE Conta ADD CONSTRAINT FK_Conta_2
    FOREIGN KEY (fk_Usuario_IdUsuario)
    REFERENCES Usuario (IdUsuario);
 
ALTER TABLE Conta ADD CONSTRAINT FK_Conta_3
    FOREIGN KEY (fk_TipoConta_IdTipoConta)
    REFERENCES TipoConta (IdTipoConta);
 
ALTER TABLE Lancamentos ADD CONSTRAINT FK_Lancamentos_2
    FOREIGN KEY (fk_Conta_IdConta)
    REFERENCES Conta (IdConta);
 
ALTER TABLE Lancamentos ADD CONSTRAINT FK_Lancamentos_3
    FOREIGN KEY (fk_TipoLancamento_IdTipoLancamento)
    REFERENCES TipoLancamento (IdTipoLancamento);
GO

-- TRIGGERS AJUSTE SALDO DA CONTA

CREATE TRIGGER trg_AjustaSaldo
ON Lancamentos
FOR INSERT
AS
BEGIN
	DECLARE @IDCONTA INT,
			@VALOR DECIMAL(12,2),
			@TIPOLANCAMENTO INT

	SELECT @IDCONTA = fk_Conta_IdConta, @VALOR = Valor, @TIPOLANCAMENTO = fk_TipoLancamento_IdTipoLancamento FROM INSERTED

	IF @TIPOLANCAMENTO = 1 
		UPDATE Conta
		SET Saldo = Saldo + @VALOR
		WHERE IdConta = @IDCONTA;
	ELSE
		UPDATE Conta
		SET Saldo = Saldo - @VALOR
		WHERE IdConta = @IDCONTA;
END
GO

CREATE TRIGGER trg_AjustaSaldoDelete
ON Lancamentos
FOR DELETE
AS
BEGIN
	DECLARE @IDCONTA INT,
			@VALOR DECIMAL(12,2),
			@TIPOLANCAMENTO INT

	SELECT @IDCONTA = fk_Conta_IdConta, @VALOR = Valor, @TIPOLANCAMENTO = fk_TipoLancamento_IdTipoLancamento FROM DELETED

	IF @TIPOLANCAMENTO = 1 
		UPDATE Conta
		SET Saldo = Saldo - @VALOR
		WHERE IdConta = @IDCONTA;
	ELSE
		UPDATE Conta
		SET Saldo = Saldo + @VALOR
		WHERE IdConta = @IDCONTA;
END
GO