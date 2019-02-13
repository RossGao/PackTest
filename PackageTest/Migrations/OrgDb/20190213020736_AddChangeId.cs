using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTest.Migrations.OrgDb
{
    public partial class AddChangeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveChangeId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveChangeId",
                table: "Departments");
        }
    }
}
