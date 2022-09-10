

namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Class created for parsing json file to object
/// </summary>
/// <typeparam name="T"></typeparam>
public class RequestParsator<T>
{
    [JsonProperty("data")]
    public T Value { get; set; }
}
