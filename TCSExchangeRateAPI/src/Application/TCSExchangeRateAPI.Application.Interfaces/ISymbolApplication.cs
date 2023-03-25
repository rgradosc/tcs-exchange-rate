using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Application.Interfaces
{
    public interface ISymbolApplication
    {
        Response<bool> Insert(SymbolDTO symbolDTO);

        Response<bool> Update(SymbolDTO symbolDTO);

        Response<bool> Delete(int symbolId);

        Response<SymbolDTO> Get(int symbolId);

        Response<IEnumerable<SymbolDTO>> GetAll();

        Task<Response<bool>> InsertAsync(SymbolDTO symbolDTO);

        Task<Response<bool>> UpdateAsync(SymbolDTO symbolDTO);

        Task<Response<bool>> DeleteAsync(int symbolId);

        Task<Response<SymbolDTO>> GetAsync(int symbolId);

        Task<Response<IEnumerable<SymbolDTO>>> GetAllAsync();
    }
}
