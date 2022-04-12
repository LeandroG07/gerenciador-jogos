using GerenciamentoJogos.Data.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GerenciamentoJogos.Data.Context
{
    public class GerenciamentoJogosDbContext
    {        

        public GerenciamentoJogosDbContext(SqlConnectionProvider sqlConnectionProvider, string connectionString)
        {
            Connection = sqlConnectionProvider.GetConnection(connectionString);
        }

        public IDbConnection Connection { get; }

    }
}
