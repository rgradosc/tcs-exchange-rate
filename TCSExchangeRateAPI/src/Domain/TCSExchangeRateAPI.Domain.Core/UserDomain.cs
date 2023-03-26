using TCSExchangeRateAPI.Domain.Entity;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Infrastructure.Interfaces;

namespace TCSExchangeRateAPI.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            return _userRepository.Authenticate(userName, password);
        }
    }
}
