using System.Threading.Tasks;
using System.Transactions;

namespace TransactionApp.Domain.Services
{
    public interface ITransactionService
    {
        Task<decimal> SubmitTransactionAsync(Transaction transaction);
    }
}
