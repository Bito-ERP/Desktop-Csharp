using BitoDesktop.Domain.Entities.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
