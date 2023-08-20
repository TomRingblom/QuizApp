using System.ComponentModel.DataAnnotations;

namespace QuizApp.Api.Models
{
    public class QuizGame
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
