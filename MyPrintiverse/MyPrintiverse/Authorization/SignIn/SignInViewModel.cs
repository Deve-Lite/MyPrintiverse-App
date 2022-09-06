using System.Windows.Input;

namespace MyPrintiverse.Authorization.SignIn;

public class SignInViewModel : BaseViewModel
{
	public Validatable<string> Email { get; set; }
	public Validatable<string> Password { get; set; }
	public Validatable<string> ConfirmPassword { get; set; }

	public ICommand SignInCommand { get; }

	private readonly ISignInService _signInService;
	
	public SignInViewModel(ISignInService signInService)
	{
		_signInService = signInService;

		SignInCommand = new AsyncCommand(SignIn, CanExecute);

		SetupValidation();
	}

	private void SetupValidation()
	{
		Email = Validator.Build<string>()
			.WithRule(new EmailRule(), "Not valid email");

		Password = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), "Password should contains at least one lower case letter.")
			.WithRule(new ContainUpperRule(), "Password should contains at least one upper case letter.")
			.WithRule(new ContainDigitsRule(), "Password should contains at least one digit.")
			.WithRule(new RangeRule<string>(8, 20), "Password should be between 8-20 characters.");

		ConfirmPassword = Validator.Build<string>()
			.WithRule(new RangeRule<string>(8, 20), "Password should be between 8 and 20 characters.")
			.WithRule(new EmailRule(), "Not valid email");
	}

	private async Task SignIn()
	{
		if (!Email.IsValid || !Password.IsValid || !ConfirmPassword.IsValid)
			return;

		var signInData = new SignInData(Email.Value, Password.Value, ConfirmPassword.Value);

		await _signInService.SingIn(signInData);
	}
}