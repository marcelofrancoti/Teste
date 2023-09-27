using System.Data;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public  class Acesso
    {
        private IDbConnection _connection;
        public Acesso()
        {
            _connection = new SqlConnection("StringConexao");
        }

        public IDbConnection dbConnectiondbConnection => _connection;
    }
}
