namespace MyPrintiverse.Tools.Settings;

/// <summary>
/// Storage settings using key-value.
/// </summary>
public interface ISettingsStorage
{
    /// <summary>
    /// Get setting from storage.
    /// </summary>
    /// <typeparam name="T">Setting type.</typeparam>
    /// <param name="key">Key to identify setting.</param>
    /// <returns>setting.</returns>
    public T? Get<T>(string key);

    /// <summary>
    /// Get setting from storage.
    /// </summary>
    /// <typeparam name="T">Setting type.</typeparam>
    /// <param name="key">Key to identify setting.</param>
    /// <param name="obj">Setting to save.</param>
    public void Save<T>(string key, T obj);

    /// <summary>
    /// Delete setting by key.
    /// </summary>
    /// <param name="key">Key to identify setting.</param>
    public void Delete(string key);

    /// <summary>
    /// Delete all settings.
    /// </summary>
    public void DeleteAll();

    /// <summary>
    /// Check if setting with provided <see paramref="key" /> exists.
    /// </summary>
    /// <param name="key">Key to identify setting.</param>
    /// <returns><see langword="true" /> if setting exists, otherwise <see langword="false" />.</returns>
    public bool Exists(string key);
}