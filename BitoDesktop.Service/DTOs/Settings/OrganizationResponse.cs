using BitoDesktop.Domain.Entities.Settings;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings;

public class OrganizationResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("currency_id")]
    public string CurrencyId { get; set; }

    public Organization Get()
    {
        return new Organization
        {
            Id = Id,
            Name = Name,
            CurrencyId = CurrencyId
        };
    }
}
