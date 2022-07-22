namespace MyPrintiverse.Core.Storage
{
	/// <inheritdoc />
	public class LocalStorage : ILocalStorage
	{
		public T? Get<T>(string key)
		{
			if (!Preferences.ContainsKey(key)) 
				return default;

			var json = Preferences.Get(key, string.Empty);
			var value = JsonConvert.DeserializeObject<T>(json);

			return value ?? default;
		}

		public void Set<T>(string key, T? value)
		{
			var json = JsonConvert.SerializeObject(value);

			Preferences.Set(key, json);
		}

		public void Delete(string key) => Preferences.Remove(key);

		public void DeleteAll() => Preferences.Clear();
	}
}
