using System.Threading.Tasks;
using TransactionApp.DAL.Contexts;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Repositories;

namespace TransactionApp.DAL.Repository
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(BankDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }
    }
}
