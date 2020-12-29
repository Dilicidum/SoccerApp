using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeTimeGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "Games");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Games");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeOfDay",
                table: "Games",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
