USE jogodb
GO

CREATE TABLE Emprestimo
(
	IdEmprestimo	INT				PRIMARY KEY		IDENTITY(1,1),
	DataEmprestimo	DATETIME		NOT NULL,
	DataDevolvido	DATETIME		NULL,
	IdJogo			INT				NOT NULL,
	IdAmigo			INT				NOT NULL,

	FOREIGN KEY (IdJogo) REFERENCES Jogo(IdJogo),
	FOREIGN KEY (IdAmigo) REFERENCES Amigo(IdAmigo)
)