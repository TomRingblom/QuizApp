using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTableForDbToFollow1NF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_QuizGames_GameId",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizGames",
                table: "QuizGames");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "QuizGames",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_GameId",
                table: "Questions",
                newName: "IX_Questions_GameId");

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_OptionId",
                table: "Questions",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Games_GameId",
                table: "Questions",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_OptionId",
                table: "Questions",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Games_GameId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_OptionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_OptionId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "QuizGames");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_GameId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_GameId");

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "QuizQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizGames",
                table: "QuizGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_QuizGames_GameId",
                table: "QuizQuestions",
                column: "GameId",
                principalTable: "QuizGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
