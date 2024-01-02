using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaCroute.Migrations
{
    /// <inheritdoc />
    public partial class ReviewsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_at",
                table: "Review",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "Review",
                newName: "created_at");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Review",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Review",
                newName: "update_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Review",
                newName: "create_at");
        }
    }
}
