using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Api.Models
{
    public class QuizQuestionOption
    {
        [Key]
        public int Id { get; set; }
        public string? Option { get; set; }

        [Required]
        public int QuestionId { get; set; }
        public QuizQuestion Question { get; set; }
    }
}
