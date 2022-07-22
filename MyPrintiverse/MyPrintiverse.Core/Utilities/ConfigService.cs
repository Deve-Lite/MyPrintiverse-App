#nullable enable

using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class ConfigService<T> : IConfigService<T> where T : class, IConfig
{
    public T Config { get; }

    //Te zmiany tylko po to ambym mógł używać aplikacji
    public ConfigService(string filePath) : this(new FileStream(filePath, FileMode.Append)) //: this(new FileStream(filePath, FileMode.Open))
    {
    }

    public ConfigService(Stream fileStream)
    {

        //var streamReader = new StreamReader(fileStream);
        //var configJso = streamReader.ReadToEnd();
        var configJson = "{\r\n  \"Culture\": \"en\",\r\n  \"Version\": \"1\",\r\n  \"BaseApiUrl\": \"https://docs.microsoft.com/\",\r\n  \"ClientSecret\":  \"null\"\r\n}";

        if (string.IsNullOrEmpty(configJson))
            return;

        var config = configJson.ToObject<T>();

        if (config is null)
            return;

        if (!config.Verify())
            throw new InvalidConfigException();


        Config = config;

#if DEBUG
        Config.DeveloperMode = true;
#else
		Config.DeveloperMode = false;
#endif
    }
}