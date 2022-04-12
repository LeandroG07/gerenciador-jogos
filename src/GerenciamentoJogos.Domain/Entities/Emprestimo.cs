using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Entities
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime? DataDevolvido { get; set; }

        public Jogo Jogo { get; set; }

        public Amigo Amigo { get; set; }
    }
}
