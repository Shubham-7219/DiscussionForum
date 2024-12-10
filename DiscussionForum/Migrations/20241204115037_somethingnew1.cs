using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionForum.Migrations
{
    /// <inheritdoc />
    public partial class somethingnew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_User_Id",
                table: "Answers",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_User_Id",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_User_Id",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
