using Microsoft.EntityFrameworkCore.Migrations;

namespace Wasmah.Context.Migrations
{
    public partial class ModifyInvoiceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_InvoiceId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceId",
                table: "Product",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
