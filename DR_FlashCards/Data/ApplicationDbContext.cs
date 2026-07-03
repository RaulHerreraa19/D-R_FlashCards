using Microsoft.EntityFrameworkCore;
using DR_FlashCards.Models;


namespace DR_FlashCards.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // 1. Definición de las tablas en PostgreSQL (en inglés)
    public DbSet<UsersModel> Users { get; set; }
    public DbSet<ExamModel> Exams { get; set; }
    public DbSet<DeckModel> Decks { get; set; }
    public DbSet<FlashCardModel> Flashcards { get; set; }

    // 2. Configuración mediante Fluent API optimizada para PostgreSQL
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
      
        // Seeders para probar el proyecto
        modelBuilder.Entity<UsersModel>().HasData(
            new UsersModel { Id = 1, Name = "Usuario de Prueba", Email = "test@example.com", Password = "123", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        modelBuilder.Entity<ExamModel>().HasData(
            new ExamModel { Id = 1, Subject = "Matemáticas", ExamDate = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc), UserId = 1 }
        );

        modelBuilder.Entity<DeckModel>().HasData(
            new DeckModel { Id = 1, Name = "Álgebra Básica", IdExam = 1, IdUser = 1 }
        );

        modelBuilder.Entity<FlashCardModel>().HasData(
            new FlashCardModel { Id = 1, Question = "¿Cuánto es 2+2?", Answer = "4", MazoId = 1 },
            new FlashCardModel { Id = 2, Question = "Despeja X: X + 5 = 10", Answer = "X = 5", MazoId = 1 }
        );
    }
}