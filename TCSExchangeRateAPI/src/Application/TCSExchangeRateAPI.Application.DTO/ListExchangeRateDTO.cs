using System;

namespace TCSExchangeRateAPI.Application.DTO
{
    public class ListExchangeRateDTO
    {
        public int Id { get; set; }

        public string Base { get; set; }

        public string Target { get; set; }

        public decimal Rate { get; set; }

        public string DateLastRate { get; set; }
    }
}
