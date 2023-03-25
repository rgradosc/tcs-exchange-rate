using TCSExchangeRateAPI.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.Data;

namespace TCSExchangeRateAPI.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private const string CONNECTION_STRING_NAME = "DefaultConnection";
        private readonly IConfiguration configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                var sqliteConnection = new SqliteConnection();
                if (sqliteConnection == null) { return null; }

                sqliteConnection.ConnectionString = configuration.GetConnectionString(CONNECTION_STRING_NAME);
                sqliteConnection.Open();
                return sqliteConnection;
            }
        }
    }
}
