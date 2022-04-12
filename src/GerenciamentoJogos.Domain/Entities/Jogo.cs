using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoJogos.Domain.Entities
{
    public class Jogo
    {
        public int IdJogo { get; set; }

        [Display(Name = "Jogo")]
        public string Nome { get; set; }
    }
}
