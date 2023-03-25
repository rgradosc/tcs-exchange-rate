using System.Data;

namespace TCSExchangeRateAPI.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection Connection { get; }
    }
}
