namespace MyPrintiverse.Core;

/// <summary>
/// Base model for data objects.
/// </summary>
public abstract class BaseModel : IBaseModel
{ 
	[PrimaryKey, JsonProperty("_id")]
	public string Id { get; set; }

	[JsonProperty("createdAt")]
	public DateTime CreatedAt { get; set; }
	[JsonProperty("updatedAt")]
	public DateTime EditedAt { get; set; }
}
