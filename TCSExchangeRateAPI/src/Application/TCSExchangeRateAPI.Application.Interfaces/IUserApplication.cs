using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Transversal.Common;

namespace TCSExchangeRateAPI.Application.Interfaces
{
    public interface IUserApplication
    {
        Response<UserDTO> Authenticate(AuthDTO userAuth);
    }
}
