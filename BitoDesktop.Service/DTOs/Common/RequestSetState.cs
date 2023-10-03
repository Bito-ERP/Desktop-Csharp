using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;

internal class RequestSetState
{
    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
}
