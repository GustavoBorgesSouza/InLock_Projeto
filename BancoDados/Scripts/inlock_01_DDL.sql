CREATE DATABASE inlock_games_manha;
GO

USE inlock_games_manha;
GO

CREATE TABLE Estudio(
	idEstudio INT PRIMARY KEY IDENTITY(1,1),
	nomeEstudio VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Jogo(
	idJogo INT PRIMARY KEY IDENTITY(1,1),
	idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio),
	nomeJogo VARCHAR(40) NOT NULL UNIQUE,
	descricao VARCHAR(260) NOT NULL,
	dataLancamento DATE NOT NULL,
	valor SMALLINT NOT NULL
);
GO

CREATE TABLE TipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	titulo VARCHAR(25) NOT NULL
);
GO

CREATE TABLE Usuario(
	idUsuario INT PRIMARY KEY IDENTITY(1,1),
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
	email VARCHAR(256) NOT NULL UNIQUE,
	senha VARCHAR(20) NOT NULL,
);
GO
