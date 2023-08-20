using Newtonsoft.Json;

namespace QuizApp.Blazor.Models.ChatGpt
{
    public class ChatGptResponse
    {
        [JsonProperty("warning")]
        public string? Warning { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("model")]
        public string? Model { get; set; }

        [JsonProperty("choices")]
        public List<ChatGptChoice>? Choices { get; set; }

        [JsonProperty("usage")]
        public ChatGptUsage? Usage { get; set; }
    }
}
