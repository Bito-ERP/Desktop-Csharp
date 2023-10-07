using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class ScaleResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

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

        public Scale Get()
        {
            return new Scale
            {
                Id = Id,
                OrganizationId = OrganizationId,
                Type = Type,
                SkuCount = SkuCount,
                SumCheckIndex = SumCheckIndex,
                PriceCount = PriceCount,
                WeightCount = WeightCount,
                DepartmentCode = DepartmentCode,
                CountAfterDot = CountAfterDot
            };
        }
    }
}
