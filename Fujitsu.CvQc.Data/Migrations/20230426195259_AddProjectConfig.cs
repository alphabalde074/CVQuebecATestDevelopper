using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class AddProjectConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConfigId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportMode = table.Column<int>(type: "int", nullable: false),
                    TemplatePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputSuffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectConfig", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ConfigId",
                table: "Projects",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectConfig_ConfigId",
                table: "Projects",
                column: "ConfigId",
                principalTable: "ProjectConfig",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectConfig_ConfigId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectConfig");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ConfigId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "Projects");
        }
    }
}
