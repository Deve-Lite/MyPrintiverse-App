using System.IdentityModel.Tokens.Jwt;

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class Token : IToken
{
	public string? Id { get; private set; }
	public string? Value { get; private set; }

	public bool IsValid { get; private set; }

	public TokenType TokenType { get; }

	public Token(TokenType tokenType)
	{
		TokenType = tokenType;
		IsValid = false;
	}

	public event IToken.SetHandler? OnSuccessfulSet;
	public event IToken.SetHandler? OnFailedSet;

	private string TokenName => TokenType == TokenType.Authorization ? "Authorization" : "Refresh-Token";

	public bool Set(List<Parameter> parameters)
	{
		Value = parameters.Find(param => param.Name == TokenName)?.Value?.ToString();

		return CheckToken();
	}

	public bool Set(Parameter parameter)
	{
		if (parameter.Name == TokenName)
		{
			Value = parameter.Value?.ToString();
		}

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
		token = token.Replace("Bearer", string.Empty).Trim();

		var handler = new JwtSecurityTokenHandler();
		var webToken = handler.ReadToken(token) as JwtSecurityToken;

		Id = webToken?.Claims.First(claim => claim.Type == "_id").Value.ToString();
	}
}