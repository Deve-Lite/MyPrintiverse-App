
namespace MyPrintiverse.Tools.Http
{
    public class ApiLink : IApiLink
    {
	    private static ApiLink? _instance;
		private static ApiLink GetInstance(string apiBase) => _instance ??= new ApiLink(apiBase);

		private static string _apiBase = string.Empty;

		private ApiLink(string apiBase)
		{
			_apiBase = apiBase;
		}

		public static IAuthorizationLink GetAuthorizationLink(string apiBase) => GetInstance(apiBase);
	    public static IUserLink GetUserLink(string apiBase) => GetInstance(apiBase);
	    public static ISettingsLink GetSettingsLink(string apiBase) => GetInstance(apiBase);
	    public static IPingLink GetPingLink(string apiBase) => GetInstance(apiBase);

	    private static string CombineWithBase(string link) => $"{_apiBase}{link}";

		// Authorization
		public string RegisterUser() => CombineWithBase("/api/v1/auth/register");
	    public string LoginUser() => CombineWithBase("/api/v1/auth/login");
		public string LogoutUser() => CombineWithBase("/api/v1/auth/logout");
		public string RenewToken() => CombineWithBase("/api/v1/auth/token/renew");
	    public string ChangePassword() => CombineWithBase("/api/v1/auth/password/change");
	    public string ConfirmPassword() => CombineWithBase("/api/v1/auth/password/confirm");
	    public string RestorePassword() => CombineWithBase("/api/v1/auth/password/restore");
	    public string ConfirmMail() => CombineWithBase("/api/v1/auth/mail/confirm");

		// User
		public string GetUser() => CombineWithBase("/api/v1/users");
	    public string GetUserById(string userId) => CombineWithBase($"/api/v1/users/{userId}");
	    public string ModifyUser() => CombineWithBase("/api/v1/users");
	    public string DeleteUser() => CombineWithBase("/api/v1/users");

		// Settings
		public string GetUserSettings() => CombineWithBase("/api/v1/user-settings");
	    public string ModifyUserSettings() => CombineWithBase("/api/v1/user-settings");

		// Ping
		public string Ping() => CombineWithBase("/api/v1/ping");
	    public string PingWithPayload() => CombineWithBase("/api/v1/ping");
    }
}

