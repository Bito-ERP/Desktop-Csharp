using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Service.DTOs.Settings;

public class PaymentMethodResponse
{
    [Required]
    [JsonProperty("_id")]
    public string Id { get; set; }

    [Required]
    [JsonProperty("name")]
    public string Name { get; set; }

    [Required]
    [JsonProperty("is_enabled")]
    public bool IsEnabled { get; set; }

    public PaymentMethod Get() => new()
    {
        Id = Id,
        Name = Name,
        IsEnabled = IsEnabled
    };
}

