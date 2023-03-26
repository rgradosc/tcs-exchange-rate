using System;

namespace TCSExchangeRateAPI.Application.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
