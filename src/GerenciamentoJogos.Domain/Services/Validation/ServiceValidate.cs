using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciamentoJogos.Domain.Services.Validation
{
    public class ServiceValidate : IServiceValidate
    {
        public ServiceValidate()
        {
            Erros = new List<ErroValidate>();
            Validacoes = new List<ValidationValidate>();
        }

        public bool Sucesso => !Erros.Any();

        public bool Validacao => Validacoes.Any();

        public IList<ErroValidate> Erros { get; set; }

        public IList<ValidationValidate> Validacoes { get; set; }

        public void AdicionarErro(string mensagem, string detalhes)
        {
            Erros.Add(new ErroValidate(mensagem, detalhes));
        }

        public void AdicionarValidacao(string mensagem)
        {
            Validacoes.Add(new ValidationValidate(mensagem));
        }

    }
}
