using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Auth;
internal class RequestUseDevice
{
    [JsonPropertyName("_id"), Required]
    public string Id { get; set; }

    [JsonPropertyName("device_name"), Required]
    public string DeviceName { get; set; }

    [JsonPropertyName("imei"), Required]
    public string Imei { get; set; }
}
