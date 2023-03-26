using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
