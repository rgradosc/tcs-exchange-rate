using Microsoft.AspNetCore.Mvc;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Application.Interfaces;

namespace TCSExchangeRateAPI.Services.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SymbolsController : Controller
    {
        private readonly ISymbolApplication _symbolApplication;

        public SymbolsController(ISymbolApplication symbolApplication)
        {
            _symbolApplication = symbolApplication;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _symbolApplication.GetAllAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] SymbolDTO symbolDTO)
        {
            var response = await _symbolApplication.UpdateAsync(symbolDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
    }
}
