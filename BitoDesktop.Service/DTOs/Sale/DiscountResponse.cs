using BitoDesktop.Domain.Entities.Sale;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Sale;

public class DiscountResponse
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

    [JsonProperty("image")]
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
