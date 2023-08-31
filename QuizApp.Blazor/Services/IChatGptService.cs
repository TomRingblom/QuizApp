using QuizApp.Shared.Models.Quiz;

namespace QuizApp.Blazor.Services;

public interface IChatGptService
{
    public Task<IEnumerable<QuizQuestionDto>> QuizFromGptAsync(string query);
}
