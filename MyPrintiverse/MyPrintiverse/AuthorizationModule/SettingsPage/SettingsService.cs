using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.AuthorizationModule.SettingsPage;

public class SettingsService : BaseService, ISettingsService
{
	public SettingsService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession sessionService)
		: base(configService, logger, messageService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SaveSettings(Settings settings)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}