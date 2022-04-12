using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GerenciamentoJogos.Data.Provider
{
    public interface IDbConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString);
    }
}
