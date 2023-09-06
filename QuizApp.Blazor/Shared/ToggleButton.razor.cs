using Microsoft.AspNetCore.Components;

namespace QuizApp.Blazor.Shared;

public partial class ToggleButton
{
    [Parameter]
    public List<string>? Options { get; set; }

    [Parameter]
    public bool IsValidated { get; set; }

    [Parameter]
    public string? Correct { get; set; }

    [Parameter]
    public EventCallback<string> OnSubmit { get; set; }

    private Dictionary<int, string>? buttons;
    private Dictionary<string, object>? attributes;
    private string answer = "";
    private const string Btn = "quiz-button";
    private const string BtnChosen = $"{Btn} chosen";

    protected override void OnInitialized()
    {
        buttons = ResetButtons();
        attributes = SetAttributes(true);
    }

    private async Task InvokeOnSubmit()
    {
        if (IsValidated)
        {
            buttons = ResetButtons();
            IsValidated = false;
        }
        else
        {
            
        }

        await OnSubmit.InvokeAsync(answer);
    }

    private void Choice(int number, string option)
    {
        answer = option;
        attributes = SetAttributes(false);

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

        StateHasChanged();
    }

    private Dictionary<int, string> ResetButtons()
    {
        return new ()
        {
            { 1, Btn },
            { 2, Btn },
            { 3, Btn }
        };
    }
    private Dictionary<string, object> SetAttributes(bool input)
    {
        return new ()
        {
            { "class", "quiz-submit" },
            { "disabled", input }
        };
    }
}