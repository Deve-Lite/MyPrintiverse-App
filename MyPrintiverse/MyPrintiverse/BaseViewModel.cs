namespace MyPrintiverse;

/// <summary>
/// Base viewmodel for any page.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
	/// <summary>
	/// Default delay in milliseconds.
	/// </summary>
	protected const int DELAY = 500;

	protected internal virtual void OnAppearing()
	{
		IsBusy = false;
	}

	/// <summary>
	/// Terminate if any action started on page.
	/// </summary>
	protected bool IsBusy
	{
		get => _isBusy; 
		set => SetProperty(ref _isBusy, value);
	}
	private bool _isBusy;

	/// <summary>
	/// Store page title name.
	/// </summary>
	public string Title
	{
		get => _title; 
		set => SetProperty(ref _title, value);
	}
	private string _title;

	public event PropertyChangedEventHandler PropertyChanged;

	/// <summary>
	/// Standard method for notifying view when property value has changed.
	/// </summary>
	/// <param name="propertyName"></param>
	protected virtual void OnPropertyChanged(string propertyName = null)
	{
		var handler = PropertyChanged;

		handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>
	/// Check if command can be executed.
	/// </summary>
	/// <returns><see langword="true" /> if command can be executed, otherwise <see langword="false" /></returns>
	protected bool CanExecute(object obj) => !IsBusy;

	/// <summary>
	/// Method for notifying view when any value has changed, with possibility to take action when value changed.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="backingStore"></param>
	/// <param name="value"></param>
	/// <param name="propertyName"></param>
	/// <param name="onChanged"></param>
	/// <returns></returns>
	protected virtual bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(backingStore, value))
			return false;

		onChanged?.Invoke();
		backingStore = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	/// <summary>
	/// Standard alert to get true/false value from user.
	/// </summary>
	/// <param name="title"></param>
	/// <returns></returns>
	protected async Task<bool> GetBoolFromUser(string title, string message)
	{
		IsBusy = true;

		var value = await Shell.Current.DisplayAlert(title, message, "Yes", "No");

		IsBusy = false;
		return value;
	}

	protected void ExecuteBlockade(Action act)
	{
		IsBusy = true;

		act();

		IsBusy = false;
	}

	protected async Task ExecuteBlockade(Func<Task> act)
	{
		IsBusy = true;

		await act();

		IsBusy = false;
	}
}