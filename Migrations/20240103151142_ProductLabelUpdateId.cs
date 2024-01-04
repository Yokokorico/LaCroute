using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaCroute.Migrations
{
    /// <inheritdoc />
    public partial class ProductLabelUpdateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLabel",
                table: "ProductLabel");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductLabel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLabel",
                table: "ProductLabel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabel_ProductId",
                table: "ProductLabel",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLabel",
                table: "ProductLabel");

            migrationBuilder.DropIndex(
                name: "IX_ProductLabel_ProductId",
                table: "ProductLabel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductLabel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLabel",
                table: "ProductLabel",
                columns: new[] { "ProductId", "LabelId" });
        }
    }
}
