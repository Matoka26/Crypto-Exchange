using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_binance_api.Migrations
{
    /// <inheritdoc />
    public partial class user_with_history : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Histories_HistoryId",
                table: "Coins");

            migrationBuilder.DropIndex(
                name: "IX_Coins_HistoryId",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Coins");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coins_IdHistory",
                table: "Coins",
                column: "IdHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_Histories_IdHistory",
                table: "Coins",
                column: "IdHistory",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Histories_IdHistory",
                table: "Coins");

            migrationBuilder.DropIndex(
                name: "IX_Coins_IdHistory",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Coins");

            migrationBuilder.AddColumn<Guid>(
                name: "HistoryId",
                table: "Coins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coins_HistoryId",
                table: "Coins",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_Histories_HistoryId",
                table: "Coins",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id");
        }
    }
}
