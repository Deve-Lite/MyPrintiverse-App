namespace MyPrintiverse.Core.Services.Helpers;

/// <summary>
/// Class created for parsing json file to object
/// </summary>
/// <typeparam name="T"></typeparam>
public class RequestData<T>
{
    [JsonProperty("data")]
    public T? Value { get; set; }
}
