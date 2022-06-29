using FileSystem = Microsoft.Maui.Storage.FileSystem;

#nullable enable

namespace MyPrintiverse.BaseServices;

/// <summary>
/// Base service for device databases.
/// </summary>
public abstract class BaseService : IBaseService
{
	protected SQLiteAsyncConnection? _dataBaseConnection;

	public IConfigService<Config> ConfigService { get; }
	public ILogger Logger { get; }
	public IMessageService MessageService { get; }
	public ISession Session { get; }

	protected BaseService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session)
	{
		var configServiceExceptionMessage = GetExceptionMessage<BaseService>(nameof(configService));
		ConfigService = configService ?? throw new ArgumentNullException(configServiceExceptionMessage);

		var loggerExceptionMessage = GetExceptionMessage<BaseService>(nameof(logger));
		Logger = logger ?? throw new ArgumentNullException(loggerExceptionMessage);

		var messageServiceExceptionMessage = GetExceptionMessage<BaseService>(nameof(messageService));
		MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);

        var sessionExceptionMessage = GetExceptionMessage<BaseService>(nameof(session));
        Session = session ?? throw new ArgumentNullException(messageServiceExceptionMessage);
    }

	/// <summary>
	/// Try run operation (function) if it throw exception, function catch it if app is not in developer mode and will show error message.
	/// </summary>
	/// <param name="function"></param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	protected async Task<bool>TryRun(Func<Task<bool>> function)
	{
		try
		{
			return await function();
		}
		catch (Exception) when (!ConfigService.Config.IsDeveloperMode)
		{
			await MessageService.ShowErrorAsync();
			return await Task.Run(() => false);
		}
	}

	/// <summary>
	/// Creates exception message.
	/// </summary>
	/// <typeparam name="T">Class type where exception is thrown.</typeparam>
	/// <param name="propertyName"></param>
	/// <returns>exception message.</returns>
	protected string GetExceptionMessage<T>(string propertyName) => $"{nameof(T)} - {propertyName}";

	/// <summary>
	/// Creates and connects to <typeparamref name="TItem"/> database.
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	/// <param name="dbName">Database name</param>
	/// <returns><see langword="awaitable"/> <see cref="Task"/>.</returns>
	protected async Task ConnectToDatabase<TItem>(string dbName) where TItem : new()
	{
		if (_dataBaseConnection != null)
			return;

		var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
		_dataBaseConnection = new SQLiteAsyncConnection(dbPath);
		await _dataBaseConnection.CreateTableAsync<TItem>();
	}
}