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

public interface IBaseModel
{
	public string Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime EditedAt { get; set; }
}