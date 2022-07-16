namespace MyPrintiverse.AuthorizationModule.ConfirmEmailPage;

/// <summary>
/// Service for managing <see cref="ConfirmEmailViewModel"/> data.
/// </summary>
public interface IConfirmEmailService : IBaseService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="email"></param>
	/// <param name="code"></param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	Task<bool> ConfirmEmailAsync(string email, string code);
}