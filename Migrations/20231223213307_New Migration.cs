using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clicker.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_userId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_userId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_userId",
                table: "Scores",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_userId",
                table: "Scores",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
