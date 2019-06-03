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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BankSeed
            modelBuilder.Entity<Bank>().HasData(new Bank { BankId = 1, BankName = "Banco Liliputense", CreatedOn = DateTime.UtcNow, Status = "A" });
            #endregion

            #region ClientSeed
            modelBuilder.Entity<Client>().HasData(
                new Client() { ClientId = 1, ClientName = "Juan Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A" },
                new Client() { ClientId = 2, ClientName = "Maria Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A" });
            #endregion

            #region AccountSeed
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, ClientId = 1, CurrentAmount = 2923023, CreatedOn = DateTime.UtcNow, Status = "A" },
                new Account { AccountId = 2, ClientId = 2, CurrentAmount = 500000, CreatedOn = DateTime.UtcNow, Status = "A" },
                new Account { AccountId = 3, ClientId = 2, CurrentAmount = 2423023, CreatedOn = DateTime.UtcNow, Status = "A" });
            #endregion

            #region TransactionTypeSeed
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { TransactionTypeCode = "W", Description = "Withdrawal" },
                new TransactionType { TransactionTypeCode = "D", Description = "Deposit" },
                new TransactionType { TransactionTypeCode = "T", Description = "Transfer" });
            #endregion
        }

        DbSet<Bank> Banks { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
