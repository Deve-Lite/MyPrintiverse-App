#nullable enable
using MyPrintiverse;
using MyPrintiverse.BaseServices.Interfaces;

namespace MyPrintiverse.BaseServices;

/// <summary>
/// Config manager. (Tread safe)
/// </summary>
public class Config : IConfig
{
    private static Config? _configInstance;

    private Dictionary<string, string> _config = new();
    private readonly string _filePath;

    #region Properties

    public string ApiUrl { get; set; }
    public AppMode AppMode { get; set; }

    #endregion

    /// <summary>
    /// Create <see cref="Config" /> instance.
    /// </summary>
    /// <exception cref="ArgumentException" />
    /// <exception cref="FileNotFoundException" />
    /// <param name="filePath">Config file disc path.</param>
    /// <returns><see cref="Config" /> instance.</returns>
    public static Config GetInstance(string filePath)
    {
        switch (_configInstance)
        {
            case null:
                _configInstance = new Config(filePath);

                return _configInstance;
            default:
                return _configInstance;
        }
    }

    /// <summary>
    /// Release (delete) instance.
    /// </summary>
    public static void ReleaseInstance() => _configInstance = null;

    protected Config(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));

        ReadConfigAsync();

        lock (_config)
        {
            if (_config.Count is 0)
            {
                throw new FileNotFoundException(nameof(filePath));
            }
        }
    }

    /// <summary>
    /// Get/Set config property by <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="propertyName">Config property name</param>
    /// <returns>property value if property with provided <paramref name="propertyName"/> exists, otherwise <see langword="throw" /> <see cref="ArgumentException"/>.</returns>
    /// <exception cref="ArgumentException" />
    public string this[string propertyName]
    {
        get
        {
            if (!_config.ContainsKey(propertyName))
            {
                throw new ArgumentException($"{nameof(Config)} - {nameof(propertyName)}");
            }

            return _config[propertyName];
        }

        // Łukasz czy będziemy zapisywać config z poziomu aplikacji?
        set
        {
            if (!_config.ContainsKey(propertyName))
            {
                throw new ArgumentException($"{nameof(Config)} - {nameof(propertyName)}");
            }

            _config[propertyName] = value;
            SaveConfigAsync();
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

    // Łukasz czy będziemy zapisywać konfig z poziomu aplikacji?
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