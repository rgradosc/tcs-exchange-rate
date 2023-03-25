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
    internal class SymbolApplication : ISymbolApplication
    {
        private readonly ISymbolDomain _symbolDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<SymbolApplication> _logger;

        public SymbolApplication(ISymbolDomain symbolDomain, 
            IMapper mapper,
            IAppLogger<SymbolApplication> logger)
        {
            _symbolDomain = symbolDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<SymbolDTO> Get(int symbolId)
        {
            var response = new Response<SymbolDTO>();

            try
            {
                var symbol = _symbolDomain.Get(symbolId);
                response.Data = _mapper.Map<SymbolDTO>(symbol);

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

        public Response<IEnumerable<SymbolDTO>> GetAll()
        {
            var response = new Response<IEnumerable<SymbolDTO>>();

            try
            {
                var customers = _symbolDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<SymbolDTO>>(customers);

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

        public Response<bool> Insert(SymbolDTO symbolDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<Symbol>(symbolDTO);
                response.Data = _symbolDomain.Insert(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
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

        public Response<bool> Update(SymbolDTO symbolDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<Symbol>(symbolDTO);
                response.Data = _symbolDomain.Update(symbol);

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

        public Response<bool> Delete(int symbolId)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _symbolDomain.Get(symbolId);
                response.Data = _symbolDomain.Delete(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
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

        public async Task<Response<SymbolDTO>> GetAsync(int symbolId)
        {
            var response = new Response<SymbolDTO>();

            try
            {
                var symbol = await _symbolDomain.GetAsync(symbolId);
                response.Data = _mapper.Map<SymbolDTO>(symbol);

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

        public async Task<Response<IEnumerable<SymbolDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SymbolDTO>>();

            try
            {
                var symbols = await _symbolDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SymbolDTO>>(symbols);

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

        public async Task<Response<bool>> InsertAsync(SymbolDTO symbolDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<Symbol>(symbolDTO);
                response.Data = await _symbolDomain.InsertAsync(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
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

        public async Task<Response<bool>> UpdateAsync(SymbolDTO symbolDTO)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = _mapper.Map<Symbol>(symbolDTO);
                response.Data = await _symbolDomain.UpdateAsync(symbol);

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

        public async Task<Response<bool>> DeleteAsync(int symbolId)
        {
            var response = new Response<bool>();

            try
            {
                var symbol = await _symbolDomain.GetAsync(symbolId);
                response.Data = await _symbolDomain.DeleteAsync(symbol);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
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
