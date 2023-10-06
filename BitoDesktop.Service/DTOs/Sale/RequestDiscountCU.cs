using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Sale;

public class RequestDiscountCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("apply_type")]
    public string ApplyType { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("currency_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string CurrencyId { get; set; }

}
