using System.Windows.Input;

namespace MyPrintiverse.Interfaces.Others;

/// <summary>
/// Interface for async command.
/// </summary>
public interface IAsyncCommand : ICommand
{
	/// <summary>
	/// Execute function.
	/// </summary>
	/// <returns></returns>
	Task ExecuteAsync();

	/// <summary>
	/// Raise a CanExecute change event.
	/// </summary>
	void RaiseCanExecuteChanged();
}

/// <summary>
/// Interface for async command with parameter.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncCommand<in T> : ICommand
{
	/// <summary>
	/// Execute function with item.
	/// </summary>
	/// <returns></returns>
	Task ExecuteAsync(T item);

	/// <summary>
	/// Raise a CanExecute change event.
	/// </summary>
	void RaiseCanExecuteChanged();
}