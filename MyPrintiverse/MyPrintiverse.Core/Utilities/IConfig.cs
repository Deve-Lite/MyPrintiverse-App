namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Store configuration data.
/// </summary>
public interface IConfig : IServerConfig
{
	/// <summary>
	/// Specifies that app is running in developer mode.
	/// </summary>
	public bool DeveloperMode { get; set; }

	/// <summary>
	/// Application runtime culture.
	/// </summary>
	public string Culture { get; set; }

	/// <summary>
	/// Application version.
	/// </summary>
	public string Version { get; set; }
}