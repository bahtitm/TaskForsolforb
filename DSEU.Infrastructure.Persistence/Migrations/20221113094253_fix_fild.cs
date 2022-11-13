using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Infrastructure.Persistence.Migrations
{
    public partial class fix_fild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Order",
                newName: "ProvideId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProvideId",
                table: "Order",
                column: "ProvideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Provide_ProvideId",
                table: "Order",
                column: "ProvideId",
                principalTable: "Provide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Provide_ProvideId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProvideId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ProvideId",
                table: "Order",
                newName: "ProviderId");
        }
    }
}
