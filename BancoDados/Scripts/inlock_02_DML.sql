--DML

USE inlock_games_manha;
GO

-- Inserindo Estudios 
INSERT INTO Estudio(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

-- Inserindo Jogos e seus respectivos dados
INSERT INTO Jogo(idEstudio,nomeJogo,descricao,dataLancamento,valor)
VALUES (1,'Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','15/05/2012',99),
(2,'Red Dead Redemption II','jogo eletrônico de ação-aventura western.','26/10/2018',120);
GO

-- Inserindo tipos de usuário da aplicação
INSERT INTO TipoUsuario(titulo)
VALUES ('Administrador'),('Cliente');
GO

-- Inserindo dados dos Usuários
INSERT INTO Usuario(idTipoUsuario,email,senha)
VALUES (1,'admin@admin.com','admin'),(2,'cliente@cliente.com','cliente');
GO


