
using MyPrintiverse.Base.Models;

namespace MyPrintiverse.FilamentsModule.Prints;

/// <summary>
/// Filament model for storing print data.
/// </summary>
public class Print : BaseModel
{
    [JsonProperty("weight")]
    public double Weight { get; set; }

    [JsonProperty("fileId")]
    public string FileId { get; set; }
    [JsonProperty("printerId")]
    public string PrinterId { get; set; }

    [JsonProperty("Rating")]
    public int Rating { get; set; }

    [JsonProperty("isSuccesfull")]
    public bool IsSuccesfull { get; set; }

    [JsonProperty("printTime")]
    public double PrintTime { get; set; }
}
