using BitoDesktop.Domain.Entities.Sale;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Sale;

public class DiscountResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("apply_type")]
    public string ApplyType { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("currency_id")]
    public string CurrencyId { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    public Discount Get() => new()
    {
        Id = Id,
        Name = Name,
        ApplyType = ApplyType,
        Value = Value,
        CurrencyId = ApplyType == "cash" ? CurrencyId : null,
        Image = Image
    };

}
