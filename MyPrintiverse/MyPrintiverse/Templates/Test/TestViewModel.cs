

namespace MyPrintiverse.Templates.Test;

public class TestViewModel : BaseViewModel
{
    bool boolValue;
    public bool BoolValue { get => boolValue; set => SetProperty(ref boolValue, value, test); }

    public void test()
    {
        Console.WriteLine("Pressed");
    }

    public TestViewModel()
    {
        Email = Validator.Build<string>()
            .WithRule(new EmailRule(), "Email is not valid");

        Password = Validator.Build<string>()
            .WithRule(new ContainLowerRule(), "Password should contains at least one lower case letter.")
            .WithRule(new ContainUpperRule(), "Password should contains at least one upper case letter.")
            .WithRule(new ContainDigitsRule(), "Password should contains at least one digit.")
            .WithRule(new RangeRule<string>(8, 20), "Password should be between 8-20 characters.");

        EmailValidateCommand = new Command(EmailValidate);
        PasswordValidateCommand = new Command(PasswordValidate);
        TestCommand = new Command(Test);
    }

    public Command EmailValidateCommand { get; set; }
    public Command PasswordValidateCommand { get; set; }
    public Command TestCommand { get; set; }

    public Validatable<string> Email { get; set; }
    public Validatable<string> Password { get; set; }

    public override void OnAppearing()
    {
        base.OnAppearing();

        //TODO
        // te pola trrzeba wyzerować inaczej ContainLowerRule,ContainUpperRule,ContainDigitsRule sie wywalą jezeli string jest null
        Email.Value = "";
        Password.Value = "";
    }

    public void Test()
    {
        Email.Validate();
        Password.Validate();
    }

    public void EmailValidate()
    {
        Email.Validate();
    }

    public void PasswordValidate()
    {
        Password.Validate();
    }

}
