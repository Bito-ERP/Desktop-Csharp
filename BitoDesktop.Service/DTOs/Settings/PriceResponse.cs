using BitoDesktop.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings;
internal class PriceResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("currency_id")]
    public string CurrencyId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("min_price")]
    public double? MinPrice { get; set; }

    [JsonPropertyName("max_price")]
    public double? MaxPrice { get; set; }

    [JsonPropertyName("apply_type")]
    public string ApplyType { get; set; } = "cash";

    [JsonPropertyName("min_sale_amount")]
    public double? MinSaleAmount { get; set; }

    [JsonPropertyName("is_main")]
    public bool IsMain { get; set; }

    [JsonPropertyName("has_access")]
    public bool HasAccess { get; set; } = false;

    [JsonPropertyName("employee_ids")]
    public List<string> Employees { get; set; } = new List<string>();

    [JsonPropertyName("can_be_updated")]
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

