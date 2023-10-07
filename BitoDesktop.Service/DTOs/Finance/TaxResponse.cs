using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Finance;

public class TaxResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("rate")]
    public float Rate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("to_price")]
    public bool ToPrice { get; set; }

    [JsonProperty("is_manual")]
    public bool IsManual { get; set; }

    [JsonProperty("is_all")]
    public bool IsAll { get; set; }

    [JsonProperty("is_all_categories")]
    public bool IsAllCategories { get; set; }

    [JsonProperty("is_all_suppliers")]
    public bool IsAllSuppliers { get; set; }

    [JsonProperty("category_ids")]
    public List<string> CategoryIds { get; set; }

    [JsonProperty("supplier_ids")]
    public List<string> SupplierIds { get; set; }

    [JsonProperty("item_added_ids")]
    public List<string> AddedItemIds { get; set; }

    [JsonProperty("item_removed_ids")]
    public List<string> RemovedItemIds { get; set; }

    [JsonProperty("organization_ids")]
    public List<string> OrganizationIds { get; set; }

    [JsonProperty("item_count")]
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

