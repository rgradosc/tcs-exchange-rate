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

        public bool Update(ExchangeRate exchangeRate)
        {
            return _exchangeRateRepository.Update(exchangeRate);
        }

        public ExchangeRate Get(string baseCurrency, string targetCurrency)
        {
            return _exchangeRateRepository.Get(baseCurrency, targetCurrency);
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            return _exchangeRateRepository.GetAll();
        }

        public async Task<bool> UpdateAsync(ExchangeRate exchangeRate)
        {
            return await _exchangeRateRepository.UpdateAsync(exchangeRate);
        }

        public async Task<ExchangeRate> GetAsync(string baseCurrency, string targetCurrency)
        {
            return await _exchangeRateRepository.GetAsync(baseCurrency, targetCurrency);
        }

        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            return await _exchangeRateRepository.GetAllAsync();
        }
    }
}
