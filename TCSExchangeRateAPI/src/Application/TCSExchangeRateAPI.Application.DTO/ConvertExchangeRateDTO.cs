namespace TCSExchangeRateAPI.Application.DTO
{
    public class ConvertExchangeRateDTO
    {
        public string Base { get; set; }

        public string Target { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountConverted { get; set; }

    }
}
