namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Store configuration data.
/// </summary>
public interface IConfig
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

	/// <summary>
	/// Check if all <see cref="IConfig"/> properties are specified.
	/// </summary>
	/// <returns><see langword="false"/> if any property is null or empty, otherwise <see langword="true"/>.</returns>
	public bool Verify();
}