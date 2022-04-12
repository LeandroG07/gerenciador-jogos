using GerenciamentoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services
{
    public interface IEmprestimoService
    {
        EmprestimoModel Obter(int id);

        IEnumerable<EmprestimoModel> Listar();

        void Inserir(EmprestimoModel emprestimoModel);

        void Atualizar(EmprestimoModel emprestimoModel);

        void Excluir(int id);

        void Receber(EmprestimoModel emprestimoModel);
    }
}
