using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Application.Interfaces;
using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Application.Main
{
    public class ExchangeRateApplication : IExchangeRateApplication
    {
        private readonly IExchangeRateDomain _exchangeRateDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ExchangeRateApplication> _logger;

        public ExchangeRateApplication(IExchangeRateDomain exchangeRateDomain,
            IMapper mapper,
            IAppLogger<ExchangeRateApplication> logger)
        {
            _exchangeRateDomain = exchangeRateDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<ConvertExchangeRateDTO> ConvertExchangeRate(CalculateExchangeRateDTO calculateDTO)
        {
            var response = new Response<ConvertExchangeRateDTO>();

            try
            {
                var exchangeRate = _exchangeRateDomain.Get(calculateDTO.Base, calculateDTO.Target);
                if (exchangeRate != null) 
                {
                    decimal amountConverted = calculateDTO.Amount * exchangeRate.BaseRate;
                    response.Data = new ConvertExchangeRateDTO
                    {
                        Amount = calculateDTO.Amount,
                        AmountConverted = amountConverted,
                        Base = calculateDTO.Base,
                        Target = calculateDTO.Target,
                        ExchangeRate = exchangeRate.BaseRate,
                    };
                    response.IsSuccess = true;
                    response.Message = "Conversión a tipo de cambio exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public Response<ListExchangeRateDTO> Get(string baseCurrency, string targetCurrency)
        {
            var response = new Response<ListExchangeRateDTO>();

            try
            {
                var exchangeRate = _exchangeRateDomain.Get(baseCurrency, targetCurrency);
                response.Data = _mapper.Map<ListExchangeRateDTO>(exchangeRate);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public Response<IEnumerable<ListExchangeRateDTO>> GetAll()
        {
            var response = new Response<IEnumerable<ListExchangeRateDTO>>();

            try
            {
                var exchangesRates = _exchangeRateDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<ListExchangeRateDTO>>(exchangesRates);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public Response<bool> Update(UpdateExchangeRateDTO updateDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<ExchangeRate>(updateDTO);
                response.Data = _exchangeRateDomain.Update(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacíón exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public async Task<Response<ConvertExchangeRateDTO>> ConvertExchangeRateAsync(CalculateExchangeRateDTO calculateDTO)
        {
            var response = new Response<ConvertExchangeRateDTO>();

            try
            {
                var exchangeRate = await _exchangeRateDomain.GetAsync(calculateDTO.Base, calculateDTO.Target);
                if (exchangeRate != null)
                {
                    decimal amountConverted = calculateDTO.Amount * exchangeRate.BaseRate;
                    response.Data = new ConvertExchangeRateDTO
                    {
                        Amount = calculateDTO.Amount,
                        AmountConverted = amountConverted,
                        Base = calculateDTO.Base,
                        Target = calculateDTO.Target,
                        ExchangeRate = exchangeRate.BaseRate,
                    };
                    response.IsSuccess = true;
                    response.Message = $"Conversión de {calculateDTO.Base} al tipo de cambio en {calculateDTO.Target} exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public async Task<Response<ListExchangeRateDTO>> GetAsync(string baseCurrency, string targetCurrency)
        {
            var response = new Response<ListExchangeRateDTO>();

            try
            {
                var exchangeRate = await _exchangeRateDomain.GetAsync(baseCurrency, targetCurrency);
                response.Data = _mapper.Map<ListExchangeRateDTO>(exchangeRate);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<ListExchangeRateDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ListExchangeRateDTO>>();

            try
            {
                var exchangesRates = await _exchangeRateDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ListExchangeRateDTO>>(exchangesRates);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(UpdateExchangeRateDTO updateDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<ExchangeRate>(updateDTO);
                response.Data = await _exchangeRateDomain.UpdateAsync(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacíón exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }
    }
}
