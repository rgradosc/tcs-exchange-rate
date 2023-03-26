using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Domain.Interfaces
{
    public interface IUserDomain
    {
        User Authenticate(string userName, string password);
    }
}
