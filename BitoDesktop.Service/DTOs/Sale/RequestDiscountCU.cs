using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Sale;

public class RequestDiscountCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("apply_type")]
    public string ApplyType { get; set; }

    [JsonProperty("value")]
    public float Value { get; set; }

    [JsonProperty("currency_id")]
    public string CurrencyId { get; set; }

}
