namespace MyPrintiverse.Authorization.ChangePassword;

public interface IChangePasswordService : IBaseService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="oldPassword"></param>
	/// <param name="newPassword"></param>
	/// <param name="confirmPassword"></param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, string confirmPassword);
}