using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Queries
{
    public static class AmigoQuery
    {
        #region Obter
        public static readonly string OBTER =
@$"
SELECT
    IdAmigo AS { nameof(Amigo.IdAmigo) },
    Nome AS { nameof(Amigo.Nome) },
    Endereco AS { nameof(Amigo.Endereco) },
    Telefone AS { nameof(Amigo.Telefone) }
FROM
    Amigo WITH(NOLOCK)
WHERE
    IdAmigo = @idAmigo
";
        #endregion

        #region Listar
        public static readonly string LISTAR = 
@$"
SELECT
    IdAmigo AS { nameof(Amigo.IdAmigo) },
    Nome AS { nameof(Amigo.Nome) },
    Endereco AS { nameof(Amigo.Endereco) },
    Telefone AS { nameof(Amigo.Telefone) }
FROM
    Amigo WITH(NOLOCK)
ORDER BY
    Nome ASC
";
        #endregion

        #region Listar por Nome
        public static readonly string LISTAR_FILTRO_NOME =
@$"
SELECT
    IdAmigo AS { nameof(Amigo.IdAmigo) },
    Nome AS { nameof(Amigo.Nome) },
    Endereco AS { nameof(Amigo.Endereco) },
    Telefone AS { nameof(Amigo.Telefone) }
FROM
    Amigo WITH(NOLOCK)
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
    Amigo
    (
        Nome, 
        Endereco, 
        Telefone
    )
VALUES
    (
        @Nome, 
        @Endereco, 
        @Telefone
    )
";
        #endregion

        #region Atualizar
        public static readonly string ATUALIZAR =
@$"
UPDATE
    Amigo
SET 
    Nome = @Nome, 
    Endereco = @Endereco, 
    Telefone = @Telefone
WHERE
    IdAmigo = @idAmigo

";
        #endregion

        #region Excluir
        public static readonly string EXCLUIR =
@$"
DELETE FROM
    Amigo
WHERE
    IdAmigo = @idAmigo
";
        #endregion

    }
}
