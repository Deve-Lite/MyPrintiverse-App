using MyPrintiverse.Core.Utilities;
using MyPrintiverse.Core.Validation;

namespace MyPrintiverse.AuthorizationModule.LoginPage;

public class LoginViewModel : BaseViewModel
{
	public Validatable<string> Email { get; set; }
	public Validatable<string> Password { get; set; }

	public ICommand LogInCommand { get; }

	private readonly ILogInService _logInService;

	public LoginViewModel(ILogInService logInService)
	{
		_logInService = logInService;

		LogInCommand = new AsyncCommand(LogIn, CanExecute, shellExecute: ExecuteBlockade);

		Email = Validator.Build<string>()
			.WithRule(new EmailRule(), "Email is not valid");

		Password = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), "Password should contains at least one lower case letter.")
			.WithRule(new ContainUpperRule(), "Password should contains at least one upper case letter.")
			.WithRule(new ContainDigitsRule(), "Password should contains at least one digit.")
			.WithRule(new RangeRule<string>(8, 20), "Password should be between 8-20 characters.");
	}

	private async Task LogIn()
	{
		if (!Email.IsValid || !Password.IsValid)
			return;

		var isLogInSuccessful = await _logInService.LogInAsync(Email.Value, Password.Value);

		if (isLogInSuccessful)
			return; // TODO: Add navigation

		await _logInService.MessageService.ShowErrorAsync();
	}
}