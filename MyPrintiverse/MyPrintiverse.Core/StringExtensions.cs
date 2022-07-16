
namespace MyPrintiverse.Core;

public static class StringExtensions
{
	/// <summary>
	/// Convert all <see langword="char" /> in <see langword="string" /> to lower and first letter to upper.
	/// </summary>
	/// <param name="this"></param>
	/// <returns>converted <paramref name="this"/>.</returns>
	public static string FirstLetterToUpper(this string @this)
	{
		if (string.IsNullOrWhiteSpace(@this))
			return string.Empty;

		return @this[0].ToString().ToUpper() + @this[1..^1].ToLower();
	}

	/// <summary>
	/// Convert JSON <see langword="string" /> to <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="this">JSON to convert.</param>
	/// <returns><typeparamref name="T"/> from <paramref name="this"/></returns>
	public static T? ToObject<T>(this string @this) => JsonConvert.DeserializeObject<T>(@this);

	/// <summary>
	/// Validate <see langword="this" /> <see langword="string" />.
	/// </summary>
	/// <param name="this"><see langword="string" /> to validate.</param>
	/// <param name="regexPattern">Regex pattern for validation.</param>
	/// <returns><see langword="true" /> if <paramref name="this" /> is valid, otherwise <see langword="false" />.</returns>
	public static bool Validate(this string @this, string regexPattern) => Regex.IsMatch(@this, regexPattern);

	/// <summary>
	/// Validate <see langword="this" /> <see langword="string" />.
	/// </summary>
	/// <param name="this"><see langword="string" /> to validate.</param>
	/// <param name="regex">Regex with ready pattern.</param>
	/// <returns><see langword="true" /> if <paramref name="this" /> is valid, otherwise <see langword="false" />.</returns>
	public static bool Validate(this string @this, Regex regex) => regex.IsMatch(@this);
}