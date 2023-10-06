using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class CurrencySettingsResonse
    {
        [JsonProperty("apply_in_main")]
        public bool ApplyInMain { get; set; }
    }
}
