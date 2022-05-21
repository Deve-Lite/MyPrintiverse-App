namespace MyPrintiverse.AuthorizationModule.SignInPage;

public sealed record SignInData(string Email, string Password, string ConfirmPassword)
{
	public string Email { get; set; } = Email;
	public string Password { get; set; } = Password;
	public string ConfirmPassword { get; set; } = ConfirmPassword;
}