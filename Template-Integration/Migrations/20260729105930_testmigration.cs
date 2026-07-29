using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_Integration.Migrations
{
    /// <inheritdoc />
    public partial class testmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "netprice",
                table: "AddProducts");

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "AddProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "AddProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "AddProducts");

            migrationBuilder.AlterColumn<int>(
                name: "OriginalPrice",
                table: "AddProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "netprice",
                table: "AddProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
