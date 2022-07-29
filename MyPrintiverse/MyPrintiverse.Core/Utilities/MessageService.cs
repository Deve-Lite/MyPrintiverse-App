namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class MessageService : IMessageService
{
	private readonly Page _mainPage;
		
	public MessageService()
	{
		//_mainPage = Application.Current?.MainPage ?? throw new ArgumentNullException($"Cannot create {nameof(MessageService)} whene MainPage is not set.");
	}

	public async Task ShowErrorAsync() => await ShowAlertAsync("Error", "Something went wrong.");

	public async Task ShowAlertAsync(string title, string message, string ok = "Ok")
	{
		await Application.Current.MainPage.DisplayAlert(title, message, ok);
	}

	public async Task<bool> ShowSelectAlertAsync(string title, string message, string accept = "Accept", string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent)
	{
		return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
	}

	public async Task<string> ShowActionSheetAsync(string title, string cancel = "Cancel", string delete = "Delete", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons)
	{
		return await Application.Current.MainPage.DisplayActionSheet(title, cancel, delete, flowDirection, buttons);
	}

	public async Task<TEnum> ShowActionSheetAsync<TEnum>(string title, string cancel = "Cancel") where TEnum : struct, Enum
	{
		var result = await Application.Current.MainPage.DisplayActionSheet(title, cancel, null, Enum.GetValues<TEnum>().Cast<string>().ToArray());

		return await Task.Run(() => Enum.Parse<TEnum>(result));
	}

	public async Task<string> ShowPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
	{
		return await Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
	}
}