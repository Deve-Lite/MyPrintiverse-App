using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyPrintiverse.Authorization.ChangePassword;

public sealed partial class ChangePasswordViewModel : BaseViewModel
{
	[ObservableProperty]
	private Validatable<string> _currentPassword;

	[ObservableProperty] 
	public Validatable<string> _newPassword;

	[ObservableProperty] 
	public Validatable<string> _confirmPassword;

	private readonly IChangePasswordService _changePasswordService;

	public ChangePasswordViewModel(IChangePasswordService changePasswordService)
	{
		_changePasswordService = changePasswordService;

		const string atLeastOneLowerMessage = "Password should contains at least one lower case letter.";
		const string atLeastOneUpperMessage = "Password should contains at least one upper case letter.";
		const string atLeastOneDigitMessage = "Password should contains at least one digit.";
		const string shouldBeInRangeMessage = "Password should be between 8-20 characters.";

		CurrentPassword = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), atLeastOneLowerMessage)
			.WithRule(new ContainUpperRule(), atLeastOneUpperMessage)
			.WithRule(new ContainDigitsRule(), atLeastOneDigitMessage)
			.WithRule(new RangeRule<string>(8, 20), shouldBeInRangeMessage);

		NewPassword = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), atLeastOneLowerMessage)
			.WithRule(new ContainUpperRule(), atLeastOneUpperMessage)
			.WithRule(new ContainDigitsRule(), atLeastOneDigitMessage)
			.WithRule(new RangeRule<string>(8, 20), shouldBeInRangeMessage);

		ConfirmPassword = Validator.Build<string>()
			.WithRule(new ContainLowerRule(), atLeastOneLowerMessage)
			.WithRule(new ContainUpperRule(), atLeastOneUpperMessage)
			.WithRule(new ContainDigitsRule(), atLeastOneDigitMessage)
			.WithRule(new RangeRule<string>(8, 20), shouldBeInRangeMessage);
	}

	[RelayCommand]
	private async Task ChangePassword()
	{
		if (!CurrentPassword.IsValid || !NewPassword.IsValid || !ConfirmPassword.IsValid)
			return;

		var result = await _changePasswordService.ChangePasswordAsync(CurrentPassword.Value, NewPassword.Value, ConfirmPassword.Value);

		if (result)
			return; //TODO: Add navigation

		IsBusy = false;
	}
}