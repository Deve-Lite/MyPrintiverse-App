using MyPrintiverse.Base.Models;

namespace MyPrintiverse.FilamentsModule.Statistics;

/// <summary>
/// Filament statistics model for storing statistics data.
/// </summary>
public class FilamentStatistics : BaseModel
{
    [JsonProperty("filamentId")]
    public string FilamentId { get; set; }

    [JsonProperty("totalAvaliableWeight")]
    public double TotalAvaliableWeight { get; set; }
    [JsonProperty("totalUsedWeight")]
    public double TotalUsedWeight { get; set; }

    [JsonProperty("lastPrintingTemperature")]
    public int LastNozzleTemperature { get; set; }
    [JsonProperty("lastBedTemperature")]
    public int LastBedTemperature { get; set; }
    [JsonProperty("lastCoolingSpeed")]
    public int LastCoolingSpeed { get; set; }

    [JsonProperty("overallRating")]
    public double Rating { get; set; }
}
