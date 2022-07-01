namespace MyPrintiverse.BaseServices.Item;

/// <summary>
/// Default interface for device service with standard CRUD operations.
/// </summary>
/// <typeparam name="Item"></typeparam>
public interface IDeviceItemService<Item>
{
	/// <summary>
	/// Returns sqlite db item by id.
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<Item> GetItemAsync(string objectId);
	/// <summary>
	/// Returns IEnumerable of items from sqlite db.
	/// </summary>
	/// <returns></returns>
	Task<IEnumerable<Item>> GetItemsAsync();

	/// <summary>
	/// Adds item to sqlite db.
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task AddItemAsync(Item item);

	/// <summary>
	/// Updates item in sqlite db. Should update only when exists! 
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task UpdateItemAsync(Item item);

	/// <summary>
	/// Deletes item by id in sqlite db.
	/// </summary>
	/// <param name="objectId"></param>
	/// <returns></returns>
	Task DeleteItemAsync(string objectId);
	/// <summary>
	/// Methods drops table (item database).
	/// </summary>
	/// <returns></returns>
	Task DeleteAllAsync();
}