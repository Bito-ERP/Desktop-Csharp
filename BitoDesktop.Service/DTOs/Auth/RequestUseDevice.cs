using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;
internal class RequestUseDevice
{
    [JsonProperty("_id"), Required]
    public string Id { get; set; }

    [JsonProperty("device_name"), Required]
    public string DeviceName { get; set; }

    [JsonProperty("imei"), Required]
    public string Imei { get; set; }
}
