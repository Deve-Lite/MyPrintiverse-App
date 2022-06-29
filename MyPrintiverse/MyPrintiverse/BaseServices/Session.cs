#nullable enable

namespace MyPrintiverse.BaseServices;

/// <summary>
/// Session manager.
/// </summary>
public class Session : ISession
{
	private static Session? _instance;

	private Session()
	{

	}

	public static Session GetInstance() => _instance ?? new Session();
	public static Session ReleaseInstance() => _instance = null;

	public event Action OnConnectionLost;
        
	public string? SessionToken { get; set; }

	/// <summary>
	/// Returns true if app user is logged else false.
	/// </summary>
	public bool IsLogged => SessionToken != null;

	/// <summary>
	/// Returns true if device is connected to internet else false.
	/// </summary>
	public bool HasConnection { get; set; }

}