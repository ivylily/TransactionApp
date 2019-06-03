using System.Threading.Tasks;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Services.Communication;

namespace TransactionApp.Domain.Services
{
    public interface ITransactionService
    {
        Task<SubmitTransactionResponse> SubmitTransactionAsync(Transaction transaction);
    }
}
