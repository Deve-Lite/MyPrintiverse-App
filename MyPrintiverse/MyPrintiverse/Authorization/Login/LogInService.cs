using MyPrintiverse.Core.Http;
using MyPrintiverse.Tools.Http;

namespace MyPrintiverse.Authorization.Login;

/// <inheritdoc cref="ILoginService" />
public class LoginService : BaseHttpService, ILoginService
{
	public LoginService(IConfigService<Config> configService, IMessageService messageService, ISession sessionService, IHttpService httpService) : base(configService, messageService, httpService, sessionService)
	{
	}

	public async Task<bool> LogInAsync(string login, string password)
	{
		return await TryRun(async authorizationToken =>
		{
			var url = ApiLink
				.GetAuthorizationLink(ConfigService.Config.Api.FullPath)
				.LoginUser();

			return await Session.Authorize<Token>(HttpService, url, login, password);
		});
	}
}