using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTest.Migrations
{
    public partial class init_CreateVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    VersionNumber = table.Column<string>(nullable: false),
                    VersionTitle = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ReleaseNote = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskTitle = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Iteration = table.Column<string>(nullable: false),
                    CommitIds = table.Column<string>(nullable: false),
                    DetailNote = table.Column<string>(nullable: true),
                    Applicant = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    VersionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_VersionId",
                table: "Details",
                column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Versions");
        }
    }
}
