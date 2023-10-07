using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

public class DataResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

