using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.AuthorizationModule.RemindPasswordPage;

/// <inheritdoc cref="IRemindPasswordService" />
public class RemindPasswordService : BaseService, IRemindPasswordService
{
	public RemindPasswordService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession sessionService)
		: base(configService, logger, messageService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> RemindPasswordAsync(string email)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}

	/// <inheritdoc />
	public async Task<bool> RemindPasswordAsync(string email, string code)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}
