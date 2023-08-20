using Newtonsoft.Json;

namespace QuizApp.Blazor.Models.ChatGpt
{
    public class ChatGptChoice
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("logprobs")]
        public object? Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string? FinishReason { get; set; }
    }
}
