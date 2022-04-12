using Dapper;
using GerenciamentoJogos.Data.Context;
using GerenciamentoJogos.Data.Queries;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private GerenciamentoJogosDbContext _gerenciamentoJogosContext;

        public JogoRepository(GerenciamentoJogosDbContext gerenciamentoJogosContext)
        {
            _gerenciamentoJogosContext = gerenciamentoJogosContext;
        }

        public Jogo Obter(int idJogo)
        {
            return _gerenciamentoJogosContext.Connection.QueryFirstOrDefault<Jogo>(JogoQuery.OBTER, new { idJogo });
        }

        public IEnumerable<Jogo> Listar()
        {
            return _gerenciamentoJogosContext.Connection.Query<Jogo>(JogoQuery.LISTAR);
        }

        public IEnumerable<Jogo> Listar(string nome)
        {
            return _gerenciamentoJogosContext.Connection.Query<Jogo>(JogoQuery.LISTAR_FILTRO_NOME, new { nome });
        }

        public void Atualizar(Jogo Jogo)
        {
            _gerenciamentoJogosContext.Connection.Execute(JogoQuery.ATUALIZAR, Jogo);
        }

        public void Excluir(int idJogo)
        {
            _gerenciamentoJogosContext.Connection.Execute(JogoQuery.EXCLUIR, new { idJogo });
        }

        public void Inserir(Jogo Jogo)
        {
            _gerenciamentoJogosContext.Connection.Execute(JogoQuery.INSERIR, Jogo);
        }
    }
}
