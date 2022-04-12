using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services.Validation
{
    public class ValidationValidate
    {
        public ValidationValidate(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

    }
}
