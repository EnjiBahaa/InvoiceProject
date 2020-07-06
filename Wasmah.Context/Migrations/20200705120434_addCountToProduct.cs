using Microsoft.EntityFrameworkCore.Migrations;

namespace Wasmah.Context.Migrations
{
    public partial class addCountToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
