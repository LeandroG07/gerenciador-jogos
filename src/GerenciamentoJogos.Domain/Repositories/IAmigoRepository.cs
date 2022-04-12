using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Repositories
{
    public interface IAmigoRepository : IRepository<Amigo>
    {
        new Amigo Obter(int id);
        new IEnumerable<Amigo> Listar();        
        new void Inserir(Amigo amigo);
        new void Atualizar(Amigo amigo);
        new void Excluir(int id);
        IEnumerable<Amigo> Listar(string filtro);

    }
}
