﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionApp.DAL.Contexts;

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

            modelBuilder.Entity("TransactionApp.Domain.Models.Bank", b =>
                {
                    b.Property<long>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 6, 3, 5, 46, 18, 724, DateTimeKind.Utc).AddTicks(1640));

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasDefaultValue("A");

                    b.HasKey("BankId");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            BankId = 1L,
                            BankName = "Banco Liliputense",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 742, DateTimeKind.Utc).AddTicks(4873),
                            Status = "A"
                        },
                        new
                        {
                            BankId = 2L,
                            BankName = "Banco Jardin Oriental",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 744, DateTimeKind.Utc).AddTicks(3946),
                            Status = "A"
                        },
                        new
                        {
                            BankId = 3L,
                            BankName = "Banco Git",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 744, DateTimeKind.Utc).AddTicks(4062),
                            Status = "A"
                        });
                });

            modelBuilder.Entity("TransactionApp.Domain.Models.Client", b =>
                {
                    b.Property<long>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BankId");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 6, 3, 5, 46, 18, 745, DateTimeKind.Utc).AddTicks(8225));

                    b.Property<decimal>("CurrentAmount");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasDefaultValue("A");

                    b.HasKey("ClientId");

                    b.HasIndex("BankId");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            ClientId = 1L,
                            BankId = 1L,
                            ClientName = "Juan Fulano",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(281),
                            CurrentAmount = 400000m,
                            Status = "A"
                        },
                        new
                        {
                            ClientId = 2L,
                            BankId = 1L,
                            ClientName = "Maria Fulano",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2205),
                            CurrentAmount = 245009m,
                            Status = "A"
                        },
                        new
                        {
                            ClientId = 3L,
                            BankId = 2L,
                            ClientName = "Betty Mengano",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2218),
                            CurrentAmount = 100000m,
                            Status = "A"
                        },
                        new
                        {
                            ClientId = 4L,
                            BankId = 2L,
                            ClientName = "Pedro Vegano",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2222),
                            CurrentAmount = 300000m,
                            Status = "A"
                        },
                        new
                        {
                            ClientId = 5L,
                            BankId = 3L,
                            ClientName = "Alix Mengano",
                            CreatedOn = new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2222),
                            CurrentAmount = 25000m,
                            Status = "A"
                        });
                });

            modelBuilder.Entity("TransactionApp.Domain.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("ClientId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 6, 3, 5, 46, 18, 748, DateTimeKind.Utc).AddTicks(9714));

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<long>("MerchandClientId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasDefaultValue("A");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<byte>("TransactionType")
                        .HasMaxLength(1);

                    b.HasKey("TransactionId");

                    b.HasIndex("ClientId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("TransactionApp.Domain.Models.Client", b =>
                {
                    b.HasOne("TransactionApp.Domain.Models.Bank", "Bank")
                        .WithMany("Clients")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TransactionApp.Domain.Models.Transaction", b =>
                {
                    b.HasOne("TransactionApp.Domain.Models.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
