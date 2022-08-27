

namespace MyPrintiverse.FilamentsModule.Filaments;

/// <summary>
/// Filament model for storing filament data.
/// </summary>
public class Filament : BaseModel
{
    [JsonProperty("typeId")]
    public string TypeId { get; set; }

    [JsonProperty("brand")]
    public string Brand { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("colorHex")]
    public string ColorHex { get; set; }

    [JsonProperty("shortDescription")]
    public string Description { get; set; }

    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    [JsonProperty("nozzleTemperature")]
    public int NozzleTemperature { get; set; }

    [JsonProperty("bedTemperature")]
    public int BedTemperature { get; set; }

    [JsonProperty("coolingRate")]
    public int CoolingRate { get; set; }

    [JsonProperty("rating")]
    public int Rating { get; set; }
}

