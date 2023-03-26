using Dapper;
using System.Data;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Infrastructure.Interfaces;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory) 
        { 
            _connectionFactory = connectionFactory;
        }

        public User Authenticate(string userName, string password)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var query = $"SELECT '{userName}' AS 'Username', '{password}' AS 'Password';";

                var user = connection.QuerySingle<User>(query, commandType: CommandType.Text);
                return user;
            }
        }
    }
}
