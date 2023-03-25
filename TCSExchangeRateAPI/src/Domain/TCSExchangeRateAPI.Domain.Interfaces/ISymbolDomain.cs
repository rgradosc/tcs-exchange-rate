using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Domain.Interfaces
{
    public interface ISymbolDomain
    {
        bool Insert(Symbol symbol);

        bool Update(Symbol symbol);

        bool Delete(Symbol symbol);

        Symbol Get(int symbolId);

        IEnumerable<Symbol> GetAll();

        Task<bool> InsertAsync(Symbol symbol);

        Task<bool> UpdateAsync(Symbol symbol);

        Task<bool> DeleteAsync(Symbol symbol);

        Task<Symbol> GetAsync(int symbolId);

        Task<IEnumerable<Symbol>> GetAllAsync();
    }
}
