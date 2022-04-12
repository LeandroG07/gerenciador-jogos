using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Obter(int id);
        IEnumerable<T> Listar();        
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}
