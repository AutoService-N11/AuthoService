using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class h6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCategories_Companies_CompanyId",
                table: "CompanyCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "CompanyCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCategories_Companies_CompanyId",
                table: "CompanyCategories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCategories_Companies_CompanyId",
                table: "CompanyCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "CompanyCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCategories_Companies_CompanyId",
                table: "CompanyCategories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
