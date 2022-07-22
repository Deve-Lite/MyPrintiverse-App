using MyPrintiverse.Core.Http;

namespace MyPrintiverse.AuthorizationModule.ConfirmEmailPage;

public class ConfirmEmailService : BaseHttpService, IConfirmEmailService
{
	public ConfirmEmailService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, IHttpService httpService, ISession sessionService) 
		: base(configService, logger, messageService, httpService, sessionService)
	{
	}


	/// <inheritdoc />
	public async Task<bool> ConfirmEmailAsync(string email, string code)
	{
		return await TryRun(async () =>
		{
			var url = string.Empty; //TODO

			var result = await HttpService.Get<bool>(url);

			return result.Value;
		});
	}
}