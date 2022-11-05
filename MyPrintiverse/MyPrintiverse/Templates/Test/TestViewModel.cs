

using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.Core.Extensions;
using MyPrintiverse.Tools;

namespace MyPrintiverse.Templates.Test;

public partial class TestViewModel : BaseViewModel
{
    Color color;
    public Color Color { get => color; set => SetProperty(ref color, value); }

    public void test()
    {
        Console.WriteLine("Pressed");
    }

    IToast ToastService;

    public TestViewModel(IToast toast)
    {
        ToastService = toast;

        NewDescription = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(maxLength: 10), "Too long data.Too long data.Too long data.Too long data.Too long data.Too long data.Too long data.Too long data.Too long data.Too long data.");

        Step = 1;
        TotalSteps=4;
    }

    #region Headers

    private int counter = 0;

    [RelayCommand]
    public async Task Header()
    {
        counter += 1;
        await ToastService.Toast($"1. Clicked: {counter}.");
    }

    [RelayCommand]
    public async Task Header2()
    {
        counter += 1;
        await ToastService.Toast($"2. Clicked: {counter}.");
    }

    #endregion

    #region Form

    [ObservableProperty]
    byte _step;
    [ObservableProperty]
    string _stepDescription;
    [ObservableProperty]
    byte _TotalSteps;
    [ObservableProperty]
    bool _isRunningNext;

    [RelayCommand]
    public async Task Prev()
    {
        if (Step == 1)
            return;

        IsRunning = true;
        Step -= 1;
        StepDescription = $"This is test description with chanigin number: {Step}";
        await ToastService.Toast($"Prev clicked: {Step}.");
        await Task.Delay(500);

        IsRunning = false;
    }

    [RelayCommand]
    public async Task Next()
    {
        if (Step == 4)
            return;

        IsRunningNext = true;
        Step += 1;
        StepDescription = $"This is test description with chanigin number: {Step}";
        await ToastService.Toast($"Next clicked: {Step}.");
        await Task.Delay(500);
        IsRunningNext = false;
    }

    #endregion

    #region Inputs

    bool boolValue;
    public bool BoolValue { get => boolValue; set => SetProperty(ref boolValue, value); }

    public ExtendedValidatable<string> NewDescription { get; set; }



    #endregion

}
