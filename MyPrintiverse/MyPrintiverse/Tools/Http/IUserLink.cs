namespace MyPrintiverse.Tools.Http;

public interface IUserLink
{
	public string GetUser();
	public string GetUserById(string userId);
	public string ModifyUser();
	public string DeleteUser();
}