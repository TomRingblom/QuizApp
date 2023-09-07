using Microsoft.AspNetCore.Components;
using QuizApp.Blazor.Services;
using QuizApp.Shared.Models.Quiz;

namespace QuizApp.Blazor.Pages
{
    public partial class Quiz
    {
        [Inject]
        public IChatGptService? ChatGptService { get; set; }

        private IEnumerable<QuizQuestionDto>? questions;
        private int questionId = 1;
        private int progress = 0;
        private bool runGame = true;
        private bool isValidated = false;
        private bool loading = false;
        private string inputValue = "";
        private List<QuizResult> answers = new();

        private async void GetQuiz(string input)
        {
            loading = true;
            questions = await ChatGptService!.QuizFromGptAsync(input);
            runGame = true;
            loading = false;
            progress = CalculateProgress(questionId, questions.Count());
            StateHasChanged();
        }

        private void SubmitHandler(string guess)
        {
            if(questions != null)
            {
                var question = questions
                    .Where(x => x.Id == questionId)
                    .FirstOrDefault();

                if(isValidated)
                {
                    questionId++;
                    answers.Add(new QuizResult { Answer = guess, Question = question });
                    progress = CalculateProgress(questionId, questions.Count());
                    isValidated = false;
                }
                else
                {
                    isValidated = true;
                }

                if (answers.Count == questions.Count())
                {
                    runGame = false;
                }
            }
        }

        private int CalculateProgress(int complete, int total)
        {
            return (int)Math.Round((double)(100 * complete) / total);
        }
    }
}