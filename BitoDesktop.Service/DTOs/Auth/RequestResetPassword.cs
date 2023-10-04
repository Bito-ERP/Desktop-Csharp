using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Auth;

public class RequestResetPassword
{
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("confirm_password")]
    public string ConfirmPassword { get; set; }

    [JsonPropertyName("otp")]
    public string Otp { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    [JsonPropertyName("device")]
    public string Device { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("product")]
    public string Product { get; set; }
}

