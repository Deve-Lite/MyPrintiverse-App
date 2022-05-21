﻿using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.AuthorizationModule.LoginPage;

public class LogInService : BaseService, ILogInService
{
	public LogInService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession sessionService) : base(configService, logger, messageService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> LogInAsync(string username, string password)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}