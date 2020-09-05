using Microsoft.EntityFrameworkCore.Migrations;

namespace AES.ShopCart.API.Migrations
{
    public partial class Voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ShopCartClient_DiscountValue",
                table: "ShopCartClients",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "VoucherUsed",
                table: "ShopCartClients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "ShopCartClients",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "ShopCartClients",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "ShopCartClients",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percent",
                table: "ShopCartClients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopCartClient_DiscountValue",
                table: "ShopCartClients");

            migrationBuilder.DropColumn(
                name: "VoucherUsed",
                table: "ShopCartClients");

            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "ShopCartClients");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "ShopCartClients");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "ShopCartClients");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "ShopCartClients");
        }
    }
}
