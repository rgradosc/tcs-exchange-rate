using Microsoft.AspNetCore.Mvc;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Application.Interfaces;

namespace TCSExchangeRateAPI.Services.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExchangeRatesController : Controller
    {
        private readonly IExchangeRateApplication _exchangeRateApplication;

        public ExchangeRatesController(IExchangeRateApplication exchangeRateApplication)
        {
            _exchangeRateApplication = exchangeRateApplication;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertAsync([FromQuery] CalculateExchangeRateDTO calculateDTO)
        {
            var response = await _exchangeRateApplication.ConvertExchangeRateAsync(calculateDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("latest/base/{baseCurrency}/target/{targetCurrency}")]
        public async Task<IActionResult> GetAsync(string baseCurrency, string targetCurrency)
        {
            var response = await _exchangeRateApplication.GetAsync(baseCurrency, targetCurrency);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _exchangeRateApplication.GetAllAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateExchangeRateDTO updateDTO)
        {
            var response = await _exchangeRateApplication.UpdateAsync(updateDTO);
            
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
    }
}
