using CommunityToolkit.Mvvm.ComponentModel;

namespace MyPrintiverse.Core;

/// <summary>
/// Base viewmodel for any page.
/// </summary>
public abstract partial class BaseViewModel : ObservableObject
{
    #region Const
    /// <summary>
    /// Default delay in milliseconds.
    /// </summary>
    protected const int DELAY = 500;

    #endregion

    public virtual void OnAppearing() 
	{
        IsEnabled = true;
        IsBusy = false;
        IsRunning = false;
    }

	/// <summary>
	/// Terminate if any action started on page.
	/// </summary>
	[ObservableProperty]
	private bool _isBusy;

	[ObservableProperty]
	private bool _isRefreshing;

	/// <summary>
	/// Terminate if loading action on page is started.
	/// </summary>
	[ObservableProperty]
	private bool _isRunning;

	/// <summary>
	/// Terminate if buttons on page are on.
	/// </summary>
	[ObservableProperty]
	private bool _isEnabled;

    /// <summary>
    /// Check if command can be executed.
    /// </summary>
    /// <returns><see langword="true" /> if command can be executed, otherwise <see langword="false" /></returns>
    protected bool CanExecute() => !IsBusy;
    protected bool CanExecute(object obj) => !IsBusy;

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

    /// <summary>
	///  Automatically change <see cref="IsBusy"/> execute <paramref name="act"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="act">Action to execute.</param>
	/// <param name="value"> Action parameter.</param>
	/// <returns></returns>
    protected async Task ExecuteBlockade<T>(Func<T, Task> act, T value)
    {
        IsBusy = true;

        await act(value);

        IsBusy = false;
    }

    /// <summary>
    ///  Automatically change <see cref="IsBusy"/> execute <paramref name="act"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="act">Action to execute.</param>
    /// <param name="value"> Action parameter.</param>
    /// <returns></returns>
    protected void ExecuteBlockade<T>(Action<T> act, T value)
    {
        IsBusy = true;

        act(value);

        IsBusy = false;
    }

    

	#region Exceptions Methods

	/// <summary>
	/// Performs GoToAsync action with specified route.
	/// </summary>
	/// <param name="route"></param>
	/// <returns></returns>
	protected virtual async Task OpenPage(string route) => await Shell.Current.GoToAsync(route, true);

	/// <summary>
	/// If other commands can't perform use this function to block action.
	/// </summary>
	/// <returns></returns>
	protected virtual bool AnyActionStartedCommand()
	{
		if (IsBusy)
			return true;

		IsBusy = true;
		return false;
	}

	/// <summary>
	/// Creates exception message.
	/// </summary>
	/// <typeparam name="T">Class type where exception is thrown.</typeparam>
	/// <param name="propertyName"></param>
	/// <returns>exception message.</returns>
	protected string GetExceptionMessage<T>(string propertyName) => $"{nameof(T)} - {propertyName}";

    #endregion
}