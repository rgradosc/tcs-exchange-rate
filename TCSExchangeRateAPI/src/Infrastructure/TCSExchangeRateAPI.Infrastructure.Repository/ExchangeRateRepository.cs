using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Infrastructure.Interfaces;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Infrastructure.Repository
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ExchangeRateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public ExchangeRate Get(string baseCurrency, string targetCurrency)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@BaseCurrency", baseCurrency);
                p.Add("@TargetCurrency", targetCurrency);

                string query = @"
                    SELECT Id, BaseCurrency, TargetCurrency, BaseRate, DateLastRate 
                    FROM Rates 
                    WHERE BaseCurrency=@BaseCurrency AND TargetCurrency=@TargetCurrency;
                ";
                var exchangeRate = connection.QuerySingle<ExchangeRate>(query, param: p, 
                                    commandType: CommandType.Text);

                return exchangeRate;
            }
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            using (var connection = _connectionFactory.Connection)
            {
                string query = @"
                    SELECT  Id, BaseCurrency, 
                            TargetCurrency, BaseRate, 
                            DateLastRate, Active 
                    FROM Rates WHERE Active='Y';
                ";
                var exchangeRate = connection.Query<ExchangeRate>(query, commandType: CommandType.Text);

                return exchangeRate;
            }
        }

        public bool Update(ExchangeRate exchangeRate)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@BaseCurrency", exchangeRate.BaseCurrency);
                p.Add("@TargetCurrency", exchangeRate.TargetCurrency);
                p.Add("@BaseRate", exchangeRate.BaseRate);
                p.Add("@DateLastRate", DateTime.Now.ToString("d"));

                string query = @"
                    UPDATE Rates SET BaseRate=@BaseRate, DateLastRate=@DateLastRate 
                    WHERE BaseCurrency=@BaseCurrency AND TargetCurrency=@TargetCurrency;
                ";
                var result = connection.Execute(query, param: p, commandType: CommandType.Text);

                return result > 0;
            }
        }

        public async Task<ExchangeRate> GetAsync(string baseCurrency, string targetCurrency)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@BaseCurrency", baseCurrency);
                p.Add("@TargetCurrency", targetCurrency);

                string query = @"
                    SELECT Id, BaseCurrency, TargetCurrency, BaseRate, DateLastRate 
                    FROM Rates 
                    WHERE BaseCurrency=@BaseCurrency AND TargetCurrency=@TargetCurrency;
                ";
                var exchangeRate = await connection.QuerySingleAsync<ExchangeRate>(query, param: p,
                                    commandType: CommandType.Text);

                return exchangeRate;
            }
        }

        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            using (var connection = _connectionFactory.Connection)
            {
                string query = @"
                    SELECT  Id, BaseCurrency, 
                            TargetCurrency, BaseRate, 
                            DateLastRate, Active 
                    FROM Rates WHERE Active='Y';
                ";
                var exchangeRate = await connection.QueryAsync<ExchangeRate>(query, commandType: CommandType.Text);

                return exchangeRate;
            }
        }

        public async Task<bool> UpdateAsync(ExchangeRate exchangeRate)
        {
            using (var connection = _connectionFactory.Connection)
            {
                var p = new DynamicParameters();
                p.Add("@BaseCurrency", exchangeRate.BaseCurrency);
                p.Add("@TargetCurrency", exchangeRate.TargetCurrency);
                p.Add("@BaseRate", exchangeRate.BaseRate);
                p.Add("@DateLastRate", DateTime.Now.ToString("d"));

                string query = @"
                    UPDATE Rates SET BaseRate=@BaseRate, DateLastRate=@DateLastRate 
                    WHERE BaseCurrency=@BaseCurrency AND TargetCurrency=@TargetCurrency;
                ";
                var result = await connection.ExecuteAsync(query, param: p, commandType: CommandType.Text);

                return result > 0;
            }
        }
    }
}
