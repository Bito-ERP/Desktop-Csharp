using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Finance;

internal class RequestTaxCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rate")]
    public float? Rate { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("to_price")]
    public bool? ToPrice { get; set; }

    [JsonPropertyName("is_manual")]
    public bool? IsManual { get; set; }

    [JsonPropertyName("is_all")]
    public bool? IsAll { get; set; }

    [JsonPropertyName("is_all_categories")]
    public bool? IsAllCategories { get; set; }

    [JsonPropertyName("is_all_suppliers")]
    public bool? IsAllSuppliers { get; set; }

    [JsonPropertyName("category_ids")]
    public string[]? CategoryIds { get; set; }

    [JsonPropertyName("supplier_ids")]
    public string[]? SupplierIds { get; set; }

    [JsonPropertyName("item_added_ids")]
    public string[]? AddedIds { get; set; }

    [JsonPropertyName("item_removed_ids")]
    public string[]? RemovedIds { get; set; }
}
