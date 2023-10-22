using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Service.DTOs.Auth;
public class RequestUseDevice
{
    [JsonProperty("_id"), Required]
    public string Id { get; set; }

    [JsonProperty("device_name"), Required]
    public string DeviceName { get; set; }

    [JsonProperty("imei"), Required]
    public string Imei { get; set; }
}
