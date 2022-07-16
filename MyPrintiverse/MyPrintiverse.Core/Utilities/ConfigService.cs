#nullable enable

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class ConfigService<T> : IConfigService<T> // TODO: Refactor this shit
{
	protected static ConfigService<T>? _configInstance;

	protected Dictionary<string, string> _config = new();
	protected readonly string _filePath;

	public T Config { get; set; } 

	/// <summary>
	/// Create and return <see cref="ConfigServiceServiceService{T}" /> instance.
	/// </summary>
	/// <exception cref="ArgumentException" />
	/// <exception cref="FileNotFoundException" />
	/// <param name="filePath">ConfigServiceService file disc path.</param>
	/// <param name="logger">ILogger instance.</param>
	/// <returns><see cref="ConfigServiceServiceService{T}" /> instance.</returns>
	public static ConfigService<T> GetInstance(string filePath)
	{
		if (_configInstance == null)
			_configInstance = new ConfigService<T>(filePath);

		return _configInstance;
	}

	protected ConfigService(string configFilePath)
	{
		_filePath = configFilePath;

		ReadConfigAsync();

		lock (_config)
		{
			if (_config.Count is 0)
				throw new FileNotFoundException(nameof(_filePath));
		}
	}

	private async void ReadConfigAsync()
	{
		await Task.Run(async () =>
		{
			using var streamReader = new StreamReader(_filePath);
			var configJson = await streamReader.ReadToEndAsync();

			lock (_config)
			{
				_config = JsonConvert.DeserializeObject<Dictionary<string, string>>(configJson) ?? new Dictionary<string, string>();
			}
		});
	}

	private async void SaveConfigAsync()
	{
		await Task.Run(async () =>
		{
			await using var streamWriter = new StreamWriter(_filePath);
			string? configJson;

			lock (_config)
			{
				configJson = JsonConvert.SerializeObject(_config);
			}

			if (string.IsNullOrWhiteSpace(configJson))
				await streamWriter.WriteAsync(configJson);
		});
	}
}