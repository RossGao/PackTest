using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTest.Migrations
{
    public partial class UpdateDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Details",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Details",
                newName: "IsDelete");
        }
    }
}
