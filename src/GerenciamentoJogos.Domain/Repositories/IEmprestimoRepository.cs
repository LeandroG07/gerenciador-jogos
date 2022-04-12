using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Repositories
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        new Emprestimo Obter(int id);
        new IEnumerable<Emprestimo> Listar();
        new void Inserir(Emprestimo emprestimo);
        new void Atualizar(Emprestimo emprestimo);
        new void Excluir(int id);
        IEnumerable<Emprestimo> Listar(string filtro);
        void Receber(Emprestimo emprestimo);
    }
}
