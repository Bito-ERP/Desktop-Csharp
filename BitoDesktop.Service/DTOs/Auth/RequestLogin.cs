using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Auth;

public class RequestLogin
{
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("pincode")]
    public string Pincode { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("brand")]
    public string Brand { get; set; }

    [JsonProperty("device")]
    public string Device { get; set; }

    [JsonProperty("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("product")]
    public string Product { get; set; }
}
