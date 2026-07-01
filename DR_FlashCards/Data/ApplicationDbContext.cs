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
      
    }
      
}