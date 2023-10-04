using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;

public class DataResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

