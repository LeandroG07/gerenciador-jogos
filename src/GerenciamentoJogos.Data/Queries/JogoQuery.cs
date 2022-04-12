using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Queries
{
    public static class JogoQuery
    {
        #region Obter
        public static readonly string OBTER =
@$"
SELECT
    IdJogo AS { nameof(Jogo.IdJogo) },
    Nome AS { nameof(Jogo.Nome) }
FROM
    Jogo WITH(NOLOCK)
WHERE
    IdJogo = @idJogo
";
        #endregion

        #region Listar
        public static readonly string LISTAR =
@$"
SELECT	
    J.IdJogo AS { nameof(Jogo.IdJogo) },
    J.Nome AS { nameof(Jogo.Nome) }
FROM
    Jogo J WITH(NOLOCK)
LEFT JOIN
	Emprestimo E WITH(NOLOCK)
		ON E.IdJogo = J.IdJogo
		AND E.DataDevolvido IS NULL
WHERE 
	E.IdEmprestimo IS NULL
ORDER BY
    Nome ASC
";
        #endregion

        #region Listar por Nome
        public static readonly string LISTAR_FILTRO_NOME =
@$"
SELECT
    IdJogo AS { nameof(Jogo.IdJogo) },
    Nome AS { nameof(Jogo.Nome) }
FROM
    Jogo WITH(NOLOCK)
WHERE
    Nome LIKE '%@nome%'
ORDER BY
    Nome ASC
";
        #endregion

        #region Inserir
        public static readonly string INSERIR =
@$"
INSERT INTO
    Jogo
    (
        Nome
    )
VALUES
    (
        @Nome
    )
";
        #endregion

        #region Atualizar
        public static readonly string ATUALIZAR =
@$"
UPDATE
    Jogo
SET 
    Nome = @Nome
WHERE
    IdJogo = @idJogo

";
        #endregion

        #region Excluir
        public static readonly string EXCLUIR =
@$"
DELETE FROM
    Jogo
WHERE
    IdJogo = @idJogo
";
        #endregion
    }
}
