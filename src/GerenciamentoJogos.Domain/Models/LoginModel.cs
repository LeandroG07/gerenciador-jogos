using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoJogos.Domain.Models
{
    public class LoginModel
    {
        public int IdLogin { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string NomeUsuario { get; set; }
    }
}
