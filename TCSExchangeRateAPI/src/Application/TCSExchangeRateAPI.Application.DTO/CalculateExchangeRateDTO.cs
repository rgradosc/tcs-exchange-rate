namespace TCSExchangeRateAPI.Application.DTO
{
    public class CalculateExchangeRateDTO
    {
        public string Base { get; set; }

        public string Target { get; set; }

        public decimal Amount { get; set; }
    }
}
