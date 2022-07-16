using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.AuthorizationModule.SignInPage;

public class SignInService : BaseService, ISignInService
{
	public SignInService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession sessionService) 
		: base(configService, logger, messageService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SingIn(SignInData user)
	{
		return await TryRun(async () =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}