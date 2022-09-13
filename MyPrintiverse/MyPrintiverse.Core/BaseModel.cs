namespace MyPrintiverse.Core;

/// <summary>
/// Base model for data objects.
/// </summary>
public abstract class BaseModel : IBaseModel
{ 
	[PrimaryKey, JsonProperty("_id")]
	public string Id { get; set; }


	[JsonProperty("createdAt")]
	public long CreatedAtTicks { get; set; }
    [JsonProperty("updatedAt")]
    public long EditedAtTicks { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt => new DateTime(CreatedAtTicks);
    [JsonIgnore]
    public DateTime EditedAt => new DateTime(EditedAtTicks);
}
