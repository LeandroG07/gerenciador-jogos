using GerenciamentoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Repositories
{
    public interface IJogoRepository : IRepository<Jogo>
    {
        new Jogo Obter(int id);
        new IEnumerable<Jogo> Listar();
        new void Inserir(Jogo jogo);
        new void Atualizar(Jogo jogo);
        new void Excluir(int id);
        IEnumerable<Jogo> Listar(string filtro);
    }
}
