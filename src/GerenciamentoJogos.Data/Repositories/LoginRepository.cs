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
    public class LoginRepository : ILoginRepository
    {

        private GerenciamentoJogosDbContext _gerenciamentoJogosContext;

        public LoginRepository(GerenciamentoJogosDbContext gerenciamentoJogosContext)
        {
            _gerenciamentoJogosContext = gerenciamentoJogosContext;
        }

        public Login Logar(Login login)
        {
            return _gerenciamentoJogosContext.Connection.QueryFirstOrDefault<Login>(LoginQuery.LOGAR, login);
        }
    }
}
