using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DR_FlashCards.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />  
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "id", "ExamModelId", "id_exam", "id_user", "name" },
                values: new object[] { 1, null, 1, 1, "Álgebra Básica" });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "id", "exam_date", "subject", "user_id" },
                values: new object[] { 1, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Matemáticas", 1 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "id", "answer", "mazo_id", "question" },
                values: new object[,]
                {
                    { 1, "4", 1, "¿Cuánto es 2+2?" },
                    { 2, "X = 5", 1, "Despeja X: X + 5 = 10" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "created_at", "email", "name", "password" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test@example.com", "Usuario de Prueba", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
