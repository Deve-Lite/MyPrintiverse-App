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
    protected const int DELAY = 150;

    #endregion

    public virtual void OnAppearing() 
	{
        IsEnabled = true;
        IsBusy = false;
        IsRunning = false;
    }

    #region Properties

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
    #endregion

    #region Methods
    /// <summary>
    /// Check if command can be executed.
    /// </summary>
    /// <returns><see langword="true" /> if command can be executed, otherwise <see langword="false" /></returns>
    protected bool CanExecute() => !IsBusy;
    protected bool CanExecute(object obj) => !IsBusy;

	/// <summary>
	/// Performs GoToAsync action with specified route.
	/// </summary>
	/// <param name="route"></param>
	/// <returns></returns>
	protected virtual async Task OpenPage(string route, bool animated = true) => await Shell.Current.GoToAsync(route, animated);

    /// <summary>
    /// Performs GoToAsync action with specified route.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected virtual async Task OpenPage(Type page, bool animated = true) => await Shell.Current.GoToAsync(page.Name, animated);

    /// <summary>
    /// Performs GoToAsync action with specified route.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task OpenPage<T>(bool animated = true) => await Shell.Current.GoToAsync(typeof(T).Name, animated);


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