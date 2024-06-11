using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_binance_api.Migrations
{
    /// <inheritdoc />
    public partial class testnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MarketCap",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketCap",
                table: "Coins");
        }
    }
}
