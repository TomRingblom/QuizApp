using Newtonsoft.Json;

namespace QuizApp.Blazor.Models.Quiz
{
    public class QuizQuestion
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
