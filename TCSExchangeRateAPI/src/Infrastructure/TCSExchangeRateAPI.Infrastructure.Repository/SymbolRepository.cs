using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Infrastructure.Interfaces;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Infrastructure.Repository
{
    public class SymbolRepository : ISymbolRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SymbolRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool Delete(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolId", symbol.Id);

                var result = connection.Execute("SymbolsDelete", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolId", symbol.Id);

                var result = await connection.ExecuteAsync("SymbolsDelete", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public Symbol Get(int symbolId)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolId", symbolId);

                var symbol = connection.QuerySingle<Symbol>("SymbolGetByID", param: p, commandType: CommandType.StoredProcedure);

                return symbol;
            }
        }

        public async Task<Symbol> GetAsync(int symbolId)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolId", symbolId);

                var symbol = await connection.QuerySingleAsync<Symbol>("SymbolGetByID", param: p, commandType: CommandType.StoredProcedure);

                return symbol;
            }
        }

        public IEnumerable<Symbol> GetAll()
        {
            using (var connection = _connectionFactory.Connection)
            {
                var symbols = connection.Query<Symbol>("SymbolsList", commandType: CommandType.StoredProcedure);

                return symbols;
            }
        }

        public async Task<IEnumerable<Symbol>> GetAllAsync()
        {
            using (var connection = _connectionFactory.Connection)
            {
                var symbols = await connection.QueryAsync<Symbol>("SymbolsList", commandType: CommandType.StoredProcedure);

                return symbols;
            }
        }

        public bool Insert(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolCode", symbol.SymbolCode);
                p.Add("@SymbolName", symbol.SymbolName);
                
                var result = connection.Execute("SymbolsInsert", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> InsertAsync(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@SymbolCode", symbol.SymbolCode);
                p.Add("@SymbolName", symbol.SymbolName);

                var result = await connection.ExecuteAsync("SymbolsInsert", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool Update(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", symbol.Id);
                p.Add("@SymbolCode", symbol.SymbolCode);
                p.Add("@SymbolName", symbol.SymbolName);
                p.Add("@Active", symbol.Active);

                var result = connection.Execute("SymbolsUpdate", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Symbol symbol)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", symbol.Id);
                p.Add("@SymbolCode", symbol.SymbolCode);
                p.Add("@SymbolName", symbol.SymbolName);
                p.Add("@Active", symbol.Active);

                var result = await connection.ExecuteAsync("SymbolsUpdate", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
