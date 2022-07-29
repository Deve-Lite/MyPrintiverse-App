using MyPrintiverse.Core.Utilities;
using MyPrintiverse.Core.Validation;

namespace MyPrintiverse.AuthorizationModule.RemindPasswordPage;

public class RemindPasswordViewModel : BaseViewModel
{
	public Validatable<string> Email { get; set; }
	public Validatable<string> RecoveryCode { get; set; }

	public ICommand RemindPasswordInitCommand { get; }
	public ICommand RemindPasswordWithCodeCommand { get; }

	private readonly IRemindPasswordService _remindPasswordService;

	public RemindPasswordViewModel(IRemindPasswordService remindPasswordService)
	{
		_remindPasswordService = remindPasswordService;

		RemindPasswordInitCommand = new AsyncCommand(RemindPasswordInit, CanExecute, shellExecute: ExecuteBlockade);
		RemindPasswordWithCodeCommand = new AsyncCommand(RemindPasswordWithCode, CanExecute, shellExecute: ExecuteBlockade);

		SetupValidation();
	}

	private void SetupValidation()
	{
		Email = Validator.Build<string>()
			.WithRule(new EmailRule(), "Email is not valid");

		RecoveryCode = Validator.Build<string>()
			.WithRule(new RangeRule<string>(6, 6), "Wrong recovery code")
			.WithRule(new OnlyDigitsRule(), "Wrong recovery code");
	}

	private async Task RemindPasswordInit()
	{
		if (!Email.IsValid)
			return;

		var isRemindPasswordSuccessful = await _remindPasswordService.RemindPasswordAsync(Email.Value);

		if (isRemindPasswordSuccessful)
			return; // TODO: Navigation

		RecoveryCode.Error = "Wrong recovery code";
	}

	private async Task RemindPasswordWithCode() 
	{
		if (!Email.IsValid || RecoveryCode.IsValid)
			return;

		var isRemindPasswordSuccessful = await _remindPasswordService.RemindPasswordAsync(Email.Value, RecoveryCode.Value);

		if (isRemindPasswordSuccessful)
			return; // TODO: Navigation

		RecoveryCode.Error = "Wrong recovery code";
	}
}