using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings;

public class RequestPriceCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("currency_id")]
    public string CurrencyId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}
