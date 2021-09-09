-- DQL

USE inlock_games_manha;
GO

--Listar todos os Usu�rios
SELECT * FROM Usuario;

--Listar todos os Est�dios
SELECT * FROM Estudio;

--Listar todos os Jogos
SELECT * FROM Jogo;

--Listar todos os jogos e seus respectivos est�dios;
SELECT nomeJogo 'Jogos', nomeEstudio 'Est�dios'
FROM Jogo J
LEFT JOIN Estudio E 
ON J.idEstudio = E.idEstudio;
GO

--Buscar e trazer na lista todos os est�dios com os respectivos jogos 
--mesmo que eles n�o contenham nenhum jogo de refer�ncia
SELECT nomeEstudio 'Est�dio', nomeJogo 'Jogo'
FROM Estudio E
LEFT JOIN Jogo J
ON E.idEstudio = J.idEstudio;
GO

--Buscar um usu�rio por e-mail e senha (login);
SELECT email, senha 
FROM Usuario
WHERE email='admin@admin.com' AND senha='admin';
GO
--Em 'admin@admin.com' trocar por EX: @Email e no 'admin' trocar por EX: @Senha na API

--Buscar um jogo por idJogo;
SELECT idJogo, nomeEstudio 'Est�dio', nomeJogo 'Jogo', dataLancamento 'Data de Lan�amento', descricao 'Descri��o', valor 
FROM Jogo J
LEFT JOIN Estudio E 
ON J.idEstudio = E.idEstudio
WHERE idJogo= 1
GO
--Em 'idJogo= "1" trocar por EX: @idJogo na API

--Buscar um est�dio por idEstudio;
SELECT idEstudio, nomeEstudio 'Est�dio'
FROM Estudio
WHERE idEstudio= 1;
GO
--Em 'idEstudio= "1"; trocar por EX: @idEstudio na API


