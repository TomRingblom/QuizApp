using Newtonsoft.Json;
using QuizApp.Blazor.Models.Quiz;
using static System.Net.WebRequestMethods;
using System.Text;
using QuizApp.Blazor.Models.ChatGpt;

namespace QuizApp.Blazor.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly HttpClient _httpClient;

        public ChatGptService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> QuizFromGptAsync(string query)
        {
            var apiKey = "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";
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var jsonContent = new
            {
                model = "text-davinci-003",
                prompt = $"can you give me a quiz of the subject {query} with 5 questions and 1 right option and two wrong options? And can you format the answer in a json string with a class quizQuestions with properties int id, string question, List<string> options and string correctAnswer? And don't give me anything as a answer but the json object.",
                max_tokens = 1000,
                temperature = 0.7
            };

            //var responseContent = await _httpClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json"));

            // Read the response as a string
            //var resContext = await responseContent.Content.ReadAsStringAsync();

            var test = "{\r\n  \"warning\": \"This model version is deprecated. Migrate before January 4, 2024 to avoid disruption of service. Learn more https://platform.openai.com/docs/deprecations\",\r\n  \"id\": \"cmpl-7pZcVSXFiArPFm8aKBmQ2UAS53Kig\",\r\n  \"object\": \"text_completion\",\r\n  \"created\": 1692526007,\r\n  \"model\": \"text-davinci-003\",\r\n  \"choices\": [\r\n    {\r\n      \"text\": \"\\n\\n{\\n    \\\"quizQuestions\\\": [\\n        {\\n            \\\"id\\\": 0,\\n            \\\"question\\\": \\\"What is the capital of Sweden?\\\",\\n            \\\"options\\\": [\\\"Copenhagen\\\", \\\"Oslo\\\", \\\"Stockholm\\\"],\\n            \\\"correctAnswer\\\": \\\"Stockholm\\\"\\n        },\\n        {\\n            \\\"id\\\": 1,\\n            \\\"question\\\": \\\"What is the currency of Sweden?\\\",\\n            \\\"options\\\": [\\\"Euro\\\", \\\"Krona\\\", \\\"Pound\\\"],\\n            \\\"correctAnswer\\\": \\\"Krona\\\"\\n        },\\n        {\\n            \\\"id\\\": 2,\\n            \\\"question\\\": \\\"What is the population of Stockholm?\\\",\\n            \\\"options\\\": [\\\"1 million\\\", \\\"2 million\\\", \\\"3 million\\\"],\\n            \\\"correctAnswer\\\": \\\"1 million\\\"\\n        },\\n        {\\n            \\\"id\\\": 3,\\n            \\\"question\\\": \\\"What is the main language spoken in Stockholm?\\\",\\n            \\\"options\\\": [\\\"English\\\", \\\"Swedish\\\", \\\"Norwegian\\\"],\\n            \\\"correctAnswer\\\": \\\"Swedish\\\"\\n        },\\n        {\\n            \\\"id\\\": 4,\\n            \\\"question\\\": \\\"What is the highest point in Stockholm?\\\",\\n            \\\"options\\\": [\\\"Viktoriaparken\\\", \\\"Kungsholmen\\\", \\\"Huddingebergen\\\"],\\n            \\\"correctAnswer\\\": \\\"Huddingebergen\\\"\\n        }\\n    ]\\n}\",\r\n      \"index\": 0,\r\n      \"logprobs\": null,\r\n      \"finish_reason\": \"stop\"\r\n    }\r\n  ],\r\n  \"usage\": {\r\n    \"prompt_tokens\": 70,\r\n    \"completion_tokens\": 302,\r\n    \"total_tokens\": 372\r\n  }\r\n}";
            // Deserialize the response into a dynamic object
            var data = JsonConvert.DeserializeObject<ChatGptResponse>(test);
            var quiz = JsonConvert.DeserializeObject<QuizList>(data.Choices[0].Text);

            //System.IO.File.WriteAllText($"{query}", resContext);

            return true;
        }

        public bool SaveQuizToJson()
        {
            throw new NotImplementedException();
        }
    }
}
