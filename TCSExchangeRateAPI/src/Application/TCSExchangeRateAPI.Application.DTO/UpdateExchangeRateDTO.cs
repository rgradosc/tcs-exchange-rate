namespace TCSExchangeRateAPI.Application.DTO
{
    public class UpdateExchangeRateDTO
    {
        public string Base { get; set; }

        public string Target { get; set; }

        public decimal Rate { get; set; }
    }
}
