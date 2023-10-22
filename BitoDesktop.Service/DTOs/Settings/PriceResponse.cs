using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitoDesktop.Service.DTOs.Settings;
public class PriceResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("currency_id")]
    public string CurrencyId { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("min_price")]
    public double? MinPrice { get; set; }

    [JsonProperty("max_price")]
    public double? MaxPrice { get; set; }

    [JsonProperty("apply_type")]
    public string ApplyType { get; set; } = "cash";

    [JsonProperty("min_sale_amount")]
    public double? MinSaleAmount { get; set; }

    [JsonProperty("is_main")]
    public bool IsMain { get; set; }

    [JsonProperty("has_access")]
    public bool HasAccess { get; set; } = false;

    [JsonProperty("employee_ids")]
    public List<string> Employees { get; set; } = new List<string>();

    [JsonProperty("can_be_updated")]
    public bool CanBeUpdated { get; set; }

    public Price Get()
    {
        return new Price
        {
            Id = Id,
            Code = Code,
            Name = Name,
            ShortName = ShortName,
            Status = Status,
            CurrencyId = CurrencyId,
            Type = Type,
            MinPrice = MinPrice,
            MaxPrice = MaxPrice,
            ApplyType = ApplyType,
            MinSaleAmount = MinSaleAmount,
            IsMain = IsMain,
            CanBeUpdated = CanBeUpdated,
            Employees = HasAccess ? Employees : null
        };
    }
}

