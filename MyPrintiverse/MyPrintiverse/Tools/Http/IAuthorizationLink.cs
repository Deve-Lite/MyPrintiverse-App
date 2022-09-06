namespace MyPrintiverse.Tools.Http;

public interface IAuthorizationLink
{
	public string RegisterUser();
	public string LoginUser();
	public string LogoutUser();
	public string RenewToken();
	public string ChangePassword();
	public string ConfirmPassword();
	public string RestorePassword();
	public string ConfirmMail();
}