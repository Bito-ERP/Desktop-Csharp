using BitoDesktop.Domain.Entities.WarehouseP;
using BitoDesktop.Service.DTOs.Common;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.WarehouseP;
internal class WarehouseResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("organization")]
    public DataResponse Organisation { get; set; }

    [JsonPropertyName("responsible_employee")]
    public UserResponse ResponsibleEmployee { get; set; }

    [JsonPropertyName("is_main")]
    public bool IsMain { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    public Warehouse Get()
    {
        return new Warehouse
        {
            Id = Id,
            Name = Name,
            OrganizationId = Organisation.Id,
            ResponsibleEmployeeId = ResponsibleEmployee.Id,
            IsMain = IsMain,
            Status = Status,
            Code = Code
        };
    }
}
