namespace MyPrintiverse.Tools.Settings;

/// <inheritdoc />
public class SettingsStorage : ISettingsStorage
{
    public T? Get<T>(string key)
    {
        var defaultValue = JsonConvert.SerializeObject(default(T));

        var json = Preferences.Get(key, defaultValue);

        var setting = JsonConvert.DeserializeObject<T>(json);

        return setting;
    }

    public void Save<T>(string key, T obj)
    {
        var json = JsonConvert.SerializeObject(obj);

        Preferences.Set(key, json);
    }

    public void Delete(string key) => Preferences.Remove(key);

    public void DeleteAll() => Preferences.Clear();

    public bool Exists(string key) => Preferences.ContainsKey(key);
}