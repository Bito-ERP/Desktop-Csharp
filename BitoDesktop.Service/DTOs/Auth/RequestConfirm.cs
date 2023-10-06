using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Auth;

public class RequestConfirm
{
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("otp")]
    public string Otp { get; set; }
}

