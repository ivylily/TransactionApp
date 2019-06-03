using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionApp.DAL.Contexts;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Repositories;

namespace TransactionApp.DAL.Repository
{
    public class BankRepository : BaseRepository, IBankRepository
    {
        public BankRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bank>> ListAsync()
        {
            return await _context.Banks.Include(p => p.Clients).ToListAsync();
        }
    }
}
