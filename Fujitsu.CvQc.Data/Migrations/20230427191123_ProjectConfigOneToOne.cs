using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class ProjectConfigOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectConfig_ConfigId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ConfigId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectConfig",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConfig_ProjectId",
                table: "ProjectConfig",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectConfig_Projects_ProjectId",
                table: "ProjectConfig",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectConfig_Projects_ProjectId",
                table: "ProjectConfig");

            migrationBuilder.DropIndex(
                name: "IX_ProjectConfig_ProjectId",
                table: "ProjectConfig");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectConfig");

            migrationBuilder.AddColumn<Guid>(
                name: "ConfigId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
