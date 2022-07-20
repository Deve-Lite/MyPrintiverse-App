namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc cref="IConfig"/>
public class Config : IConfig, IServerConfig
{
	public bool DeveloperMode { get; set; }
	public string Culture { get; set; }
	public string Version { get; set; }
	public string BaseApiUrl { get; set; }
	public string ClientSecret { get; set; }

	private Config()
	{
		Culture = string.Empty;
		Version = string.Empty;
		BaseApiUrl = string.Empty;
		ClientSecret = string.Empty;
	}

	public bool Verify()
	{
		foreach (var property in GetType().GetProperties())
		{
			var propertyValue = property.GetValue(this, null);

			switch (propertyValue)
			{
				case null:
				case string stringPropertyValue when string.IsNullOrEmpty(stringPropertyValue):
					return false;
			}
		}

		return true;
	}
}