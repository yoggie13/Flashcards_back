using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REST.Migrations
{
    public partial class DateRegisterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "Users");

        }
    }
}
