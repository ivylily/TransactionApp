﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionApp.DAL.Models;

namespace TransactionApp.DAL.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20190602225403_DatabaseCreation")]
    partial class DatabaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("CurrentAmount");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.Bank", b =>
                {
                    b.Property<long>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("BankId");

                    b.ToTable("Banks");
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

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TransactionApp.DAL.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<long>("MerchandAccountId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
