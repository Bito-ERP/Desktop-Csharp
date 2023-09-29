using BitoDesktop.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings;

internal class PaymentMethodResponse
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

