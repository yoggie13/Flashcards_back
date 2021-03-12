using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REST.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "DecksOfCards",
                columns: table => new
                {
                    DeckOfCardsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID1 = table.Column<int>(type: "int", nullable: true),
                    SubjectID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecksOfCards", x => x.DeckOfCardsID);
                    table.ForeignKey(
                        name: "FK_DecksOfCards_Subjects_SubjectID1",
                        column: x => x.SubjectID1,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DecksOfCards_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckOfCardsID1 = table.Column<int>(type: "int", nullable: true),
                    TextFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextBack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_Cards_DecksOfCards_DeckOfCardsID1",
                        column: x => x.DeckOfCardsID1,
                        principalTable: "DecksOfCards",
                        principalColumn: "DeckOfCardsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID1 = table.Column<int>(type: "int", nullable: true),
                    DeckOfCardsID1 = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_DecksOfCards_DeckOfCardsID1",
                        column: x => x.DeckOfCardsID1,
                        principalTable: "DecksOfCards",
                        principalColumn: "DeckOfCardsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID1 = table.Column<int>(type: "int", nullable: true),
                    DeckOfCardsID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_Likes_DecksOfCards_DeckOfCardsID1",
                        column: x => x.DeckOfCardsID1,
                        principalTable: "DecksOfCards",
                        principalColumn: "DeckOfCardsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    SubCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID1 = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCommentedByIDUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.SubCommentID);
                    table.ForeignKey(
                        name: "FK_SubComments_Comments_CommentID1",
                        column: x => x.CommentID1,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubComments_Users_SubCommentedByIDUserID",
                        column: x => x.SubCommentedByIDUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckOfCardsID1",
                table: "Cards",
                column: "DeckOfCardsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DeckOfCardsID1",
                table: "Comments",
                column: "DeckOfCardsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID1",
                table: "Comments",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_DecksOfCards_SubjectID1",
                table: "DecksOfCards",
                column: "SubjectID1");

            migrationBuilder.CreateIndex(
                name: "IX_DecksOfCards_UserID1",
                table: "DecksOfCards",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_DeckOfCardsID1",
                table: "Likes",
                column: "DeckOfCardsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserID1",
                table: "Likes",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_CommentID1",
                table: "SubComments",
                column: "CommentID1");

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_SubCommentedByIDUserID",
                table: "SubComments",
                column: "SubCommentedByIDUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DecksOfCards");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
