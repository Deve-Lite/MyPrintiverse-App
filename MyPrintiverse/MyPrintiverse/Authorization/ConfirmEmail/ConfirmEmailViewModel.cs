namespace MyPrintiverse.Authorization.ConfirmEmail;

public sealed partial class ConfirmEmailViewModel : BaseViewModel
{
	public string Email { get; set; }
	public Validatable<string> VerificationCode { get; set; }

	private readonly IConfirmEmailService _changePasswordService;

	public ConfirmEmailViewModel(IConfirmEmailService changePasswordService, string email)
	{
		_changePasswordService = changePasswordService;

		Email = email;

		VerificationCode = Validator.Build<string>()
			.WithRule(new RangeRule<string>(6, 6), "Wrong verification code")
			.WithRule(new OnlyDigitsRule(), "Wrong verification code");
	}

	[RelayCommand]
	public async Task VerifyEmail()
	{
		if (!VerificationCode.IsValid)
			await _changePasswordService.MessageService.ShowErrorAsync();

		var result = await _changePasswordService.ConfirmEmailAsync(Email, VerificationCode.Value);

		if (result)
			return; //TODO: Add navigation

		await _changePasswordService.MessageService.ShowErrorAsync();
	}
}