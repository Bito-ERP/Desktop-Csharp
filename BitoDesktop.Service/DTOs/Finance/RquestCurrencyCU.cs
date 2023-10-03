using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Finance;

internal class RequestCurrencyCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("side")]
    public string Side { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("values")]
    public List<Value> Values { get; set; }

    public class Value
    {
        [JsonPropertyName("to_currency_id")]
        public string ToCurrencyId { get; set; }

        [JsonPropertyName("value")]
        public float Amount { get; set; }
    }
}
