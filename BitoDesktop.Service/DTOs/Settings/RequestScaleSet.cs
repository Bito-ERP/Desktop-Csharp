using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class RequestScaleSet
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("sku_count")]
        public int SkuCount { get; set; }

        [JsonProperty("sum_check_index")]
        public int SumCheckIndex { get; set; }

        [JsonProperty("price_count")]
        public int PriceCount { get; set; }

        [JsonProperty("weight_count")]
        public int WeightCount { get; set; }

        [JsonProperty("department_code")]
        public int DepartmentCode { get; set; }

        [JsonProperty("count_after_dot")]
        public int CountAfterDot { get; set; }

        [JsonProperty("digits")]
        public List<char> Digits { get; set; }
    }
}
