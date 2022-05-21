
/// <inheritdoc />
namespace MyPrintiverse.Core.Utilities;

public class MessageService : IMessageService
{
	private readonly Page _mainPage;
		
	public MessageService()
	{
		_mainPage = Application.Current?.MainPage;

		if (_mainPage == null)
			throw new ArgumentNullException($"Cannot create {nameof(MessageService)} whene MainPage is not set.");
	}

	/// <inheritdoc />
	public async Task ShowErrorAsync() => await ShowAlertAsync("Error", "Something went wrong.");

	/// <inheritdoc />
	public async Task ShowAlertAsync(string title, string message, string ok = "Ok")
	{
		await _mainPage.DisplayAlert(title, message, ok);
	}

	/// <inheritdoc />
	public async Task<bool> ShowSelectAlertAsync(string title, string message, string accept = "Accept", string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent)
	{
		return await _mainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
	}

	/// <inheritdoc />
	public async Task<string> ShowActionSheetAsync(string title, string cancel = "Cancel", string delete = "Delete", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons)
	{
		return await _mainPage.DisplayActionSheet(title, cancel, delete, flowDirection, buttons);
	}

	/// <inheritdoc />
	public async Task<TEnum> ShowActionSheetAsync<TEnum>(string title, string cancel = "Cancel") where TEnum : struct, Enum
	{
		var result = await _mainPage.DisplayActionSheet(title, cancel, null, Enum.GetValues<TEnum>().Cast<string>().ToArray());

		return await Task.Run(() => Enum.Parse<TEnum>(result));
	}

	/// <inheritdoc />
	public async Task<string> ShowPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
	{
		return await _mainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
	}
}