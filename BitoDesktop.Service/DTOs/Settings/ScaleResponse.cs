using BitoDesktop.Domain.Entities.Settings;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class ScaleResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

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
