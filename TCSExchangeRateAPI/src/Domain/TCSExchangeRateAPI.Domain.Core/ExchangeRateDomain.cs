using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;

namespace TCSExchangeRateAPI.Domain.Core
{
    public class ExchangeRateDomain : IExchangeRateDomain
    {
        public bool Insert(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public bool Update(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public ExchangeRate Get(int rateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(ExchangeRate exchangeRate)
        {
            throw new NotImplementedException();
        }

        public Task<ExchangeRate> GetAsync(int rateId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
