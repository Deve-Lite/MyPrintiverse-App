using MyPrintiverse.Core.Storage;

namespace MyPrintiverse.Tools.Settings;

/// <summary>
/// Storage settings using key-value.
/// </summary>
public interface ISettingsStorage : ILocalStorage
{
    /// <summary>
    /// Check if setting with provided <see paramref="key" /> exists.
    /// </summary>
    /// <param name="key">Key to identify setting.</param>
    /// <returns><see langword="true" /> if setting exists, otherwise <see langword="false" />.</returns>
    public bool Exists(string key);
}