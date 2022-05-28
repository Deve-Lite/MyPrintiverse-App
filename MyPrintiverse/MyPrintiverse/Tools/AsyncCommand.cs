using MyPrintiverse.Tools.Exceptions;
using System.Reflection;
using System.Windows.Input;

namespace MyPrintiverse.Tools
{
    /// <summary>
    /// AsyncCommand from MVVM helpers.
    /// https://github.com/jamesmontemagno/mvvm-helpers
    /// </summary> 
    
    /// <summary>
	/// Implementation of an Async Command
	/// </summary>
	public class AsyncCommand : IAsyncCommand
    {
        readonly Func<Task> execute;
        readonly Func<object, bool>? canExecute;
        readonly Action<Exception>? onException;
        readonly bool continueOnCapturedContext;
        readonly WeakEventManager weakEventManager = new WeakEventManager();

        /// <summary>
        /// Create a new AsyncCommand
        /// </summary>
        /// <param name="execute">Function to execute</param>
        /// <param name="canExecute">Function to call to determine if it can be executed</param>
        /// <param name="onException">Action callback when an exception occurs</param>
        /// <param name="continueOnCapturedContext">If the context should be captured on exception</param>
        public AsyncCommand(Func<Task> execute,
                            Func<object, bool>? canExecute = null,
                            Action<Exception>? onException = null,
                            bool continueOnCapturedContext = false)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
            this.onException = onException;
            this.continueOnCapturedContext = continueOnCapturedContext;
        }

        /// <summary>
        /// Event triggered when Can Excecute changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { weakEventManager.AddEventHandler(value); }
            remove { weakEventManager.RemoveEventHandler(value); }
        }

        /// <summary>
        /// Invoke the CanExecute method and return if it can be executed.
        /// </summary>
        /// <param name="parameter">Parameter to pass to CanExecute.</param>
        /// <returns>If it can be executed.</returns>
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Execute the command async.
        /// </summary>
        /// <returns>Task of action being executed that can be awaited.</returns>
        public Task ExecuteAsync() => execute();

        /// <summary>
        /// Raise a CanExecute change event.
        /// </summary>
        public void RaiseCanExecuteChanged() => weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));

        #region Explicit implementations
        void ICommand.Execute(object parameter) => ExecuteAsync().SafeFireAndForget(onException, continueOnCapturedContext);
        #endregion
    }
    /// <summary>
    /// Implementation of a generic Async Command
    /// </summary>
    public class AsyncCommand<T> : IAsyncCommand<T>
    {

        readonly Func<T, Task> execute;
        readonly Func<object, bool>? canExecute;
        readonly Action<Exception>? onException;
        readonly bool continueOnCapturedContext;
        readonly WeakEventManager weakEventManager = new WeakEventManager();

        /// <summary>
        /// Create a new AsyncCommand
        /// </summary>
        /// <param name="execute">Function to execute</param>
        /// <param name="canExecute">Function to call to determine if it can be executed</param>
        /// <param name="onException">Action callback when an exception occurs</param>
        /// <param name="continueOnCapturedContext">If the context should be captured on exception</param>
        public AsyncCommand(Func<T, Task> execute,
                            Func<object, bool>? canExecute = null,
                            Action<Exception>? onException = null,
                            bool continueOnCapturedContext = false)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
            this.onException = onException;
            this.continueOnCapturedContext = continueOnCapturedContext;
        }

        /// <summary>
        /// Event triggered when Can Excecute changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { weakEventManager.AddEventHandler(value); }
            remove { weakEventManager.RemoveEventHandler(value); }
        }

        /// <summary>
        /// Invoke the CanExecute method and return if it can be executed.
        /// </summary>
        /// <param name="parameter">Parameter to pass to CanExecute.</param>
        /// <returns>If it can be executed</returns>
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Execute the command async.
        /// </summary>
        /// <returns>Task that is executing and can be awaited.</returns>
        public Task ExecuteAsync(T parameter) => execute(parameter);

        /// <summary>
        /// Raise a CanExecute change event.
        /// </summary>
        public void RaiseCanExecuteChanged() => weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));

        #region Explicit implementations

        void ICommand.Execute(object parameter)
        {
            if (CommandUtils.IsValidCommandParameter<T>(parameter))
                ExecuteAsync((T)parameter).SafeFireAndForget(onException, continueOnCapturedContext);

        }
        #endregion
    }

    /// <summary>
    /// Extension Utils
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Task extension to add a timeout.
        /// </summary>
        /// <returns>The task with timeout.</returns>
        /// <param name="task">Task.</param>
        /// <param name="timeoutInMilliseconds">Timeout duration in Milliseconds.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async static Task<T> WithTimeout<T>(this Task<T> task, int timeoutInMilliseconds)
        {
            var retTask = await Task.WhenAny(task, Task.Delay(timeoutInMilliseconds))
                .ConfigureAwait(false);

#pragma warning disable CS8603 // Possible null reference return.
            return retTask is Task<T> ? task.Result : default;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Task extension to add a timeout.
        /// </summary>
        /// <returns>The task with timeout.</returns>
        /// <param name="task">Task.</param>
        /// <param name="timeout">Timeout Duration.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Task<T> WithTimeout<T>(this Task<T> task, TimeSpan timeout) =>
            WithTimeout(task, (int)timeout.TotalMilliseconds);

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
}
