using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class AddDocumentMapFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentFileName",
                table: "DocumentMaps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFileName",
                table: "DocumentMaps");
        }
    }
}
