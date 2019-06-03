﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionApp.DAL.Models;

namespace TransactionApp.DAL.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionApp.DAL.Models.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClientId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal>("CurrentAmount");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1L,
                            ClientId = 1L,
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(2966),
                            CurrentAmount = 2923023m,
                            Status = "A"
                        },
                        new
                        {
                            AccountId = 2L,
                            ClientId = 2L,
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4142),
                            CurrentAmount = 500000m,
                            Status = "A"
                        },
                        new
                        {
                            AccountId = 3L,
                            ClientId = 2L,
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4150),
                            CurrentAmount = 2423023m,
                            Status = "A"
                        });
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.Bank", b =>
                {
                    b.Property<long>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("BankId");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            BankId = 1L,
                            BankName = "Banco Liliputense",
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 903, DateTimeKind.Utc).AddTicks(8849),
                            Status = "A"
                        });
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.Client", b =>
                {
                    b.Property<long>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BankId");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1L,
                            BankId = 1L,
                            ClientName = "Juan Fulano",
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(7825),
                            Status = "A"
                        },
                        new
                        {
                            ClientId = 2L,
                            BankId = 1L,
                            ClientName = "Maria Fulano",
                            CreatedOn = new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(9562),
                            Status = "A"
                        });
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<long>("MerchandAccountId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.TransactionType", b =>
                {
                    b.Property<string>("TransactionTypeCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("TransactionTypeCode");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeCode = "W",
                            Description = "Withdrawal"
                        },
                        new
                        {
                            TransactionTypeCode = "D",
                            Description = "Deposit"
                        },
                        new
                        {
                            TransactionTypeCode = "T",
                            Description = "Transfer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
