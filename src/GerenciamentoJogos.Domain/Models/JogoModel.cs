using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoJogos.Domain.Models
{
    public class JogoModel
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(150)]
        public string Nome { get; set; }
    }
}
