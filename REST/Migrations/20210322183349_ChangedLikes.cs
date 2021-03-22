using Microsoft.EntityFrameworkCore.Migrations;

namespace REST.Migrations
{
    public partial class ChangedLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "LikedByUser",
                table: "DecksOfCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "DecksOfCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikedByUser",
                table: "DecksOfCards");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "DecksOfCards");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
