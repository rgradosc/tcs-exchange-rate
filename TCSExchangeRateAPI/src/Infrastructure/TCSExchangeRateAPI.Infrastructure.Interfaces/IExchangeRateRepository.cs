using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Infrastructure.Interfaces
{
    public interface IExchangeRateRepository
    {
        bool Insert(ExchangeRate exchangeRate);

        bool Update(ExchangeRate exchangeRate);

        bool Delete(ExchangeRate exchangeRate);

        ExchangeRate Get(int rateId);

        IEnumerable<ExchangeRate> GetAll();

        Task<bool> InsertAsync(ExchangeRate exchangeRate);

        Task<bool> UpdateAsync(ExchangeRate exchangeRate);

        Task<bool> DeleteAsync(ExchangeRate exchangeRate);

        Task<ExchangeRate> GetAsync(int rateId);

        Task<IEnumerable<ExchangeRate>> GetAllAsync();
    }
}
