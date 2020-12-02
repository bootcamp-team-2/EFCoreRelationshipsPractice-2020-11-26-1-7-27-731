using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationshipsPractice.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEntity_Companies_CompanyEntityId",
                table: "EmployeeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileEntity",
                table: "ProfileEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEntity",
                table: "EmployeeEntity");

            migrationBuilder.RenameTable(
                name: "ProfileEntity",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "EmployeeEntity",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEntity_CompanyEntityId",
                table: "Employees",
                newName: "IX_Employees_CompanyEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCapital",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Profiles_ProfileId",
                table: "Companies",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Companies_Profiles_ProfileId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyEntityId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "ProfileEntity");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmployeeEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyEntityId",
                table: "EmployeeEntity",
                newName: "IX_EmployeeEntity_CompanyEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCapital",
                table: "ProfileEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "EmployeeEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileEntity",
                table: "ProfileEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEntity",
                table: "EmployeeEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileId",
                table: "Companies",
                column: "ProfileId",
                principalTable: "ProfileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEntity_Companies_CompanyEntityId",
                table: "EmployeeEntity",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
