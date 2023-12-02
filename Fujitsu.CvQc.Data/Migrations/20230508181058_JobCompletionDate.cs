using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    public partial class JobCompletionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Jobs");
        }
    }
}
