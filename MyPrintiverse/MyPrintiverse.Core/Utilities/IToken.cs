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
	/// Sets token.
	/// </summary>
	/// <param name="token">Token to set.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public bool Set(string? token);
}