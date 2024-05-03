using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class finaly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "CarSeats",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "AutoServices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "CarSeats");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AutoServices");
        }
    }
}
