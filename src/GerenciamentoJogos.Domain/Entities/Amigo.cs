using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoJogos.Domain.Entities
{
    public class Amigo
    {
        public int IdAmigo { get; set; }

        [Display(Name = "Amigo")]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
