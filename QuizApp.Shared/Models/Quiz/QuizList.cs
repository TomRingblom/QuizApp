using Newtonsoft.Json;

namespace QuizApp.Shared.Models.Quiz
{
    public class QuizList
    {
        [JsonProperty("quizQuestions")]
        public List<QuizQuestionDto>? QuizQuestions { get; set; }
    }
}
