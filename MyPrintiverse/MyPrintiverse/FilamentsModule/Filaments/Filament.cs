

namespace MyPrintiverse.FilamentsModule.Filaments;

/// <summary>
/// Filament model for storing filament data.
/// </summary>
public class Filament : BaseModel
{
    [JsonProperty("filamentTypeId")]
    public string TypeId { get; set; }

    [JsonProperty("brand")]
    public string Brand { get; set; }

    [JsonProperty("colorName")]
    public string ColorName { get; set; }

    [JsonProperty("colorHex")]
    public string ColorHex { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    [JsonProperty("nozzleTemperature")]
    public int NozzleTemperature { get; set; }

    [JsonProperty("bedTemperature")]
    public int BedTemperature { get; set; }

    [JsonProperty("coolingTemperature")] // DO ZMIANY NA COOLING RATE U KAMILA
    public int CoolingRate { get; set; }

    [JsonProperty("rating")]
    public int Rating { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }
}

