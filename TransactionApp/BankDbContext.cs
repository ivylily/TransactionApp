using Microsoft.EntityFrameworkCore;
using System;

namespace TransactionApp.DAL.Models
{
    public class BankDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2HFT7NA;Initial Catalog=TransactionAppDB;Integrated Security=True");
        }
               
        DbSet<Bank> Banks { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
