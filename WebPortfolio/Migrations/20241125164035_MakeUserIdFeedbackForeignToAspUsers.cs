using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserIdFeedbackForeignToAspUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feedback");
        }
    }
}
