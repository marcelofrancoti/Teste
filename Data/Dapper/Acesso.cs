﻿using System.Data;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public  class Acesso
    {
        private IDbConnection _connection;
        public Acesso()
        {
            _connection = new SqlConnection("Data Source=MARCELODEV;Initial Catalog=TESTE;Integrated Security=True;TrustServerCertificate=True;");
        }

        public IDbConnection dbConnectiondbConnection => _connection;
    }
}
