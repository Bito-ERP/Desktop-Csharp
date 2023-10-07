using BitoDesktop.Domain.Entities.Pos;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Pos;
public class PageResponse
{
    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public Page Get() => new()
    {
        Order = Order,
        Id = Id,
        OrganizationId = OrganizationId,
        Name = Name
    };
}
