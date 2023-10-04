using BitoDesktop.Domain.Entities.Settings;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings;

public class PaymentMethodResponse
{
    [Required]
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    [JsonPropertyName("is_enabled")]
    public bool IsEnabled { get; set; }

    public PaymentMethod Get() => new()
    {
        Id = Id,
        Name = Name,
        IsEnabled = IsEnabled
    };
}

