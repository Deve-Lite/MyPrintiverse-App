

namespace MyPrintiverse.Admin.Models
{
    public class ConfirmData
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
