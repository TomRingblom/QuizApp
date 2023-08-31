using Microsoft.AspNetCore.Components;
using QuizApp.Blazor.Services;
using QuizApp.Shared.Models.Quiz;

namespace QuizApp.Blazor.Pages
{
    public partial class Quiz
    {
        [Inject]
        public IChatGptService? _chatGptService { get; set; }

        private IEnumerable<QuizQuestionDto> questions;
        private int questionId = 1;
        private bool runGame = true;
        private bool loading = false;
        private string inputValue = "";
        private List<QuizResult> answers = new();
        private async void GetQuiz(string input)
        {
            loading = true;
            questions = await _chatGptService.QuizFromGptAsync(input);
            runGame = true;
            loading = false;
            StateHasChanged();
        }

        private void SubmitHandler(string guess)
        {
            var question = questions.Where(x => x.Id == questionId).FirstOrDefault();
            questionId++;
            answers.Add(new QuizResult { Answer = guess, Question = question });
            if (answers.Count == questions.Count())
            {
                runGame = false;
            }
        }

        private void PlayAgain()
        {
            questionId = 1;
            runGame = true;
            answers = new();
        }
    }
}