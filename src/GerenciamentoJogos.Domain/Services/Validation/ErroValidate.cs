using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services.Validation
{
    public class ErroValidate
    {

        public ErroValidate(string descricao, string detalhes)
        {
            Descricao = descricao;
            Detalhes = detalhes;
        }

        public string Descricao { get; set; }
        public string Detalhes { get; set; }

    }
}
