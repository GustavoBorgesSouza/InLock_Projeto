-- DQL

USE inlock_games_manha;
GO

--Listar todos os Usuários
SELECT * FROM Usuario;

--Listar todos os Estúdios
SELECT * FROM Estudio;

--Listar todos os Jogos
SELECT * FROM Jogo;

--Listar todos os jogos e seus respectivos estúdios;
SELECT nomeJogo 'Jogos', nomeEstudio 'Estúdios'
FROM Jogo J
LEFT JOIN Estudio E 
ON J.idEstudio = E.idEstudio;
GO

--Buscar e trazer na lista todos os estúdios com os respectivos jogos 
--mesmo que eles não contenham nenhum jogo de referência
SELECT nomeEstudio 'Estúdio', nomeJogo 'Jogo'
FROM Estudio E
LEFT JOIN Jogo J
ON E.idEstudio = J.idEstudio;
GO

--Buscar um usuário por e-mail e senha (login);
SELECT email, senha 
FROM Usuario
WHERE email='admin@admin.com' AND senha='admin';
GO
--Em 'admin@admin.com' trocar por EX: @Email e no 'admin' trocar por EX: @Senha na API

--Buscar um jogo por idJogo;
SELECT idJogo, nomeEstudio 'Estúdio', nomeJogo 'Jogo', dataLancamento 'Data de Lançamento', descricao 'Descrição', valor 
FROM Jogo J
LEFT JOIN Estudio E 
ON J.idEstudio = E.idEstudio
WHERE idJogo= 1
GO
--Em 'idJogo= "1" trocar por EX: @idJogo na API

--Buscar um estúdio por idEstudio;
SELECT idEstudio, nomeEstudio 'Estúdio'
FROM Estudio
WHERE idEstudio= 1;
GO
--Em 'idEstudio= "1"; trocar por EX: @idEstudio na API


