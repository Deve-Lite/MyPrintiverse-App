#nullable enable
namespace MyPrintiverse.BaseServices;

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