using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace BitoDesktop.Service.DTOs.Sale;

internal class RequestDiscountCU
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("apply_type")]
    public string ApplyType { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("currency_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string? CurrencyId { get; set; }

}
