using System.ComponentModel.DataAnnotations;

namespace QuizApp.Api.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Options { get; set; }
        public string? CorrectAnswer { get; set; }
        [Required]
        public int GameId { get; set; }
        public QuizGame Game { get; set; }
    }
}
