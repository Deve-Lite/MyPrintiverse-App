using MyPrintiverse.Authorization.SignIn;
using MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

namespace MyPrintiverse.Authorization.Login;

public sealed partial class LoginViewModel : BaseViewModel
{
	public Validatable<string> Email { get; set; }
	public Validatable<string> Password { get; set; }

	private readonly ILoginService _loginService;

	public LoginViewModel(ILoginService loginService)
	{
		_loginService = loginService;

		Email = Validator.Build<string>()
			.WithRule(new EmailRule(), "Email is not valid");

		Password = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), "Password should contains at least one lower case letter.")
			.WithRule(new ContainUpperRule(), "Password should contains at least one upper case letter.")
			.WithRule(new ContainDigitsRule(), "Password should contains at least one digit.")
			.WithRule(new RangeRule<string>(8, 20), "Password should be between 8-20 characters.");
	}

	[RelayCommand]
	private async Task LogIn()
	{
		if (!_loginService.ConfigService.Config.DeveloperMode) // Co to kurwa napisałem???? Trzeba poprawić
		{
			if (!Email.IsValid || !Password.IsValid)
				return;

			var isLogInSuccessful = await _loginService.LogInAsync(Email.Value, Password.Value);

			if (!isLogInSuccessful)
				await _loginService.MessageService.ShowErrorAsync();
		}
	}

	[RelayCommand]
	private async Task SignIn()
	{
		await Shell.Current.GoToAsync($"/{nameof(SignInView)}");
	}

	[RelayCommand]
	private async Task GoToMainPage()
	{
		await Shell.Current.GoToAsync($"/{nameof(FilamentsView)}");
	}
}