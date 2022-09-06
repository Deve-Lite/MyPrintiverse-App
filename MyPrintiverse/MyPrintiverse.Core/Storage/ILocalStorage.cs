namespace MyPrintiverse.Core.Storage;

/// <summary>
/// Menage data storage in device non-volatile memory.
/// </summary>
public interface ILocalStorage
{
	/// <summary>
	/// Get value stored in local storage. If <paramref name="key"/> don't exists return default(<typeparamref name="T"/>).
	/// </summary>
	/// <typeparam name="T">Saved value type.</typeparam>
	/// <param name="key">Key assigned to value that you want to get.</param>
	/// <param name="defaultValue">value that will be returned if stored value will be null.</param>
	/// <returns>stored value if value exists, otherwise <paramref name="defaultValue"/>.</returns>
	public T? Get<T>(string key, T? defaultValue = default);

	/// <summary>
	/// Save <paramref name="value"/> in local storage. If <paramref name="key"/> exists, override.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	/// <param name="key">Key that will be linked to provided value.</param>
	/// <param name="value">Value to save in local storage.</param>
	public void Set<T>(string key, T? value);

	/// <summary>
	/// Delete <paramref name="key"/> and data linked to it.
	/// </summary>
	/// <param name="key">Key assigned to value that you want to delete.</param>
	public void Delete(string key);

	/// <summary>
	/// Erase all saved data. Every key-value will be deleted.
	/// </summary>
	public void DeleteAll();
}