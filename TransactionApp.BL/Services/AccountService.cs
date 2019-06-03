using System.Threading.Tasks;
using TransactionApp.Domain.Repositories;
using TransactionApp.Domain.Services;

namespace TransactionApp.BL.Services
{
    public class AccountService : IClientService
    {
        private readonly IClientRepository _accountRepository;

        public AccountService(IClientRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<decimal> GetBalanceAsync(long accountId)
        {
            return await _accountRepository.GetAccountBalanceAsync(accountId);
        }
    }
}
