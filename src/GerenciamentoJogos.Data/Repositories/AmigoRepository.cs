using Dapper;
using GerenciamentoJogos.Data.Context;
using GerenciamentoJogos.Data.Queries;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Data.Infra.Repositories
{
    public class AmigoRepository : IAmigoRepository
    {
        private GerenciamentoJogosDbContext _gerenciamentoJogosContext;        

        public AmigoRepository(GerenciamentoJogosDbContext gerenciamentoJogosContext)
        {
            _gerenciamentoJogosContext = gerenciamentoJogosContext;
        }

        public Amigo Obter(int idAmigo)
        {
            return _gerenciamentoJogosContext.Connection.QueryFirstOrDefault<Amigo>(AmigoQuery.OBTER, new { idAmigo } );
        }

        public IEnumerable<Amigo> Listar()
        {
            return _gerenciamentoJogosContext.Connection.Query<Amigo>(AmigoQuery.LISTAR);
        }

        public IEnumerable<Amigo> Listar(string nome)
        {
            return _gerenciamentoJogosContext.Connection.Query<Amigo>(AmigoQuery.LISTAR_FILTRO_NOME, new { nome });
        }

        public void Atualizar(Amigo amigo)
        {
            _gerenciamentoJogosContext.Connection.Execute(AmigoQuery.ATUALIZAR, amigo);
        }

        public void Excluir(int idAmigo)
        {
            _gerenciamentoJogosContext.Connection.Execute(AmigoQuery.EXCLUIR, new { idAmigo } );
        }

        public void Inserir(Amigo amigo)
        {
            _gerenciamentoJogosContext.Connection.Execute(AmigoQuery.INSERIR, amigo);
        }



    }
}
