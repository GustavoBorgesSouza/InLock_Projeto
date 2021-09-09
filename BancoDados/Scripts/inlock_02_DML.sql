--DML

USE inlock_games_manha;
GO

-- Inserindo Estudios 
INSERT INTO Estudio(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

-- Inserindo Jogos e seus respectivos dados
INSERT INTO Jogo(idEstudio,nomeJogo,descricao,dataLancamento,valor)
VALUES (1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','15/05/2012',99),
(2,'Red Dead Redemption II','jogo eletr�nico de a��o-aventura western.','26/10/2018',120);
GO

-- Inserindo tipos de usu�rio da aplica��o
INSERT INTO TipoUsuario(titulo)
VALUES ('Administrador'),('Cliente');
GO

-- Inserindo dados dos Usu�rios
INSERT INTO Usuario(idTipoUsuario,email,senha)
VALUES (1,'admin@admin.com','admin'),(2,'cliente@cliente.com','cliente');
GO


