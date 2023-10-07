using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Finance;

public class RequestTaxCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("rate")]
    public float? Rate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("to_price")]
    public bool? ToPrice { get; set; }

    [JsonProperty("is_manual")]
    public bool? IsManual { get; set; }

    [JsonProperty("is_all")]
    public bool? IsAll { get; set; }

    [JsonProperty("is_all_categories")]
    public bool? IsAllCategories { get; set; }

    [JsonProperty("is_all_suppliers")]
    public bool? IsAllSuppliers { get; set; }

    [JsonProperty("category_ids")]
    public string[] CategoryIds { get; set; }

    [JsonProperty("supplier_ids")]
    public string[] SupplierIds { get; set; }

    [JsonProperty("item_added_ids")]
    public string[] AddedIds { get; set; }

    [JsonProperty("item_removed_ids")]
    public string[] RemovedIds { get; set; }
}
