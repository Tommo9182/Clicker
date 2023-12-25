using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clicker.Migrations
{
    /// <inheritdoc />
    public partial class ExtendAspNetUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ApplicationUserId",
                table: "Scores",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ApplicationUserId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Scores");
        }
    }
}
