using MyPrintiverse.Core.Http;

namespace MyPrintiverse.Authorization.Settings;

public class SettingsService : BaseHttpService, ISettingsService
{
	public SettingsService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService)
		: base(configService, messageService, httpService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SaveSettings(Settings settings)
	{
		return await TryRun(async authorizationToken =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}