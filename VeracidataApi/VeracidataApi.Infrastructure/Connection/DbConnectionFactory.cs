using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using VeracidataApi.Infrastructure.Settings;

namespace VeracidataApi.Infrastructure.Connection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly ConnectionStrings _cs;
        public DbConnectionFactory(IOptions<ConnectionStrings> options) =>
            _cs = options.Value;

        public IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(_cs.Default);
            conn.Open();
            return conn;
        }
    }
}
