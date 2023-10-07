using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Auth;

public class UsernameResponse
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

