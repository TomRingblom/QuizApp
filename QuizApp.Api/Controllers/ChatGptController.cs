using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuizApp.Api.Configuration.Options;
using QuizApp.Api.Models;
using QuizApp.Shared.Models.ChatGpt;
using QuizApp.Shared.Models.Quiz;
using System.Text;

namespace QuizApp.Api.Controllers
{
    public class ChatGptController : BaseApiController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly QuizDbContext _dbContext;
        private readonly string _apiKey;

        public ChatGptController(IHttpClientFactory httpClientFactory, IOptions<ChatGptOptions> options, QuizDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = options.Value.ApiKey;
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetQuiz))]
        public async Task<ActionResult<QuizList>> GetQuiz(string query)
        {
            var gameExist = await _dbContext.QuizGames.Where(x => x.Name == query).CountAsync();

            if (gameExist > 0)
            {
                var game = await _dbContext.QuizGames.Where(x => x.Name == query).FirstOrDefaultAsync();
                var questions = await _dbContext.QuizQuestions.Where(x => x.GameId == game!.Id).ToListAsync();

                var questionList = new List<QuizQuestionDto>();
                var index = 1;
                foreach(var question in questions)
                {
                    questionList.Add(new QuizQuestionDto
                    {
                        Id = index,
                        Question = question.Question,
                        Options = question.Options.Split(",").ToList(),
                        CorrectAnswer = question.CorrectAnswer
                    });
                    index++;
                }

                return Ok(questionList);
            }

            var client = _httpClientFactory.CreateClient("ChatGptClient");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var jsonContent = new
            {
                model = "text-davinci-003",
                prompt = $"can you give me a quiz of the subject {query} with 5 questions and 1 right option and two wrong options? And can you format the answer in a json string with a class quizQuestions with properties int id, string question, List<string> options and string correctAnswer? And don't give me anything as a answer but the json object.",
                max_tokens = 1000,
                temperature = 0.7
            };

            var responseContent = await client.PostAsync(client.BaseAddress, new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json"));

            var resContext = await responseContent.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ChatGptResponse>(resContext);
            var quiz = JsonConvert.DeserializeObject<QuizList>(data.Choices[0].Text);


            if(gameExist < 1 && quiz != null && quiz.QuizQuestions != null)
            {
                await _dbContext.QuizGames.AddAsync(new QuizGame
                {
                    Name = query
                });

                await _dbContext.SaveChangesAsync();

                var game = await _dbContext.QuizGames
                    .Where(x => x.Name == query)
                    .FirstOrDefaultAsync();

                foreach (var item in quiz.QuizQuestions)
                {
                    await _dbContext.QuizQuestions.AddAsync(new QuizQuestion
                    {
                        Question = item.Question,
                        Options = string.Join(",", item.Options),
                        GameId = game.Id,
                        CorrectAnswer = item.CorrectAnswer
                    });
                }

                await _dbContext.SaveChangesAsync();
            }

            return Ok(quiz.QuizQuestions);
        }
    }
}
