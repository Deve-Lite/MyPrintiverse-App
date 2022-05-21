#nullable enable
namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// ConfigServiceService manager.
/// </summary>
public interface IConfigService<T>
{
	/// <summary>
	/// Loaded config from file.
	/// </summary>
    public T Config { get; set; }
}