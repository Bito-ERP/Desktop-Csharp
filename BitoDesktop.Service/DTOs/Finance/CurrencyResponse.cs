using BitoDesktop.Domain.Entities.Finance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitoDesktop.Service.DTOs.Finance;

public class CurrencyResponse
{
    [JsonProperty("values")]
    public List<Value> Values { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("is_main")]
    public bool IsMain { get; set; }

    [JsonProperty("side")]
    public string Side { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }

    public Currency Get() => new()
    {
        Id = Id,
        Name = Name,
        Values = Values?.Select(v => new Currency.Value
        {
            Amount = v.Amount,
            ToCurrencyId = v.ToCurrencyId
        }
        ).ToList(),
        IsMain = IsMain,
        Side = Side,
        Symbol = string.IsNullOrWhiteSpace(Symbol) ? null : Symbol,
        UpdatedAt = DateTimeOffset.Parse(UpdatedAt)
    };


    public class Value
    {
        [JsonProperty("value")]
        public double Amount { get; set; }

        [JsonProperty("to_currency_id")]
        public string ToCurrencyId { get; set; }
    }
}
