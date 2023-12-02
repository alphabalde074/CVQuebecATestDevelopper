using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class RemoveImportationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Importation_ImportationId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Importation");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ImportationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ImportationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentFileName",
                table: "DocumentMaps");

            migrationBuilder.AddColumn<DateTime>(
                name: "Importation",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Importation",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "ImportationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentFileName",
                table: "DocumentMaps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Importation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Importation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ImportationId",
                table: "Documents",
                column: "ImportationId");

            migrationBuilder.CreateIndex(
                name: "IX_Importation_ProjectId",
                table: "Importation",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Importation_ImportationId",
                table: "Documents",
                column: "ImportationId",
                principalTable: "Importation",
                principalColumn: "Id");
        }
    }
}
