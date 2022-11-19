namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class MessageService : IMessageService
{
	private static Page? MainPage => Application.Current?.MainPage;

	public async Task ShowErrorAsync() => await ShowAlertAsync("Error", "Something went wrong.");

	public async Task ShowAlertAsync(string title, string message, string ok = "Ok")
	{
		if (MainPage is null)
			return;

		await MainPage.DisplayAlert(title, message, ok);
	}

	public async Task<bool> ShowSelectAlertAsync(string title, string message, string accept = "Accept", string cancel = "Cancel", FlowDirection flowDirection = FlowDirection.MatchParent)
	{
		if (MainPage is null)
			return await Task.Run(() => false);

        return await MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
	}

	public async Task<string> ShowActionSheetAsync(string title, string cancel = "Cancel", string delete = "Delete", FlowDirection flowDirection = FlowDirection.MatchParent, params string[] buttons)
	{
		if (MainPage is null)
			return await Task.Run(() => string.Empty);

		return await MainPage.DisplayActionSheet(title, cancel, delete, flowDirection, buttons);
	}

	/* Uwaga w enum musi wystapic opcja 'Cancel' na końcu!!!*/
	public async Task<TEnum> ShowActionSheetAsync<TEnum>(string title, string cancel = "Cancel") where TEnum : struct, Enum
	{
		if (MainPage is null)
			return await Task.Run(() => new TEnum());

		//To nie działa InvalidCastException
		var strOptions = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(x => x.ToString()).ToList();
		int last = strOptions.Count()-1;

        if (!(strOptions[last]=="Cancel"))
			throw new InvalidEnumArgumentException("Enum must have 'Cancel' option as last value.");

		var cancelOption = strOptions[last];

        strOptions.RemoveAt(last);

        var result = await MainPage.DisplayActionSheet(title, cancel, null, strOptions.ToArray());

        return await Task.Run(() => Enum.Parse<TEnum>(result == null? cancelOption : result));
	}

	public async Task<string> ShowPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "")
	{
		if (MainPage is null)
			return await Task.Run(() => string.Empty);

		return await MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
	}
}