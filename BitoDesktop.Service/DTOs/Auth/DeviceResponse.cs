using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Auth;

public class DeviceResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("record_calls")]
    public bool RecordCalls { get; set; }

    [JsonProperty("multiple_user")]
    public bool MultipleUser { get; set; } = false;
}
