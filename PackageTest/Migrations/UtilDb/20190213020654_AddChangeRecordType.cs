using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTest.Migrations.UtilDb
{
    public partial class AddChangeRecordType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "ChangeRecords");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ChangeRecords",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "RecordType",
                table: "ChangeRecords",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordType",
                table: "ChangeRecords");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ChangeRecords",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceType",
                table: "ChangeRecords",
                nullable: true);
        }
    }
}
