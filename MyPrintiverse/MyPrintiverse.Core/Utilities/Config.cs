namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc cref="IConfig"/>
public class Config : IConfig
{
	public bool DeveloperMode { get; set; }
	public string Culture { get; set; }
	public string Version { get; set; }
	public Api Api { get; set; }

	private Config()
	{
		Culture = string.Empty;
		Version = string.Empty;
		Api = new Api();
	}
}

public class Api
{
	public string Protocol { get; set; }
	public string Address { get; set; }
	public string Port { get; set; }

	public string FullPath
	{
		get
		{
			var stringBuilder = new StringBuilder();

			if (!string.IsNullOrEmpty(Protocol))
				stringBuilder.Append($"{Protocol}://");

			stringBuilder.Append($"{Address}");

			if (!string.IsNullOrWhiteSpace(Port))
				stringBuilder.Append($":{Port}");

			return stringBuilder.ToString();
		}
	}

	internal Api()
	{
		Protocol = string.Empty;
		Address = string.Empty;
		Port = string.Empty;
	}
}