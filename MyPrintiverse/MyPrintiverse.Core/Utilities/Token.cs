using System.IdentityModel.Tokens.Jwt;

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class Token : IToken
{
	public string? Id { get; private set; }
	public string? Value { get; private set; }

	public bool IsValid { get; private set; }

	public Token()
	{
		IsValid = false;
	}

	public event IToken.SetHandler? OnSuccessfulSet;
	public event IToken.SetHandler? OnFailedSet;

	public bool Set(string? token)
	{
		Value = token;

		return CheckToken();
	}

	private bool CheckToken()
	{
		IsValid = !string.IsNullOrEmpty(Value);

		if (IsValid)
		{
			OnSuccessfulSet?.Invoke();
			SetTokenId(Value!);
		}
		else
		{
			OnFailedSet?.Invoke();
		}

		return IsValid;
	}

	private void SetTokenId(string token)
	{
		var handler = new JwtSecurityTokenHandler();
		var webToken = handler.ReadToken(token) as JwtSecurityToken;

		Id = webToken?.Claims.First(claim => claim.Type == "_id").Value.ToString();
	}
}