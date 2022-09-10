#nullable enable
using MyPrintiverse.Core.Utilities;
namespace MyPrintiverse.Core;

/// <summary>
/// Base service.
/// </summary>
public abstract class BaseService : IBaseService
{
	public IConfigService<Config> ConfigService { get; }
	public IMessageService MessageService { get; }
	public ISession Session { get; }

	protected BaseService(IConfigService<Config> configService, IMessageService messageService, ISession session)
	{
		ConfigService = configService;
		MessageService = messageService;
		Session = session;
	}

    /// <summary>
    /// Fills default fields of BaseModel.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void FillBaseData<T>(T item) where T : BaseModel
    {
        item.Id = ObjectId.GenerateNewId().ToString();
        item.EditedAt = DateTime.Now;
        item.CreatedAt = DateTime.Now;
    }
}