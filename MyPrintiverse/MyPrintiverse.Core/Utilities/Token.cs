using System.IdentityModel.Tokens.Jwt;

namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Class for managing token and refresh token.
/// </summary>
public class Token
{
	public static string Id { get; set; }
	public static string AccessToken { get; set; }
	public static string RefreshToken { get; set; }

	public static bool SetAccessToken(List<Parameter> list)
	{
		AccessToken = list.Find(x => x.Name == "Authorization")?.Value?.ToString();
		var isGetTokenIdSuccessful = GetTokenId(AccessToken);

		return string.IsNullOrEmpty(AccessToken) && isGetTokenIdSuccessful;
	}

	public static bool SetRefreshToken(List<Parameter> list)
	{
		RefreshToken = list.Find(x => x.Name == "Refresh-Token")?.Value?.ToString();

		return string.IsNullOrEmpty(RefreshToken);
	}

	public static bool GetTokenId(string token)
	{
		token = token.Replace("Bearer", "").Trim();

		var handler = new JwtSecurityTokenHandler();
		var webToken = handler.ReadToken(token) as JwtSecurityToken;

		Id = webToken?.Claims.First(claim => claim.Type == "_id").Value.ToString();

		return string.IsNullOrEmpty(Id);
	}
}