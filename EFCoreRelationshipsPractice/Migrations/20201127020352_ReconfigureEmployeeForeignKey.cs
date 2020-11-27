using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationshipsPractice.Migrations
{
    public partial class ReconfigureEmployeeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyRefId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyRefId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyRefId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyEntityId",
                table: "Employees",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyEntityId",
                table: "Employees",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyEntityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyEntityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyRefId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyRefId",
                table: "Employees",
                column: "CompanyRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyRefId",
                table: "Employees",
                column: "CompanyRefId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
