namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Service for creating pop-up windows.
/// </summary>
public interface IMessageService
{
	/// <summary>
	/// Show error on actual opened page.
	/// </summary>
	/// <returns><see cref="Task" /></returns>
	public Task ShowErrorAsync();

	/// <summary>
	/// Show alert on actual opened page.
	/// </summary>
	/// <param name="title">Alert window title.</param>
	/// <param name="message">Alert message.</param>
	/// <param name="ok">Close button text.</param>
	/// <returns><see cref="Task" /></returns>
	public Task ShowAlertAsync(string title, string message, string ok = "Ok");
		
	/// <summary>
	/// Show select window with two buttons <see langword="true" />/<see langword="false" /> on actual opened page.
	/// </summary>
	/// <param name="title">Select window title.</param>
	/// <param name="message">Select message.</param>
	/// <param name="accept">Button text which return <see langword="true" />.</param>
	/// <param name="cancel">Button text which return <see langword="false" />.</param>
	/// <param name="flowDirection"></param>
	/// <returns></returns>
	Task<bool> ShowSelectAlertAsync(string title, string message, string accept = "Accept",
		string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent);

	/// <summary>
	/// Show action sheet on actual opened page.
	/// </summary>
	/// <param name="title">Alert window title.</param>
	/// <param name="cancel">Button text which return <see langword="null" />.</param>
	/// <param name="delete"></param>
	/// <param name="flowDirection"></param>
	/// <param name="buttons"></param>
	/// <returns></returns>
	public Task<string> ShowActionSheetAsync(string title, string cancel = "Cancel", string delete = "Delete",
		FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons);

	/// <summary>
	/// Show alert on actual opened page.
	/// </summary>
	/// <typeparam name="TEnum">Enum type.</typeparam>
	/// <param name="title">Alert window title.</param>
	/// <param name="cancel">Button text which return <see langword="null" />.</param>
	/// <returns></returns>
	public Task<TEnum> ShowActionSheetAsync<TEnum>(string title, string cancel = "Cancel")
		where TEnum : struct, Enum;

	/// <summary>
	/// Show prompt on actual opened page.
	/// </summary>
	/// <param name="title">Prompt window title.</param>
	/// <param name="message">Prompt message.</param>
	/// <param name="accept">Button text which return value from prompt.</param>
	/// <param name="cancel">Button text which return <see langword="null" />.</param>
	/// <param name="placeholder"></param>
	/// <param name="maxLength"></param>
	/// <param name="keyboard"></param>
	/// <param name="initialValue"></param>
	/// <returns></returns>
	public Task<string> ShowPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", 
		string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "");
}