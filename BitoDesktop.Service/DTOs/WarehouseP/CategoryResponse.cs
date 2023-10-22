using BitoDesktop.Domain.Entities.WarehouseP;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitoDesktop.Service.DTOs.WarehouseP;

public class CategoryResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("image")]
    public string Image { get; set; }
    [JsonProperty("item_count")]
    public int ItemCount { get; set; }
    [JsonProperty("child_count")]
    public int ChildCount { get; set; }
    [JsonProperty("parent")]
    public DataResponse Parent { get; set; }
    [JsonProperty("organization_ids")]
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

