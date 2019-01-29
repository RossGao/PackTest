using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTest.Migrations
{
    public partial class UpdateVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Versions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Versions");
        }
    }
}
