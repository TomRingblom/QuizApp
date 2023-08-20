using QuizApp.Blazor.Models.Quiz;

namespace QuizApp.Blazor.Services
{
    public interface IChatGptService
    {
        public QuizList QuizFromGpt();
        public bool SaveQuizToJson();
    }
}
