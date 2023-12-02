using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class ChangeProjectDocumentStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_DocumentMaps_DocumentMapId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DocumentMapId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DocumentMapId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "Importation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DocumentMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentMaps_DocumentMapId",
                        column: x => x.DocumentMapId,
                        principalTable: "DocumentMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Importation_ImportationId",
                        column: x => x.ImportationId,
                        principalTable: "Importation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentMapId",
                table: "Documents",
                column: "DocumentMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ImportationId",
                table: "Documents",
                column: "ImportationId");

            migrationBuilder.CreateIndex(
                name: "IX_Importation_ProjectId",
                table: "Importation",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Importation");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentMapId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DocumentMapId",
                table: "Projects",
                column: "DocumentMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_DocumentMaps_DocumentMapId",
                table: "Projects",
                column: "DocumentMapId",
                principalTable: "DocumentMaps",
                principalColumn: "Id");
        }
    }
}
