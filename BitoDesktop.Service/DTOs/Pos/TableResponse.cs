using BitoDesktop.Domain.Entities.Pos;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Pos;
internal class TableResponse
{
    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public Table Get() => new()
    {
        Order = Order,
        Id = Id,
        OrganizationId = OrganizationId,
        Name = Name
    };
}
