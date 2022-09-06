namespace MyPrintiverse.Authorization.SignIn;

public interface ISignInService : IBaseService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="user">User data.</param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	public Task<bool> SingIn(SignInData user);
}