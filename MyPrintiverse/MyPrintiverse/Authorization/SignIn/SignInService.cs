using MyPrintiverse.Core.Http;

namespace MyPrintiverse.Authorization.SignIn;

public class SignInService : BaseHttpService, ISignInService
{
	public SignInService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) 
		: base(configService, messageService, httpService, sessionService)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SingIn(SignInData user)
	{
		return await TryRun(async authorizationToken =>
		{
			return await Task.Run(() => false); // TODO: Change it to API request.
		});
	}
}