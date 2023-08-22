using Newtonsoft.Json;

namespace QuizApp.Shared.Models.Quiz
{
    public class QuizQuestionDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("question")]
        public string? Question { get; set; }

        [JsonProperty("options")]
        public List<string>? Options { get; set; }

        [JsonProperty("correctAnswer")]
        public string? CorrectAnswer { get; set; }
    }
}
