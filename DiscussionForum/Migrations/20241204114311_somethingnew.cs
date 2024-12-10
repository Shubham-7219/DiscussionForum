using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionForum.Migrations
{
    /// <inheritdoc />
    public partial class somethingnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Question_Id1",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_Id1",
                table: "Answers",
                column: "Question_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Question_Id1",
                table: "Answers",
                column: "Question_Id1",
                principalTable: "Questions",
                principalColumn: "Question_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Question_Id1",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_Question_Id1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Question_Id1",
                table: "Answers");
        }
    }
}
