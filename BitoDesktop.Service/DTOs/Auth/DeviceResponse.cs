using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;

internal class DeviceResponse
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
