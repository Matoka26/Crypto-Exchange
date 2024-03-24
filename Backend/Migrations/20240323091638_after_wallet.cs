using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_binance_api.Migrations
{
    /// <inheritdoc />
    public partial class after_wallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstCreated",
                table: "Histories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Histories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstCreated",
                table: "Coins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Coins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdWallet",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinDTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinDTO_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinDTO_WalletId",
                table: "CoinDTO",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_IdUser",
                table: "Wallet",
                column: "IdUser",
                unique: true,
                filter: "[IdUser] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinDTO");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropColumn(
                name: "FirstCreated",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "FirstCreated",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "IdWallet",
                table: "AspNetUsers");
        }
    }
}
