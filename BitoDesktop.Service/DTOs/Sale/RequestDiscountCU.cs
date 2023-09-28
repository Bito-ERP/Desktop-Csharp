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
    [JsonProperty("_id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("apply_type")]
    public string ApplyType { get; set; }

    [JsonProperty("value")]
    public float Value { get; set; }

    [JsonProperty("currency_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string? CurrencyId { get; set; }

}
