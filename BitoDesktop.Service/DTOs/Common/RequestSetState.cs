using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Common;

internal class RequestSetState
{
    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}
