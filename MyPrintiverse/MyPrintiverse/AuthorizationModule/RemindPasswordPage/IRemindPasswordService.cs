namespace MyPrintiverse.AuthorizationModule.RemindPasswordPage;

/// <summary>
/// Service for <see cref="RemindPasswordViewModel"/>.
/// </summary>
public interface IRemindPasswordService : IBaseService
{
	/// <summary>
	/// Trigger API to send remind password code on user email.
	/// </summary>
	/// <param name="email">User email.</param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	public Task<bool> RemindPasswordAsync(string email);

	/// <summary>
	/// Check if provided code is valid.
	/// </summary>
	/// <param name="email">User email.</param>
	/// <param name="code">User remind password code.</param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	public Task<bool> RemindPasswordAsync(string email, string code);
}