using Microsoft.AspNetCore.Components;

namespace QuizApp.Blazor.Shared;

public partial class ToggleButton
{
    [Parameter]
    public List<string>? Options { get; set; }

    [Parameter]
    public EventCallback<string> OnSubmit { get; set; }

    private Dictionary<int, string>? buttons;
    //private int chosen = 0;
    private string answer = "";
    private const string Btn = "quiz-button";
    private const string BtnChosen = $"{Btn} chosen";
    protected override void OnInitialized()
    {
        buttons = ResetButtons();
    }

    private async Task InvokeOnSubmit()
    {
        buttons = ResetButtons();
        await OnSubmit.InvokeAsync(answer);
    }

    private void Choice(int number, string option)
    {
        answer = option;
        foreach (var button in buttons!.Keys)
        {
            if (button == number)
            {
                buttons[button] = BtnChosen;
            }
            else
            {
                buttons[button] = Btn;
            }
        }

        //chosen = buttons!.Where(b => b.Value == BtnChosen).Select(k => k.Key).FirstOrDefault();
        StateHasChanged();
    }

    private Dictionary<int, string> ResetButtons()
    {
        return new Dictionary<int, string>
        {
            { 1, Btn },
            { 2, Btn },
            { 3, Btn }
        };
    }
}