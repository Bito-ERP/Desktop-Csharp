using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Auth;

public class RequestConfirm
{
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("otp")]
    public string Otp { get; set; }
}

