using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Queries
{
    public static class EmprestimoQuery
    {
        #region Obter
        public static readonly string OBTER =
@$"
SELECT
	E.IdEmprestimo,
	E.DataEmprestimo,
	E.DataDevolvido,
	J.IdJogo,
	J.Nome,
	A.IdAmigo,
	A.Nome,
	A.Endereco,
	A.Telefone
FROM
	Emprestimo E WITH(NOLOCK)
INNER JOIN 
	Jogo J WITH(NOLOCK)
		ON J.IdJogo = E.IdJogo
INNER JOIN 
	Amigo A WITH(NOLOCK)
		ON A.IdAmigo = E.IdAmigo
WHERE
    E.IdEmprestimo = @idEmprestimo
";
        #endregion

        #region Listar
        public static readonly string LISTAR =
@$"
SELECT
	E.IdEmprestimo,
	E.DataEmprestimo,
	E.DataDevolvido,
	J.IdJogo,
	J.Nome,
	A.IdAmigo,
	A.Nome,
	A.Endereco,
	A.Telefone
FROM
	Emprestimo E WITH(NOLOCK)
INNER JOIN 
	Jogo J WITH(NOLOCK)
		ON J.IdJogo = E.IdJogo
INNER JOIN 
	Amigo A WITH(NOLOCK)
		ON A.IdAmigo = E.IdAmigo
WHERE 
    E.DataDevolvido IS NULL
ORDER BY 
    J.Nome ASC
";
        #endregion

        #region Listar por Nome
        public static readonly string LISTAR_FILTRO_NOME =
@$"
SELECT
	E.IdEmprestimo,
	E.DataEmprestimo,
	E.DataDevolvido,
	J.IdJogo,
	J.Nome,
	A.IdAmigo,
	A.Nome,
	A.Endereco,
	A.Telefone
FROM
	Emprestimo E WITH(NOLOCK)
INNER JOIN 
	Jogo J WITH(NOLOCK)
		ON J.IdJogo = E.IdJogo
INNER JOIN 
	Amigo A WITH(NOLOCK)
		ON A.IdAmigo = E.IdAmigo
WHERE
    J.Nome LIKE '%@nome%'
ORDER BY 
    J.Nome ASC
";
        #endregion

        #region Inserir
        public static readonly string INSERIR =
@$"
INSERT INTO
    Emprestimo
    (
        DataEmprestimo,
        DataDevolvido,
        IdJogo,
        IdAmigo
    )
VALUES
    (
        @DataEmprestimo,
        @DataDevolvido,
        @IdJogo,
        @IdAmigo
    )
";
        #endregion

        #region Atualizar
        public static readonly string ATUALIZAR =
@$"
UPDATE
    Emprestimo
SET 
    DataEmprestimo = @DataEmprestimo,
    DataDevolvido = @DataDevolvido,
    IdJogo = @IdJogo,
    IdAmigo = @IdAmigo
WHERE
    IdEmprestimo = @IdEmprestimo

";
        #endregion

        #region Receber
        public static readonly string RECEBER =
@$"
UPDATE
    Emprestimo
SET 
    DataDevolvido = GETDATE()
WHERE
    IdEmprestimo = @IdEmprestimo

";
        #endregion

        //        #region Excluir
        //        public static readonly string EXCLUIR =
        //@$"
        //DELETE FROM
        //    Amigo
        //WHERE
        //    IdAmigo = @idAmigo
        //";
        //#endregion
    }
}
