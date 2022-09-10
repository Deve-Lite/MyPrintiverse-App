namespace MyPrintiverse.Core.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Convert <typeparamref name="T"/> to json <see langword="string" />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"><typeparamref name="T"/> to convert.</param>
    /// <returns>json from <typeparamref name="T"/>.</returns>
    public static string ToJson<T>(this T @this) => JsonConvert.SerializeObject(@this);
}