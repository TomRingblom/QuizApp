using Newtonsoft.Json;

namespace QuizApp.Blazor.Models.Quiz
{
    public class QuizList
    {
        [JsonProperty("quizQuestions")]
        public List<QuizQuestion>? QuizQuestions { get; set; }
    }
}
