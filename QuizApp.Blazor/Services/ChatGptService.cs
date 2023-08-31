using Newtonsoft.Json;
using QuizApp.Shared.Models.Quiz;

namespace QuizApp.Blazor.Services;

public class ChatGptService : IChatGptService
{
    private readonly HttpClient _httpClient;

    public ChatGptService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<QuizQuestionDto>> QuizFromGptAsync(string query)
    {
        var dtos = new List<QuizQuestionDto>();
        var response = await _httpClient.GetAsync($"api/chatgpt?query={query}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<QuizQuestionDto>>(json);
            if(data != null)
            {
                dtos.AddRange(data);
            }
        }

        return dtos;
    }
}
