#nullable enable

using System.Reflection;
using MyPrintiverse.Core.Exceptions;
using MyPrintiverse.Core.File;

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class ConfigService<T> : IConfigService<T> where T : class, IConfig
{
	public T Config { get; }

    public ConfigService(Assembly assembly, string configResourcePath)
    {
		using var configResourceStream = new EmbeddedResourceReader(assembly).GetResourceStream(configResourcePath);
		using var streamReader = new StreamReader(configResourceStream);

		var configJson = streamReader.ReadToEnd();

	    if (string.IsNullOrEmpty(configJson))
		    return;

	    if (!VerifyConfig(configJson))
		    throw new InvalidConfigException();

		var config = configJson.ToObject<T>();

		Config = config ?? throw new InvalidConfigException();

#if DEBUG
	    Config.DeveloperMode = true;
#else
		Config.DeveloperMode = false;
#endif
    }

    private static bool VerifyConfig(string configAsJson) => !Regex.IsMatch(configAsJson, @"\:\snull");
}