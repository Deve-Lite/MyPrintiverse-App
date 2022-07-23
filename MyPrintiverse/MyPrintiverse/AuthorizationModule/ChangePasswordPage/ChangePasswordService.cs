namespace MyPrintiverse.AuthorizationModule.ChangePasswordPage;

public class ChangePasswordService : BaseService, IChangePasswordService
{
	public ChangePasswordService(IConfigService<Config> configService, ILogger logger, IMessageService messageService,
		ISession sessionService) : base(configService, logger, messageService, sessionService)
	{
	}

	public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, string confirmPassword)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}