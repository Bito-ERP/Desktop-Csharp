using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.WarehouseP;

public class RequestCategoryCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("parent_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string ParentId { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }
}

