using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Infrastructure.Interfaces;

namespace TCSExchangeRateAPI.Domain.Core
{
    public class SymbolDomain : ISymbolDomain
    {
        private ISymbolRepository _symbolRepository;

        public SymbolDomain(ISymbolRepository symbolRepository)
        {
            _symbolRepository = symbolRepository;
        }

        public bool Insert(Symbol symbol)
        {
            return _symbolRepository.Insert(symbol);
        }

        public bool Update(Symbol symbol)
        {
            return _symbolRepository.Update(symbol);
        }

        public bool Delete(Symbol symbol)
        {
            return _symbolRepository.Delete(symbol);
        }

        public Symbol Get(int symbolId)
        {
            return _symbolRepository.Get(symbolId);
        }

        public IEnumerable<Symbol> GetAll()
        {
            return _symbolRepository.GetAll();
        }

        public async Task<bool> InsertAsync(Symbol symbol)
        {
            return await _symbolRepository.InsertAsync(symbol);
        }

        public async Task<bool> UpdateAsync(Symbol symbol)
        {
            return await _symbolRepository.UpdateAsync(symbol);
        }

        public async Task<bool> DeleteAsync(Symbol symbol)
        {
            return await _symbolRepository.DeleteAsync(symbol);
        }

        public async Task<Symbol> GetAsync(int symbolId)
        {
            return await _symbolRepository.GetAsync(symbolId);
        }

        public async Task<IEnumerable<Symbol>> GetAllAsync()
        {
            return await _symbolRepository.GetAllAsync();
        }
    }
}
