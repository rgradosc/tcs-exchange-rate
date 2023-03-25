namespace TCSExchangeRateAPI.Domain.Entity
{
    public class Symbol
    {
        public int Id { get; set; }

        public string SymbolCode { get; set; }

        public string SymbolName { get; set; }

        public bool Active { get; set; }

        public Symbol()
        {
            
        }

        public Symbol(string symbolCode, string symbolName)
        {
            SymbolCode = symbolCode;
            SymbolName = symbolName;
            Active = true;
        }
    }
}
