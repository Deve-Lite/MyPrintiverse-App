using MyPrintiverse.Core.Http;
using MyPrintiverse.Tools.Http;

namespace MyPrintiverse.Authorization.ConfirmEmail;

public class ConfirmEmailService : BaseHttpService, IConfirmEmailService
{
	public ConfirmEmailService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) 
		: base(configService, messageService, httpService, sessionService)
	{
	}

	private record ConfirmEmailData(string Email, string Code);

	/// <inheritdoc />
	public async Task<bool> ConfirmEmailAsync(string email, string code)
	{
		return await TryRun(async (authenticationToken) =>
		{
			var data = new ConfirmEmailData(email, code);
			var url = ApiLink
				.GetAuthorizationLink(ConfigService.Config.Api.FullPath)
				.ConfirmPassword();

			var result = await HttpService.Post<bool, ConfirmEmailData>(url, data, authenticationToken);

			return result.Value;
		});
	}

}