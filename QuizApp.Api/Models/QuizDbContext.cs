using Microsoft.EntityFrameworkCore;

namespace QuizApp.Api.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {}

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizGame> QuizGames { get; set; }
    }
}
