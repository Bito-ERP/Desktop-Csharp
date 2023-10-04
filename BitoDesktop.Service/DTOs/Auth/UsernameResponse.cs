using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Auth;

public class UsernameResponse
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

