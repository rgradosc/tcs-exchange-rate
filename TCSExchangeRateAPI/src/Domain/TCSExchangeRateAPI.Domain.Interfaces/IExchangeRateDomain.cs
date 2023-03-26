﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Domain.Interfaces
{
    public interface IExchangeRateDomain
    {
        bool Update(ExchangeRate exchangeRate);

        ExchangeRate Get(string baseCurrency, string targetCurrency);

        IEnumerable<ExchangeRate> GetAll();
        
        Task<bool> UpdateAsync(ExchangeRate exchangeRate);

        Task<ExchangeRate> GetAsync(string baseCurrency, string targetCurrency);

        Task<IEnumerable<ExchangeRate>> GetAllAsync();
    }
}
