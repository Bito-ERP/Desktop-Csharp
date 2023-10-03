using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Finance;

internal class TaxResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rate")]
    public float Rate { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("to_price")]
    public bool ToPrice { get; set; }

    [JsonPropertyName("is_manual")]
    public bool IsManual { get; set; }

    [JsonPropertyName("is_all")]
    public bool IsAll { get; set; }

    [JsonPropertyName("is_all_categories")]
    public bool IsAllCategories { get; set; }

    [JsonPropertyName("is_all_suppliers")]
    public bool IsAllSuppliers { get; set; }

    [JsonPropertyName("category_ids")]
    public List<string> CategoryIds { get; set; }

    [JsonPropertyName("supplier_ids")]
    public List<string> SupplierIds { get; set; }

    [JsonPropertyName("item_added_ids")]
    public List<string> AddedItemIds { get; set; }

    [JsonPropertyName("item_removed_ids")]
    public List<string> RemovedItemIds { get; set; }

    [JsonPropertyName("organization_ids")]
    public List<string> OrganizationIds { get; set; }

    [JsonPropertyName("item_count")]
    public int ItemCount { get; set; }

    public Tax GetEntityTax() => new()
    {
        Id = Id,
        Name = Name,
        Rate = Rate,
        Type = Type,
        ToPrice = ToPrice,
        IsManual = IsManual,
        IsAll = IsAll,
        IsAllCategories = IsAllCategories,
        IsAllSuppliers = IsAllSuppliers,
        CategoryIds = CategoryIds,
        SupplierIds = SupplierIds,
        AddedItemIds = AddedItemIds,
        RemovedItemIds = RemovedItemIds,
        OrganizationIds = OrganizationIds,
        ItemCount = ItemCount
    };
}

