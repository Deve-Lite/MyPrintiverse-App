namespace MyPrintiverse.Core.Storage;

/// <summary>
/// Menage data storage in device non-volatile memory.
/// </summary>
public interface ILocalStorage
{
	/// <summary>
	/// Get value stored in local storage. If <paramref name="key"/> don't exists return default(<typeparamref name="T"/>).
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	/// <param name="key"></param>
	/// <returns></returns>
	public T? Get<T>(string key);

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
	/// <param name="key"></param>
	public void Delete(string key);

	/// <summary>
	/// Erase all saved data. Every key-value will be deleted.
	/// </summary>
	public void DeleteAll();
}