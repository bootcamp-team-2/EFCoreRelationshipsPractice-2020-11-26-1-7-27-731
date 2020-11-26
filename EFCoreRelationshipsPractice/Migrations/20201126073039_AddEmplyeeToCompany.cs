using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationshipsPractice.Migrations
{
    public partial class AddEmplyeeToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeEitity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    CompanyEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEitity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEitity_Companies_CompanyEntityId",
                        column: x => x.CompanyEntityId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegisteredCapital = table.Column<int>(nullable: false),
                    CertId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProfileId",
                table: "Companies",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEitity_CompanyEntityId",
                table: "EmployeeEitity",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileId",
                table: "Companies",
                column: "ProfileId",
                principalTable: "ProfileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "EmployeeEitity");

            migrationBuilder.DropTable(
                name: "ProfileEntity");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ProfileId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Companies");
        }
    }
}
