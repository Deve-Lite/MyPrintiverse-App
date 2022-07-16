namespace MyPrintiverse.Core;

/// <summary>
/// Base viewmodel for any page.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
	/// <summary>
	/// Default delay in milliseconds.
	/// </summary>
	protected const int DELAY = 500;

	public virtual void OnAppearing() => IsBusy = false;

	private bool _isBusy;

	/// <summary>
	/// Terminate if any action started on page.
	/// </summary>
	protected bool IsBusy
	{
		get => _isBusy; 
		set => SetProperty(ref _isBusy, value);
	}

	private bool _isRefreshing;

	/// <summary>
	/// Terminate if collection refresh started on page.
	/// </summary>
	protected bool IsRefreshing
	{
		get => _isRefreshing; 
		set => SetProperty(ref _isRefreshing, value);
	}

	/// <summary>
	/// Check if command can be executed.
	/// </summary>
	/// <returns><see langword="true" /> if command can be executed, otherwise <see langword="false" /></returns>
	protected bool CanExecute(object obj) => !IsBusy;

	/// <summary>
	/// Terminate if action can start on page.
	/// </summary>
	/// <param name="arg"></param>
	/// <returns></returns>
	protected virtual bool CanExecute<T>(T arg) => !IsBusy;
	 
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Standard method for notifying view when property value has changed.
	/// </summary>
	/// <param name="propertyName"></param>
	protected virtual void OnPropertyChanged(string? propertyName = null)
	{
		var handler = PropertyChanged;

		handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>
	/// Method for notifying view when any value has changed, with possibility to take action when value changed.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="backingStore"></param>
	/// <param name="value"></param>
	/// <param name="propertyName"></param>
	/// <param name="onChanged"></param>
	/// <returns></returns>
	protected virtual bool SetProperty<T>(ref T backingStore, T value, Action? onChanged = null, string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(backingStore, value))
			return false;

		onChanged?.Invoke();
		backingStore = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="act">Action to execute.</param>
	protected void ExecuteBlockade(Action act)
	{
		IsBusy = true;

		act();

		IsBusy = false;
	}

	/// <summary>
	/// Automatically change <see cref="IsBusy"/> execute <paramref name="act"/>.
	/// </summary>
	/// <param name="act">Action to execute.</param>
	protected async Task ExecuteBlockade(Func<Task> act)
	{
		IsBusy = true;

		await act();

		IsBusy = false;
	}
}