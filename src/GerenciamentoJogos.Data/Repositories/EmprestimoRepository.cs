using Dapper;
using GerenciamentoJogos.Data.Context;
using GerenciamentoJogos.Data.Queries;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciamentoJogos.Data.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {

        private GerenciamentoJogosDbContext _gerenciamentoJogosContext;

        public EmprestimoRepository(GerenciamentoJogosDbContext gerenciamentoJogosContext)
        {
            _gerenciamentoJogosContext = gerenciamentoJogosContext;
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _gerenciamentoJogosContext.Connection.Execute
                (
                    EmprestimoQuery.ATUALIZAR, 
                    param: new
                    {
                        emprestimo.IdEmprestimo,
                        emprestimo.DataEmprestimo,
                        emprestimo.DataDevolvido,
                        emprestimo.Jogo.IdJogo,
                        emprestimo.Amigo.IdAmigo
                    }
                );
        }

        public void Receber(Emprestimo emprestimo)
        {
            _gerenciamentoJogosContext.Connection.Execute
                (
                    EmprestimoQuery.RECEBER,
                    param: new
                    {
                        emprestimo.IdEmprestimo
                    }
                );
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Emprestimo emprestimo)
        {            
            _gerenciamentoJogosContext.Connection.Execute
                (
                    EmprestimoQuery.INSERIR, 
                    param: new
                    {
                        emprestimo.IdEmprestimo,
                        emprestimo.DataEmprestimo,
                        emprestimo.DataDevolvido,
                        emprestimo.Jogo.IdJogo,
                        emprestimo.Amigo.IdAmigo
                    }
                );
        }

        public IEnumerable<Emprestimo> Listar()
        {
            return _gerenciamentoJogosContext.Connection.Query<Emprestimo, Jogo, Amigo, Emprestimo>
                (
                    EmprestimoQuery.LISTAR, 
                    (e, j, a) => { e.Jogo = j; e.Amigo = a; return e; }, 
                    splitOn: "IdJogo,IdAmigo"
                );
        }

        public IEnumerable<Emprestimo> Listar(string nome)
        {
            return _gerenciamentoJogosContext.Connection.Query<Emprestimo, Jogo, Amigo, Emprestimo>
                (
                    EmprestimoQuery.LISTAR,
                    (e, j, a) => { e.Jogo = j; e.Amigo = a; return e; },
                    param: new { nome },
                    splitOn: "IdJogo,IdAmigo"
                );
        }

        public Emprestimo Obter(int idEmprestimo)
        {
            return _gerenciamentoJogosContext.Connection.Query<Emprestimo, Jogo, Amigo, Emprestimo>
                (
                    EmprestimoQuery.OBTER, 
                    (e, j, a) => { e.Jogo = j; e.Amigo = a; return e; }, 
                    param: new { idEmprestimo }, 
                    splitOn: "IdJogo,IdAmigo"
                ).FirstOrDefault();
        }
    }
}
