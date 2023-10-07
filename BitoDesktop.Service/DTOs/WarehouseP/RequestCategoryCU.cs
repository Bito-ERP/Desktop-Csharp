using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.WarehouseP;

public class RequestCategoryCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("parent_id")]
    public string ParentId { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }
}

