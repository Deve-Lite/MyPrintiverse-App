#nullable enable
namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Application config provider.
/// </summary>
public interface IConfigService<out T>
{
	/// <summary>
	/// Application config.
	/// </summary>
	public T Config { get; }
}