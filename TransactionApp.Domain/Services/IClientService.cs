using System.Threading.Tasks;

namespace TransactionApp.Domain.Services
{
    public interface IClientService 
    {
        Task<decimal> GetBalanceAsync(long clientId);
    }
}
