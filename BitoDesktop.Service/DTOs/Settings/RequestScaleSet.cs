using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class RequestScaleSet
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("sku_count")]
        public int SkuCount { get; set; }

        [JsonPropertyName("sum_check_index")]
        public int SumCheckIndex { get; set; }

        [JsonPropertyName("price_count")]
        public int PriceCount { get; set; }

        [JsonPropertyName("weight_count")]
        public int WeightCount { get; set; }

        [JsonPropertyName("department_code")]
        public int DepartmentCode { get; set; }

        [JsonPropertyName("count_after_dot")]
        public int CountAfterDot { get; set; }

        [JsonPropertyName("digits")]
        public List<char> Digits { get; set; }
    }
}
