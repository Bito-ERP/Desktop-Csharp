using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Auth;

public class DeviceResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("record_calls")]
    public bool RecordCalls { get; set; }

    [JsonPropertyName("multiple_user")]
    public bool MultipleUser { get; set; } = false;
}
