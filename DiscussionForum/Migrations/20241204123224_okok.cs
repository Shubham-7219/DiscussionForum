using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionForum.Migrations
{
    /// <inheritdoc />
    public partial class okok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_Id",
                table: "Answers",
                column: "Question_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Question_Id",
                table: "Answers",
                column: "Question_Id",
                principalTable: "Questions",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Question_Id",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_Question_Id",
                table: "Answers");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
