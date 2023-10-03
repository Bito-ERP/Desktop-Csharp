using BitoDesktop.Domain.Entities.WarehouseP;
using BitoDesktop.Service.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.WarehouseP;

internal class CategoryResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("image")]
    public string Image { get; set; }
    [JsonPropertyName("item_count")]
    public int ItemCount { get; set; }
    [JsonPropertyName("child_count")]
    public int ChildCount { get; set; }
    [JsonPropertyName("parent")]
    public DataResponse Parent { get; set; }
    [JsonPropertyName("organization_ids")]
    public List<string> OrganizationIds { get; set; }

    public Category Get()
    {
        return new Category
        {
            Id = Id,
            Name = Name,
            ParentId = Parent?.Id,
            ParentName = Parent?.Name,
            Image = Image,
            ItemCount = ItemCount,
            ChildCount = ChildCount,
            OrganizationIds = OrganizationIds
        };
    }
}

