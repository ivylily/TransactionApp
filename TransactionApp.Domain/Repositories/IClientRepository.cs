using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionApp.Domain.Models;

namespace TransactionApp.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        void Update(Client category);
        Task<Client> FindByIdAsync(long accountId);
        Task<decimal> GetAccountBalanceAsync(long accountId);
    }
}
