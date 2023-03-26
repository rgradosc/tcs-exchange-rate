using System;

namespace TCSExchangeRateAPI.Domain.Entity
{
    public class ExchangeRate
    {
        public int Id { get; set; }

        public string BaseCurrency { get; set; }

        public string TargetCurrency { get; set; }

        public decimal BaseRate { get; set; }

        public string DateLastRate { get; set; }

        public string Active { get; set; }

        public ExchangeRate()
        {
            DateLastRate = DateTime.Now.ToString("d");
        }

        public ExchangeRate(string baseCurrency, string targetCurrency, decimal baseRate)
        {
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
            BaseRate = baseRate;
            DateLastRate = DateTime.Now.ToString("d");
            Active = "N";
        }
    }
}
