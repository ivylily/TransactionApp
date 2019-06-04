using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionApp.DAL.Migrations
{
    public partial class NewModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankName = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false, defaultValue: "A"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 3, 5, 46, 18, 724, DateTimeKind.Utc).AddTicks(1640))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false, defaultValue: "A"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 3, 5, 46, 18, 745, DateTimeKind.Utc).AddTicks(8225)),
                    CurrentAmount = table.Column<decimal>(nullable: false),
                    BankId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MerchandClientId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false, defaultValue: "A"),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 3, 5, 46, 18, 748, DateTimeKind.Utc).AddTicks(9714)),
                    TransactionType = table.Column<byte>(maxLength: 1, nullable: false),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "BankId", "BankName", "CreatedOn", "Status" },
                values: new object[] { 1L, "Banco Liliputense", new DateTime(2019, 6, 3, 5, 46, 18, 742, DateTimeKind.Utc).AddTicks(4873), "A" });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "BankId", "BankName", "CreatedOn", "Status" },
                values: new object[] { 2L, "Banco Jardin Oriental", new DateTime(2019, 6, 3, 5, 46, 18, 744, DateTimeKind.Utc).AddTicks(3946), "A" });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "BankId", "BankName", "CreatedOn", "Status" },
                values: new object[] { 3L, "Banco Git", new DateTime(2019, 6, 3, 5, 46, 18, 744, DateTimeKind.Utc).AddTicks(4062), "A" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "BankId", "ClientName", "CreatedOn", "CurrentAmount", "Status" },
                values: new object[,]
                {
                    { 1L, 1L, "Juan Fulano", new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(281), 400000m, "A" },
                    { 2L, 1L, "Maria Fulano", new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2205), 245009m, "A" },
                    { 3L, 2L, "Betty Mengano", new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2218), 100000m, "A" },
                    { 4L, 2L, "Pedro Vegano", new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2222), 300000m, "A" },
                    { 5L, 3L, "Alix Mengano", new DateTime(2019, 6, 3, 5, 46, 18, 747, DateTimeKind.Utc).AddTicks(2222), 25000m, "A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_BankId",
                table: "Client",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ClientId",
                table: "Transaction",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
