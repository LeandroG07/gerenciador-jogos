using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Queries
{
    public static class LoginQuery
    {

        #region Logar

        public static readonly string LOGAR =
$@"

SELECT 
    IdLogin AS { nameof(Login.IdLogin) },
    Usuario AS { nameof(Login.Usuario) },
    Senha AS { nameof(Login.Senha) },
    NomeUsuario AS { nameof(Login.NomeUsuario) }
FROM
    [Login]
WHERE
    Usuario = @Usuario
    AND Senha = @Senha
";

        #endregion

    }
}
