using GerenciamentoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoJogos.WebApi.ViewModel
{
    public class EmprestimoViewModel
    {

        public EmprestimoModel EmprestimoModel;

        public IEnumerable<JogoModel> JogosModel;

        public IEnumerable<AmigoModel> AmigosModel;

    }
}
