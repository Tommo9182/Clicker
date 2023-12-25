using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clicker.Migrations
{
    /// <inheritdoc />
    public partial class ExtendAspNetUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Scores",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Scores",
                newName: "username");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_ApplicationUserId",
                table: "Scores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
