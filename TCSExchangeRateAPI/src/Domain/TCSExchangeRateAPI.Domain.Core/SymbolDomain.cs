using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;

namespace TCSExchangeRateAPI.Domain.Core
{
    public class SymbolDomain : ISymbolDomain
    {
        public bool Insert(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public bool Update(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public Symbol Get(int symbolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Symbol> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public Task<Symbol> GetAsync(int symbolId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Symbol>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
