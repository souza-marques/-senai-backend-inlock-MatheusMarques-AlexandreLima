USE InLock_Games_Manha;

-- Listar todos os usuários
SELECT * FROM Usuarios;
-- Listar todos os estúdios
SELECT * FROM Estudios;
-- Listar todos os jogos
SELECT * FROM Jogos;
-- Listar todos os jogos e seus respectivos estúdios
SELECT Nome, NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio;
-- Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência


-- Busca um usuário através do E-mail e da Senha
SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U
INNER JOIN TipoUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin'

-- Buscar um jogo através do  IdJogo;
SELECT Nome, Descricao, DataLancamento, Valor FROM Jogos
WHERE IdJogo = 1;

-- Buscar um estúdio através do seu  Id
SELECT NomeEstudio FROM Estudios
WHERE IdEstudio = 2;

----- Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência; 
SELECT * FROM Estudios LEFT OUTER JOIN Jogos ON Estudios.IdEstudio = Jogos.IdJogo 

