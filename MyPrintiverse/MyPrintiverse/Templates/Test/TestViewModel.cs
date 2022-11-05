

using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.Tools;

namespace MyPrintiverse.Templates.Test;

public partial class TestViewModel : BaseViewModel
{
    bool boolValue;
    public bool BoolValue { get => boolValue; set => SetProperty(ref boolValue, value); }

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

        Email = Validator.Build<string>()
            .WithRule(new EmailRule(), "Email is not valid");

        Password = Validator.Build<string>()
            .WithRule(new ContainLowerRule(), "Password should contains at least one lower case letter.")
            .WithRule(new ContainUpperRule(), "Password should contains at least one upper case letter.")
            .WithRule(new ContainDigitsRule(), "Password should contains at least one digit.")
            .WithRule(new RangeRule<string>(8, 20), "Password should be between 8-20 characters.");

        Numbers = Validator.Build<double>();
        Numbers = Validator.Build<double>();

        EmailValidateCommand = new Command(EmailValidate);
        PasswordValidateCommand = new Command(PasswordValidate);
        TestCommand = new Command(Test);
        AdditioalCommand = new Command(Additioal);
        LoadUpCommand = new AsyncRelayCommand(LoadUp);
        NumbersValidateCommand = new Command(() => { Numbers.Validate(); });
        PaswordizeCommand = new Command(Passwordize);

        Step = 1;
        TotalSteps=4;
    }

    public Command EmailValidateCommand { get; set; }

    public Command PaswordizeCommand { get; set; }
    public Command PasswordValidateCommand { get; set; }
    public Command TestCommand { get; set; }
    public Command AdditioalCommand { get; set; }
    public AsyncRelayCommand LoadUpCommand { get; set; }
    public Command NumbersValidateCommand { get; set; }

    public Validatable<string> Email { get; set; }
    public Validatable<string> Password { get; set; }

    public Validatable<double> Numbers { get; set; }


    bool isPassword;
    public bool IsPassword { get => isPassword; set => SetProperty(ref isPassword, value); }

    public void Passwordize()
    {
        if (IsPassword)
            IsPassword = false;
        else
            IsPassword = true;

        if (ImageSource == "spool.png")
            ImageSource = "res.png";
        else
            ImageSource = "spool.png";
    }

    string imageSource;
    public string ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }


    public override void OnAppearing()
    {
        base.OnAppearing();

        Email.Value = "";
        Password.Value = "";
        IsEnabled = true;
        IsPassword = true;

        ImageSource = "spool.png";

    }

    public void Test()
    {
        Email.Validate();
        Password.Validate();

        var x = Email.Value;
    }

    public void EmailValidate()
    {
        Email.Validate();
    }

    public void PasswordValidate()
    {
        Password.Validate();
    }

    public void Additioal()
    {
        Console.Write("sdfs");
    }


    public async Task LoadUp()
    {
        IsRunning = true;

        await Task.Delay(3000);

        Passwordize();

        if (ImageSource == "spool.png")
            ImageSource = "res.png";
        else
            ImageSource = "spool.png";

        IsRunning = false;
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

}
