namespace BitoDesktop.Domain.Entities.Settings
{
    public class Scale
    {
        public string Id { get; set; }
        public string OrganizationId { get; set; }
        public int Type { get; set; }
        public int SkuCount { get; set; }
        public int SumCheckIndex { get; set; }
        public int PriceCount { get; set; }
        public int WeightCount { get; set; }
        public int DepartmentCode { get; set; }
        public int CountAfterDot { get; set; }
    }
}
