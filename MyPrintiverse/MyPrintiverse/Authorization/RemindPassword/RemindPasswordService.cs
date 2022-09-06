using MyPrintiverse.Core.Http;

namespace MyPrintiverse.Authorization.RemindPassword;

/// <inheritdoc cref="IRemindPasswordService" />
public class RemindPasswordService : BaseHttpService, IRemindPasswordService
{
	public RemindPasswordService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService)
		: base(configService, messageService, httpService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> RemindPasswordAsync(string email)
	{
		return await TryRun(async authorizationToken =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}

	/// <inheritdoc />
	public async Task<bool> RemindPasswordAsync(string email, string code)
	{
		return await TryRun(async authorizationToken =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}
