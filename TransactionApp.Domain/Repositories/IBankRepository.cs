using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionApp.Domain.Models;

namespace TransactionApp.Domain.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> ListAsync();
    }
}
