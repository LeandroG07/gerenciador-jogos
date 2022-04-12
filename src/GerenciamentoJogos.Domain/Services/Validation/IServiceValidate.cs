using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services.Validation
{
    public interface IServiceValidate
    {
        bool Sucesso { get; }

        bool Validacao { get; }

        IList<ErroValidate> Erros { get; }

        IList<ValidationValidate> Validacoes { get; set; }

        void AdicionarErro(string mensagem, string detalhes);

        void AdicionarValidacao(string mensagem);

    }
}
