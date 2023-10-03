using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;

internal class UsernameResponse
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("is_active")]
    public string IsActive { get; set; }
    [JsonPropertyName("has_access")]
    public string HasAccess { get; set; }
    [JsonPropertyName("is_blocked")]
    public string IsBlocked { get; set; }
}

