using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionApp.DAL.Migrations
{
    public partial class DatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "ClientId", "CreatedOn", "CurrentAmount", "Status" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(2966), 2923023m, "A" },
                    { 2L, 2L, new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4142), 500000m, "A" },
                    { 3L, 2L, new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4150), 2423023m, "A" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName", "CreatedOn", "Status" },
                values: new object[] { 1L, "Banco Liliputense", new DateTime(2019, 6, 3, 0, 9, 21, 903, DateTimeKind.Utc).AddTicks(8849), "A" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "BankId", "ClientName", "CreatedOn", "Status" },
                values: new object[,]
                {
                    { 1L, 1L, "Juan Fulano", new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(7825), "A" },
                    { 2L, 1L, "Maria Fulano", new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(9562), "A" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeCode", "Description" },
                values: new object[,]
                {
                    { "W", "Withdrawal" },
                    { "D", "Deposit" },
                    { "T", "Transfer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeCode",
                keyValue: "D");

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeCode",
                keyValue: "T");

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeCode",
                keyValue: "W");
        }
    }
}
