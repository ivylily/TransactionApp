using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionApp.DAL.Contexts;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Repositories;

namespace TransactionApp.DAL.Repository
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(BankDbContext context) : base(context)
        {
        }
        
        public async Task<Client> FindByIdAsync(long accountId)
        {
            return await _context.Clients.FindAsync(accountId);
        }

        public async Task<decimal> GetAccountBalanceAsync(long accountId)
        {
            var account = await FindByIdAsync(accountId);
            return account.CurrentAmount;
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public void Update(Client category)
        {
            _context.Clients.Update(category);
        }
    }
}
