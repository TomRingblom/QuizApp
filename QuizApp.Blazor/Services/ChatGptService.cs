using Newtonsoft.Json;
using QuizApp.Shared.Models.Quiz;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace QuizApp.Blazor.Services
{
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
            //var get = await _httpClient.GetStreamAsync($"api/chatgpt?query={query}");
            //var json = await JsonSerializer.DeserializeAsync<List<QuizQuestionDto>>(get);
            return dtos;
        }

        public bool SaveQuizToJson()
        {
            throw new NotImplementedException();
        }
    }
}
