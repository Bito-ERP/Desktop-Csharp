using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings;

public class OrganizationResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("currency_id")]
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
