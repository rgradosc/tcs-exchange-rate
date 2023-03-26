using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Application.Interfaces
{
    public interface IExchangeRateApplication
    {
        Response<ConvertExchangeRateDTO> ConvertExchangeRate(CalculateExchangeRateDTO calculateDTO);

        Response<ListExchangeRateDTO> Get(string baseCurrency, string targetCurrency);

        Response<IEnumerable<ListExchangeRateDTO>> GetAll();

        Response<bool> Update(UpdateExchangeRateDTO updateDTO);

        Task<Response<ConvertExchangeRateDTO>> ConvertExchangeRateAsync(CalculateExchangeRateDTO calculateDTO);

        Task<Response<ListExchangeRateDTO>> GetAsync(string baseCurrency, string targetCurrency);

        Task<Response<IEnumerable<ListExchangeRateDTO>>> GetAllAsync();

        Task<Response<bool>> UpdateAsync(UpdateExchangeRateDTO updateDTO);
    }
}
