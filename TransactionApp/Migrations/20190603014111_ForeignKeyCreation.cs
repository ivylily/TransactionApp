using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionApp.DAL.Migrations
{
    public partial class ForeignKeyCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "TransactionTypeCode");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionTypeCode",
                table: "TransactionTypes",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 646, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 646, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 646, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 643, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 645, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 1, 41, 8, 646, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeCode",
                table: "Transactions",
                column: "TransactionTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BankId",
                table: "Clients",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Banks_BankId",
                table: "Clients",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeCode",
                table: "Transactions",
                column: "TransactionTypeCode",
                principalTable: "TransactionTypes",
                principalColumn: "TransactionTypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Banks_BankId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeCode",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeCode",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BankId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeCode",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionTypeCode",
                table: "TransactionTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 908, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 903, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2019, 6, 3, 0, 9, 21, 907, DateTimeKind.Utc).AddTicks(9562));
        }
    }
}
