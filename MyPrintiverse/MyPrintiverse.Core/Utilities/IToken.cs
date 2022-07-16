namespace MyPrintiverse.Core.Utilities;

public interface IToken
{
	/// <summary>
	/// Token id.
	/// </summary>
	public string? Id { get; }
	/// <summary>
	/// Token.
	/// </summary>
	public string? Value { get; }
	/// <summary>
	/// Gets value that indicates whether this <see cref="IToken"/> is valid.
	/// </summary>
	public bool IsValid { get; }
	/// <summary>
	/// Token type.
	/// </summary>
	public TokenType TokenType { get; }

	public delegate void SetHandler();

	/// <summary>
	/// Triggered when <see cref="Set(Parameter)"/> or <see cref="Set(List{Parameter})"/> will succeed.
	/// </summary>
	public event SetHandler? OnSuccessfulSet;
	/// <summary>
	/// Triggered when <see cref="Set(Parameter)"/> or <see cref="Set(List{Parameter})"/> will fail.
	/// </summary>
	public event SetHandler? OnFailedSet;

	/// <summary>
	/// Sets token from given <paramref name="parameter"/>.
	/// </summary>
	/// <param name="parameter">RestSharp parameter.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public bool Set(Parameter parameter);

	/// <summary>
	/// Sets token from given <paramref name="parameters"/>.
	/// </summary>
	/// <param name="parameters">RestSharp parameter list.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public bool Set(List<Parameter> parameters);
}