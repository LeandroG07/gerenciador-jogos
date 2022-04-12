using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GerenciamentoJogos.Data.Provider
{
    public class SqlConnectionProvider : IDbConnectionProvider
    {

        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
