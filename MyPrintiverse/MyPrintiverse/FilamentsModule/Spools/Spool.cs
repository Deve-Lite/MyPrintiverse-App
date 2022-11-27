
namespace MyPrintiverse.FilamentsModule.Spools;


/// <summary>
/// Filament roll model for storing filament roll data.
/// </summary>
public class Spool : BaseModel
{
    [JsonProperty("filamentId")]
    public string FilamentId { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }


    [JsonProperty("standardWeight")]
    public double StandardWeight { get; set; }
    [JsonProperty("leftWeight")]
    public double AvaliableWeight { get; set; }

    [JsonProperty("cost")]
    public double Cost { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }


    [JsonProperty("isFinished")]
    public bool IsFinished { get; set; }
    [JsonProperty("isSample")]
    public bool IsOnSpool { get; set; }

}