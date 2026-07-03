using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DR_FlashCards.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Exams",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exams",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ExamDate",
                table: "Exams",
                newName: "exam_date");

            migrationBuilder.AddColumn<int>(
                name: "ExamModelId",
                table: "Decks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeckModelFlashCardModel",
                columns: table => new
                {
                    DecksId = table.Column<int>(type: "integer", nullable: false),
                    FlashCardsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckModelFlashCardModel", x => new { x.DecksId, x.FlashCardsId });
                    table.ForeignKey(
                        name: "FK_DeckModelFlashCardModel_Decks_DecksId",
                        column: x => x.DecksId,
                        principalTable: "Decks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckModelFlashCardModel_Flashcards_FlashCardsId",
                        column: x => x.FlashCardsId,
                        principalTable: "Flashcards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Decks_ExamModelId",
                table: "Decks",
                column: "ExamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckModelFlashCardModel_FlashCardsId",
                table: "DeckModelFlashCardModel",
                column: "FlashCardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Exams_ExamModelId",
                table: "Decks",
                column: "ExamModelId",
                principalTable: "Exams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Exams_ExamModelId",
                table: "Decks");

            migrationBuilder.DropTable(
                name: "DeckModelFlashCardModel");

            migrationBuilder.DropIndex(
                name: "IX_Decks_ExamModelId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "ExamModelId",
                table: "Decks");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Exams",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Exams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Exams",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "exam_date",
                table: "Exams",
                newName: "ExamDate");
        }
    }
}
