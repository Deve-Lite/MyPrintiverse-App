namespace MyPrintiverse.Interfaces;

/// <summary>
/// Base interface for Internet Service 
/// </summary>
/// <typeparam name="Model"></typeparam>
public interface IInternetItemAsyncService<Model>
{

	/* Tutaj ewentualny problem z tym co bedziemy zwracać -> najprawdopodobniej trzeba bedzie inaczej parsować dane i zwracać nasz Response a nie RestResponse */
	/* isFirst -> determinuje czy to bylo pierwsze czy drugie zapytanie (jezeli error z tokenem to ponawaimy zapytanie inaczej zapytanie nie udane ) */

	/// <summary>
	/// Returns response with data about item specified with objectId (if succesfull).
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<RestResponse<Model>> GetItemAsync(string objectId, bool isFirst);
	/// <summary>
	/// Returns response with items (if succesfull).
	/// </summary>
	/// <returns></returns>
	Task<RestResponse<IEnumerable<Model>>> GetItemsAsync(bool isFirst);

	/// <summary>
	/// Adds item to database and returns if action was succesfull.
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task<bool> AddItemAsync(Model item, bool isFirst);

	/// <summary>
	/// Updates item to database and returns if action was succesfull.
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	Task<bool> UpdateItemAsync(Model item, bool isFirst);

	/// <summary>
	/// Deletes item specified by objectId and returns if action was succesfull.
	/// </summary>
	/// <param name="objectId"></param>
	/// <returns></returns>
	Task<bool> DeleteItemAsync(string objectId, bool isFirst);

	/// <summary>
	/// Deletes all items and returns if action was succesfull.
	/// </summary>
	/// <returns></returns>
	Task<bool> DeleteAllAsync(bool isFirst);
}