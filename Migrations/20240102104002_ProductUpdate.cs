using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaCroute.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLabel");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Product",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeId",
                table: "Product",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_TypeId",
                table: "Product",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_TypeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_TypeId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductLabel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LabelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLabel", x => x.ProductId);
                });
        }
    }
}
