using AutoMapper;
using System;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Application.Interfaces;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;

        public UserApplication(IUserDomain userDomain, 
            IMapper mapper,
            IAppLogger<UserApplication> logger)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<UserDTO> Authenticate(AuthDTO userAuth)
        {
            var response = new Response<UserDTO>();
            
            try
            {
                var user = _userDomain.Authenticate(userAuth.Username, userAuth.Password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa";
                _logger.LogInformation(response.Message);
            }
            catch (InvalidOperationException iex)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                _logger.LogError(iex.Message);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }
    }
}
