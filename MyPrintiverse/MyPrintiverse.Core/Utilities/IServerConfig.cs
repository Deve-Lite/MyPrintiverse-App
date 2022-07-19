namespace MyPrintiverse.Core.Utilities;

public interface IServerConfig
{
	/// <summary>
	/// Base api url for api requests.
	/// </summary>
	public string BaseApiUrl { get; set; }

	/// <summary>
	/// Client secret for api authorization.
	/// </summary>
	public string ClientSecret { get; set; }
}