using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;

internal class UsernameResponse
{
    [JsonProperty("username")]
    public string Username { get; set; }
    [JsonProperty("is_active")]
    public string IsActive { get; set; }
    [JsonProperty("has_access")]
    public string HasAccess { get; set; }
    [JsonProperty("is_blocked")]
    public string IsBlocked { get; set; }
}

