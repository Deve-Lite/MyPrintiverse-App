using MyPrintiverse.Core.Extensions;
using MyPrintiverse.Core.Http;
using MyPrintiverse.Tools.Http;

namespace MyPrintiverse.Authorization.ChangePassword;

public class ChangePasswordService : BaseHttpService, IChangePasswordService
{
	public ChangePasswordService(IConfigService<Config> configService, IMessageService messageService,
		ISession sessionService, IHttpService httpService) : base(configService, messageService, httpService, sessionService)
	{
	}

	private record ChangePasswordData(string OldPassword, string NewPassword, string ConfirmPassword);

	public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, string confirmPassword)
	{
		return await TryRun(async (authenticationToken) =>
		{
			var data = new ChangePasswordData(oldPassword, newPassword, confirmPassword);
			var url = ApiLink
				.GetAuthorizationLink(ConfigService.Config.Api.FullPath)
				.ChangePassword();

			var response = await HttpService.Post<string, ChangePasswordData>(url, data);
			
			return response.StatusCode.IsSuccessful();
		});
	}
}