#nullable enable

using Develite.Utilities.Exceptions;

namespace MyPrintiverse.Tools;

/// <inheritdoc />
public class ConfigService<T> : IConfigService<T>
{
	protected static ConfigService<T>? _configInstance;

	protected Dictionary<string, string> _config = new();
	protected readonly string _filePath;

	/// <inheritdoc />
	public T Config { get; set; }

	/// <summary>
	/// Create and return <see cref="ConfigServiceServiceService{T}" /> instance.
	/// </summary>
	/// <exception cref="ArgumentException" />
	/// <exception cref="FileNotFoundException" />
	/// <param name="filePath">ConfigServiceService file disc path.</param>
	/// <param name="logger">ILogger instance.</param>
	/// <returns><see cref="ConfigServiceServiceService{T}" /> instance.</returns>
	public static ConfigService<T> GetInstance()
	{
		if (_configInstance == null)
			throw new NotInitializeException();
		
		return _configInstance;
	}

	/// <summary>
	/// Release (delete) instance.
	/// </summary>
	public static void ReleaseInstance() => _configInstance = null;

	/// <summary>
	/// Create <see cref="ConfigServiceServiceService{T}" /> instance.
	/// </summary>
	/// <exception cref="ArgumentException" />
	/// <exception cref="FileNotFoundException" />
	/// <param name="filePath">ConfigServiceService file disc path.</param>
	/// <param name="logger">ILogger instance.</param>
	public static void Initialize(string configFilePath) =>
		_configInstance ??= new ConfigService<T>(configFilePath);

	protected ConfigService(string configFilePath)
	{
		_filePath = configFilePath;

		ReadConfigAsync();

		lock (_config)
		{
			if (_config.Count is 0)
			{
				throw new FileNotFoundException(nameof(_filePath));
			}
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
			{
				await streamWriter.WriteAsync(configJson);
			}
		});
	}
}