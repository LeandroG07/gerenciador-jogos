using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Entities
{
    public class Login
    {
        public int IdLogin { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string NomeUsuario { get; set; }
    }
}
