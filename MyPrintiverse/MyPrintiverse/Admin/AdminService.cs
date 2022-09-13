using MyPrintiverse.Admin.Models;
using MyPrintiverse.Admin.Tests;
using MyPrintiverse.Core.Extensions;
using MyPrintiverse.Core.File;
using MyPrintiverse.Core.Http;
using MyPrintiverse.Tools.Http;

namespace MyPrintiverse.Admin
{
    /// <inheritdoc cref="IAdminService" />
    public class AdminService : BaseHttpService, IAdminService
	{
		public AdminService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession session) : base(configService, messageService, httpService, session)
		{
		}

		public async Task<List<string>> GetAssets() => await Task.Run(() =>
		{
			var assembly = Assembly.GetExecutingAssembly();

			return new EmbeddedResourceReader(assembly)
				.GetLoadedEmbeddedResources();
		});

		public async Task<bool> PingApi()
		{
			return await TryRun(async () =>
			{
				var url = ApiLink
					.GetPingLink(ConfigService.Config.Api.FullPath)
					.Ping();

				var response = await HttpService.Get<string>(url);

				return response.StatusCode.IsSuccessful();
			});
		}

        public async Task<bool> Register(string email, string password, string username)
        {
            return await TryRun(async () =>
            {
                var url = ApiLink
                    .GetAuthorizationLink(ConfigService.Config.Api.FullPath)
                    .RegisterUser();

                var response = await HttpService.Post<string, RegisterData>(url, new RegisterData { Email=email, Password=password, Username=username });

                return response.StatusCode.IsSuccessful();
            });
        }

        public async Task<bool> ConfirmMail(string email, string code)
        {
            return await TryRun(async () =>
            {
                var url = ApiLink
                    .GetAuthorizationLink(ConfigService.Config.Api.FullPath)
                    .ConfirmMail();

                var response = await HttpService.Post<string, ConfirmData>(url, new ConfirmData { Email=email, Code=code });

                return response.StatusCode.IsSuccessful();
            });
        }

        public async Task<bool> LogIn(string email, string password)
        {
            return await TryRun(async authorizationToken =>
            {
                var url = ApiLink
                    .GetAuthorizationLink(ConfigService.Config.Api.FullPath)
                    .LoginUser();

                return await Session.Authorize<Token>(HttpService, url, email, password);
            });
        }

        public async Task OpenAndromeda() => await Shell.Current.GoToAsync(nameof(AndromedaView));

		public async Task OpenOdyssey() => await Shell.Current.GoToAsync(nameof(OdysseyView));

		public async Task OpenOrion() => await Shell.Current.GoToAsync(nameof(OrionView));
	}
}


