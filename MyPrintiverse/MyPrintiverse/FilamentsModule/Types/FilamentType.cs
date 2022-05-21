namespace MyPrintiverse.FilamentsModule.Types;

/// <summary>
/// Filament model for storing data about type of filament.
/// </summary>
public class FilamentType : BaseModel
{
    [JsonProperty("filamentId")]
    public string FilamentId { get; set; }


    [JsonProperty("fullName")]
    public string FullName { get; set; }
    [JsonProperty("shortName")]
    public string ShortName { get; set; }

    /* These 2 fields are formated to 'xxx-xxx °C' ex. 100-120 °C */
    [JsonProperty("nozzleTemperatureRange")]
    public string NozzleTemperatureRange { get; set; }
    [JsonProperty("coolingRange")]
    public string CoolingRange { get; set; }

    /* These field is formated to 'xx-xxx %' ex. 80-100 % ex. 40-90 %  */
    [JsonProperty("bedTemperatureRange")]
    public string BedTemperatureRange { get; set; }


    [JsonProperty("maxServiceTempearature")]
    public double MaxServiceTempearature { get; set; }
    [JsonProperty("density")]
    public double Density { get; set; }


    [JsonProperty("UVResistant")]
    public bool UVResistant { get; set; }
    [JsonProperty("isFoodFriendly")]
    public bool IsFoodFriendly { get; set; }
    [JsonProperty("isBio")]
    public bool IsBio { get; set; }
    [JsonProperty("isFlexible")]
    public bool IsFlexible { get; set; }
    [JsonProperty("isHeatedBedRequired")]
    public bool IsHeatedBedRequired { get; set; }


    [JsonProperty("description ")]
    public string Description { get; set; }
}

