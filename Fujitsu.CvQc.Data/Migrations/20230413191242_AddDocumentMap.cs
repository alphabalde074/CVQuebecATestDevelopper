using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class AddDocumentMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentMapId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Match = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportationMode = table.Column<int>(type: "int", nullable: false),
                    DocumentMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_DocumentMaps_DocumentMapId",
                        column: x => x.DocumentMapId,
                        principalTable: "DocumentMaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentMapSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Sections_DocumentMapSectionId",
                        column: x => x.DocumentMapSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DocumentMapId",
                table: "Projects",
                column: "DocumentMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_DocumentMapSectionId",
                table: "Paragraphs",
                column: "DocumentMapSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DocumentMapId",
                table: "Sections",
                column: "DocumentMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_DocumentMaps_DocumentMapId",
                table: "Projects",
                column: "DocumentMapId",
                principalTable: "DocumentMaps",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_DocumentMaps_DocumentMapId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "DocumentMaps");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DocumentMapId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DocumentMapId",
                table: "Projects");
        }
    }
}
