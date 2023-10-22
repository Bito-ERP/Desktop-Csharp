using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitoDesktop.Service.DTOs.Finance;

public class RequestCurrencyCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("side")]
    public string Side { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("values")]
    public List<Value> Values { get; set; }

    public class Value
    {
        [JsonProperty("to_currency_id")]
        public string ToCurrencyId { get; set; }

        [JsonProperty("value")]
        public float Amount { get; set; }
    }
}
