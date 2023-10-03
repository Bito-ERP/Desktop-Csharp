using BitoDesktop.Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Finance;

internal class CurrencyResponse
{
    [JsonPropertyName("values")]
    public List<Value> Values { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("is_main")]
    public bool IsMain { get; set; }

    [JsonPropertyName("side")]
    public string Side { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("updated_at")]
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
        [JsonPropertyName("value")]
        public double Amount { get; set; }

        [JsonPropertyName("to_currency_id")]
        public string ToCurrencyId { get; set; }
    }
}
