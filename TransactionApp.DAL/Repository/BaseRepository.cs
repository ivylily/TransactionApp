using TransactionApp.DAL.Contexts;

namespace TransactionApp.DAL.Repository
{
    public abstract class BaseRepository
    {
        protected readonly BankDbContext _context;

        public BaseRepository(BankDbContext context)
        {
            _context = context;
        }
    }
}
