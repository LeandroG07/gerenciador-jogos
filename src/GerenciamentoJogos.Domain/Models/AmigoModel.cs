using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoJogos.Domain.Models
{
    public class AmigoModel
    {        
        public int IdAmigo { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(250)]
        public string Endereco { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

    }
}
