namespace MyPrintiverse.BaseServices.Item;

/// <summary>
/// Base interface for Internet Service 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IServerItemService<T>
{

	/* Tutaj ewentualny problem z tym co bedziemy zwracać -> najprawdopodobniej trzeba bedzie inaczej parsować dane i zwracać nasz Response a nie RestResponse */
	/* isFirst -> determinuje czy to bylo pierwsze czy drugie zapytanie (jezeli error z tokenem to ponawaimy zapytanie inaczej zapytanie nie udane ) */

	/// <summary>
	/// Returns response with data about item specified with objectId (if succesfull).
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<RestResponse<T>> GetItemAsync(string objectId);
	/// <summary>
	/// Returns response with items (if succesfull).
	/// </summary>
	/// <returns></returns>
	Task<RestResponse<IEnumerable<T>>> GetItemsAsync();

	/// <summary>
	/// Adds item to database and returns if action was succesfull.
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task<bool> AddItemAsync(T item);

	/// <summary>
	/// Updates item to database and returns if action was succesfull.
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task<bool> UpdateItemAsync(T item);

	/// <summary>
	/// Deletes item specified by objectId and returns if action was succesfull.
	/// </summary>
	/// <param name="objectId"></param>
	/// <returns></returns>
	Task<bool> DeleteItemAsync(string objectId);

	/// <summary>
	/// Deletes all items and returns if action was succesfull.
	/// </summary>
	/// <returns></returns>
	Task<bool> DeleteAllAsync();
}