using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;

internal class DeviceResponse
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
