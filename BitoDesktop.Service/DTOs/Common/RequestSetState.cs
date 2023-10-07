using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

public class RequestSetState
{
    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("uuid")]
    public string Uuid { get; set; }
}
