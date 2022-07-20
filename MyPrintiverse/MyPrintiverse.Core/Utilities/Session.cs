#nullable enable

namespace MyPrintiverse.Core.Utilities;


/// <inheritdoc />
public class Session : ISession
{
	public IToken? AccessToken { get; }
	public IToken? RefreshToken { get; }

	public bool IsLogged => AccessToken != null && RefreshToken != null;
	public bool HasConnection { get; set; }
	
	public IConfigService<IConfig> Config { get; }
	
	public delegate void LoggoutHandler();
	public event LoggoutHandler OnAuthorizationFail;
	
	public Session(IConfigService<IConfig> config)
	{
		Config = config;
	}

	public bool Authorize(string login, string password)
	{
		return false;
	}

	public bool ReAuthorize()
	{
		if (true)
		{
			OnAuthorizationFail?.Invoke();
			return false;
		}

		return true;
	}
}