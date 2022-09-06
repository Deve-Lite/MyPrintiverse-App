using System.Reflection;
using System.Windows.Input;
using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Utilities;

[Obsolete]
public class AsyncCommand : IAsyncCommand
{
	private readonly Func<Task> _execute;
	private readonly Func<object, bool>? _canExecute;
	private readonly Action<Exception>? _onException;
	private readonly bool _continueOnCapturedContext;
	private readonly WeakEventManager _weakEventManager = new();
	private readonly Func<Func<Task>, Task>? _shellExecute;

	/// <summary>
	/// Create a new AsyncCommand
	/// </summary>
	/// <param name="execute">Function to _execute</param>
	/// <param name="canExecute">Function to call to determine if it can be executed</param>
	/// <param name="onException">Action callback when an exception occurs</param>
	/// <param name="continueOnCapturedContext">If the context should be captured on exception</param>
	/// <param name="shellExecute">Function to execute something before or/and after execution.</param>
	public AsyncCommand(Func<Task> execute,
		Func<object, bool>? canExecute = null,
		Action<Exception>? onException = null,
		bool continueOnCapturedContext = false,
		Func<Func<Task>, Task>? shellExecute = null)
	{
		_shellExecute = shellExecute;
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		_canExecute = canExecute;
		_onException = onException;
		_continueOnCapturedContext = continueOnCapturedContext;
	}

	/// <summary>
	/// Event triggered when Can Execute changes.
	/// </summary>
	public event EventHandler? CanExecuteChanged
	{
		add => _weakEventManager.AddEventHandler(value);
		remove => _weakEventManager.RemoveEventHandler(value);
	}

	/// <summary>
	/// Invoke the CanExecute method and return if it can be executed.
	/// </summary>
	/// <param name="parameter">Parameter to pass to CanExecute.</param>
	/// <returns>If it can be executed.</returns>
	public bool CanExecute(object? parameter)
	{
		if (parameter is not null)
			return _canExecute?.Invoke(parameter) ?? true;

		return false;
	}

	/// <summary>
	/// Execute the command async.
	/// </summary>
	/// <returns>Task of action being executed that can be awaited.</returns>
	public Task ExecuteAsync() => _shellExecute is not null ? _shellExecute(_execute) : _execute();

	/// <summary>
	/// Raise a CanExecute change event.
	/// </summary>
	public void RaiseCanExecuteChanged() => _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));

	#region Explicit implementations
	void ICommand.Execute(object? parameter) => ExecuteAsync().SafeFireAndForget(_onException, _continueOnCapturedContext);
	#endregion
}

[Obsolete]
public class AsyncCommand<T> : IAsyncCommand<T>
{
	private readonly Func<T, Task> _execute;
	private readonly Func<object, bool>? _canExecute;
	private readonly Action<Exception>? _onException;
	private readonly bool _continueOnCapturedContext;
	private readonly WeakEventManager _weakEventManager = new();
    private readonly Func<Func<T, Task>, T, Task>? _shellExecute;

    /// <summary>
	/// Create a new AsyncCommand.
	/// </summary>
	/// <param name="execute">Function to _execute</param>
	/// <param name="canExecute">Function to call to determine if it can be executed.</param>
	/// <param name="onException">Action callback when an exception occurs.</param>
	/// <param name="continueOnCapturedContext">If the context should be captured on exception.</param>
	/// <param name="shellExecute">Function to execute something before or/and after execution.</param>
	public AsyncCommand(Func<T, Task> execute,
		Func<object, bool>? canExecute = null,
		Action<Exception>? onException = null,
		bool continueOnCapturedContext = false,
		Func<Func<T, Task>, T, Task>? shellExecute = null)
	{
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		_canExecute = canExecute;
		_onException = onException;
		_continueOnCapturedContext = continueOnCapturedContext;
		_shellExecute = shellExecute;
	}

	/// <summary>
	/// Event triggered when Can Execute changes.
	/// </summary>
	public event EventHandler? CanExecuteChanged
	{
		add => _weakEventManager.AddEventHandler(value);
		remove => _weakEventManager.RemoveEventHandler(value);
	}

	/// <summary>
	/// Invoke the CanExecute method and return if it can be executed.
	/// </summary>
	/// <param name="parameter">Parameter to pass to CanExecute.</param>
	/// <returns>If it can be executed</returns>
	public bool CanExecute(object? parameter)
    {
        if (parameter is not null)
            return _canExecute?.Invoke(parameter) ?? true;

        return false;
    }

    /// <summary>
    /// Execute the command async.
    /// </summary>
    /// <returns>Task that is executing and can be awaited.</returns>
    public Task ExecuteAsync(T parameter) => _shellExecute is not null ? _shellExecute(_execute, parameter) : _execute(parameter);

    /// <summary>
    /// Raise a CanExecute change event.
    /// </summary>
    public void RaiseCanExecuteChanged() => _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));

	#region Explicit implementations

	void ICommand.Execute(object? parameter)
	{
		if (CommandUtils.IsValidCommandParameter<T>(parameter))
			ExecuteAsync((T)parameter).SafeFireAndForget(_onException, _continueOnCapturedContext);
	}

	#endregion
}

/// <summary>
/// Extension Utils.
/// </summary>
public static class AsyncCommandUtils
{
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
	/// <summary>
	/// Attempts to await on the task and catches exception
	/// </summary>
	/// <param name="task">Task to execute</param>
	/// <param name="onException">What to do when method has an exception</param>
	/// <param name="continueOnCapturedContext">If the context should be captured.</param>
	public static async void SafeFireAndForget(this Task task, Action<Exception>? onException = null, bool continueOnCapturedContext = false)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
	{
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext);
		}
		catch (Exception ex) when (onException != null)
		{
			onException.Invoke(ex);
		}
	}
}

internal static class CommandUtils
{
	internal static bool IsValidCommandParameter<T>(object o)
	{
		bool valid;
		if (o != null)
		{
			// The parameter isn't null, so we don't have to worry whether null is a valid option
			valid = o is T;

			if (!valid)
				throw new InvalidCommandParameterException(typeof(T), o.GetType());

			return valid;
		}

		var t = typeof(T);

		// The parameter is null. Is T Nullable?
		if (Nullable.GetUnderlyingType(t) != null)
		{
			return true;
		}

		// Not a Nullable, if it's a value type then null is not valid
		valid = !t.GetTypeInfo().IsValueType;

		if (!valid)
			throw new InvalidCommandParameterException(typeof(T));

		return valid;
	}
}