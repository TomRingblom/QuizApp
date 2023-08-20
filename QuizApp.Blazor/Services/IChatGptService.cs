using QuizApp.Blazor.Models.Quiz;

namespace QuizApp.Blazor.Services
{
    public interface IChatGptService
    {
        public Task<bool> QuizFromGptAsync(string query);
        public bool SaveQuizToJson();
    }
}
