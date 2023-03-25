using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Infrastructure.Interfaces;

namespace TCSExchangeRateAPI.Domain.Core
{
    public class ExchangeRateDomain : IExchangeRateDomain
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateDomain(IExchangeRateRepository exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public bool Insert(ExchangeRate exchangeRate)
        {
            return _exchangeRateRepository.Insert(exchangeRate);
        }

        public bool Update(ExchangeRate exchangeRate)
        {
            return _exchangeRateRepository.Update(exchangeRate);
        }

        public bool Delete(ExchangeRate exchangeRate)
        {
            return _exchangeRateRepository.Delete(exchangeRate);
        }

        public ExchangeRate Get(int rateId)
        {
            return _exchangeRateRepository.Get(rateId);
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            return _exchangeRateRepository.GetAll();
        }

        public async Task<bool> InsertAsync(ExchangeRate exchangeRate)
        {
            return await _exchangeRateRepository.InsertAsync(exchangeRate);
        }

        public async Task<bool> UpdateAsync(ExchangeRate exchangeRate)
        {
            return await _exchangeRateRepository.UpdateAsync(exchangeRate);
        }

        public async Task<bool> DeleteAsync(ExchangeRate exchangeRate)
        {
            return await _exchangeRateRepository.DeleteAsync(exchangeRate);
        }

        public async Task<ExchangeRate> GetAsync(int rateId)
        {
            return await _exchangeRateRepository.GetAsync(rateId);
        }

        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            return await _exchangeRateRepository.GetAllAsync();
        }
    }
}
