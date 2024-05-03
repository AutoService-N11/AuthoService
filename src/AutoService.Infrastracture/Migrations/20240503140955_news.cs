using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class news : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Companies_CompanyID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Services",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CompanyID",
                table: "Services",
                newName: "IX_Services_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Services",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CompanyId",
                table: "Services",
                newName: "IX_Services_CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Companies_CompanyID",
                table: "Services",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
