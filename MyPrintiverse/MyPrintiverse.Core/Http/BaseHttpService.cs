using MyPrintiverse.Core.Exceptions;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Http;

public class BaseHttpService : BaseService, IBaseHttpService
{
	public IHttpService HttpService { get; set; }

	public string? RefreshUrl { get; set; }

	public delegate void AuthorizationFailHandler();
	public event AuthorizationFailHandler? OnAuthorizeFail;

	public BaseHttpService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(configService, messageService, sessionService)
	{
		HttpService = httpService;
	}

	/// <summary>
	/// Try run operation (function) if it throw exception, function catch it if app is not in developer mode and will show error message. For authorized endpoints.
	/// </summary>
	/// <param name="function"></param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	protected async Task<bool> TryRun(Func<IToken?, Task<bool>> function)
	{
		var token = Session.AccessToken;

		try
		{
			return await function(token);
		}
		catch (TokenException)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(RefreshUrl))
					throw new RefreshTokenException();

				await Session.ReAuthorize<Token>(HttpService, RefreshUrl);
			}
			catch (RefreshTokenException)
			{
				OnAuthorizeFail?.Invoke();
			}
		}
		catch (Exception) when (!ConfigService.Config.DeveloperMode)
		{
			await MessageService.ShowErrorAsync();
		}

		return false;
	}


	/// <summary>
	/// Try run operation (function) if it throw exception, function catch it if app is not in developer mode and will show error message. For not authorized endpoints.
	/// </summary>
	/// <param name="function"></param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	protected async Task<bool> TryRun(Func<Task<bool>> function)
	{
		try
		{
			return await function();
		}
		catch (TokenException)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(RefreshUrl))
					throw new RefreshTokenException();

				await Session.ReAuthorize<Token>(HttpService, RefreshUrl);
			}
			catch (RefreshTokenException)
			{
				OnAuthorizeFail?.Invoke();
			}
		}
		catch (Exception ex) when (!ConfigService.Config.DeveloperMode)
		{
			var test = ConfigService.Config.DeveloperMode;
			var test2 = ex;
			await MessageService.ShowErrorAsync();
		}

		return false;
	}
}