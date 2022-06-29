using System;
using System.IdentityModel.Tokens.Jwt;

namespace MyPrintiverse.Tools
{
    /// <summary>
    /// Class for managing token and refreshtoken.
    /// </summary>
    public static class Token
    {
        public static string Id { get; set; }
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }

        public static bool GetAccessToken(List<Parameter> list)
        {
            AccessToken = list.Find(x => x.Name == "Authorization").Value.ToString();
            bool a = GetTokenId(AccessToken);

            return string.IsNullOrEmpty(AccessToken) && a;
        }

        public static bool GetRefreshToken(List<Parameter> list)
        {
            RefreshToken = list.Find(x => x.Name == "Refresh-Token").Value.ToString();

            return string.IsNullOrEmpty(RefreshToken);
        }

        public static bool GetTokenId(string token)
        {
            token = token.Replace("Bearer", "").Trim();

            var handler = new JwtSecurityTokenHandler();
            var webToken = handler.ReadToken(token) as JwtSecurityToken;

            Id = webToken.Claims.First(claim => claim.Type == "_id").Value.ToString();

            return string.IsNullOrEmpty(Id);
        }
    }
}

