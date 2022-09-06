namespace MyPrintiverse.Tools.Settings;

/// <inheritdoc />
public class SettingsStorage : ISettingsStorage
{
    public T? Get<T>(string key, T? defaultValue = default)
    {
        var json = Preferences.Get(key, null);

		if (json is null)
		{
			return defaultValue;
		}

		var setting = JsonConvert.DeserializeObject<T>(json);

        return setting;
    }

    public void Set<T>(string key, T? value)
    {
        var json = JsonConvert.SerializeObject(value);

        Preferences.Set(key, json);
    }

    public void Delete(string key) => Preferences.Remove(key);

    public void DeleteAll() => Preferences.Clear();

    public bool Exists(string key) => Preferences.ContainsKey(key);
}