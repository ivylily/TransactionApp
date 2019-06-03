using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using System;
using TransactionApp.Domain.Models;

namespace TransactionApp.DAL.Contexts
{
    public class BankDbContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().ToTable("Bank");
            modelBuilder.Entity<Bank>().HasKey(p => p.BankId);
            modelBuilder.Entity<Bank>().Property(p => p.BankId).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<long>>();
            modelBuilder.Entity<Bank>().Property(p => p.BankName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Bank>().Property(p => p.Status).IsRequired().HasMaxLength(1).HasDefaultValue("A");
            modelBuilder.Entity<Bank>().Property(p => p.CreatedOn).IsRequired().HasDefaultValue<DateTime>(DateTime.UtcNow);
            modelBuilder.Entity<Bank>().HasMany(p => p.Clients).WithOne(p => p.Bank).HasForeignKey(p => p.BankId);

            #region BankSeed
            modelBuilder.Entity<Bank>().HasData(new Bank { BankId = 1, BankName = "Banco Liliputense", CreatedOn = DateTime.UtcNow, Status = "A" });
            modelBuilder.Entity<Bank>().HasData(new Bank { BankId = 2, BankName = "Banco Jardin Oriental", CreatedOn = DateTime.UtcNow, Status = "A" });
            modelBuilder.Entity<Bank>().HasData(new Bank { BankId = 3, BankName = "Banco Git", CreatedOn = DateTime.UtcNow, Status = "A" });
            #endregion

            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Client>().HasKey(p => p.ClientId);
            modelBuilder.Entity<Client>().Property(p => p.ClientId).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<long>>();
            modelBuilder.Entity<Client>().Property(p => p.ClientName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Client>().Property(p => p.Status).IsRequired().HasMaxLength(1).HasDefaultValue("A");
            modelBuilder.Entity<Client>().Property(p => p.CurrentAmount).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.CreatedOn).IsRequired().HasDefaultValue<DateTime>(DateTime.UtcNow);
            modelBuilder.Entity<Client>().HasMany(p => p.Transactions).WithOne(p => p.Client).HasForeignKey(p => p.ClientId);

            #region ClientSeed
            modelBuilder.Entity<Client>().HasData(
                new Client() { ClientId = 1, ClientName = "Juan Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 400000 },
                new Client() { ClientId = 2, ClientName = "Maria Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 245009 },
                new Client() { ClientId = 3, ClientName = "Betty Mengano", BankId = 2, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 100000 },
                new Client() { ClientId = 4, ClientName = "Pedro Vegano", BankId = 2, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 300000 },
                new Client() { ClientId = 5, ClientName = "Alix Mengano", BankId = 3, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 25000 });
            #endregion

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>().HasKey(p => p.TransactionId);
            modelBuilder.Entity<Transaction>().Property(p => p.TransactionId).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<long>>();
            modelBuilder.Entity<Transaction>().Property(p => p.Amount).IsRequired();          
            modelBuilder.Entity<Transaction>().Property(p => p.TransactionType).IsRequired().HasMaxLength(1);
            modelBuilder.Entity<Transaction>().Property(p => p.TransactionDate).IsRequired();
            modelBuilder.Entity<Transaction>().Property(p => p.Status).IsRequired().HasMaxLength(1).HasDefaultValue("A");
            modelBuilder.Entity<Transaction>().Property(p => p.CreatedOn).IsRequired().HasDefaultValue<DateTime>(DateTime.UtcNow);
            modelBuilder.Entity<Transaction>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Transaction>().Property(p => p.MerchandClientId);
        }
    }
}
