using Microsoft.EntityFrameworkCore;

namespace QuizApp.Api.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {}

        public DbSet<QuizGame> Games { get; set; }
        public DbSet<QuizQuestion> Questions { get; set; }
        public DbSet<QuizQuestionOption> Options { get; set; }
    }
}
