namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// Base viewmodel for any page.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Default delay in milliseconds.
    /// </summary>
    protected const int DELAY = 500;

    /// <summary>
    /// Standard functions to do when page appears.
    /// </summary>
    protected internal virtual void OnAppearing()
    {
        IsBusy = false;
    }

    private bool isBusy;
    /// <summary>
    /// Terminate if any action started on page.
    /// </summary>
    protected bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

    private bool iRefreshing;
    /// <summary>
    /// Terminate if collection refresh started on page.
    /// </summary>
    protected bool IsRefreshing { get => iRefreshing; set => SetProperty(ref iRefreshing, value); }


    /// <summary>
    /// Terminate if action can start on page.
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    protected virtual bool CanExecute(object arg) 
    {
        if (IsBusy)
            return false;

        IsBusy = true;

        return true;
    }

    /// <summary>
    /// Terminate if action can start on page.
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    protected virtual bool CanExecute<T>(T arg)
    {
        if (IsBusy)
            return false;

        IsBusy = true;

        return true;
    }


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
    /// Creates exception message.
    /// </summary>
    /// <typeparam name="T">Class type where exception is thrown.</typeparam>
    /// <param name="propertyName"></param>
    /// <returns>exception message.</returns>
    protected string GetExceptionMessage<T>(string propertyName) => $"{nameof(T)} - {propertyName}";

}
