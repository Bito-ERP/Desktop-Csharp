using BitoDesktop.Domain.Entities.WarehouseP;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.WarehouseP;
public class WarehouseResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("organization")]
    public DataResponse Organisation { get; set; }

    [JsonProperty("responsible_employee")]
    public UserResponse ResponsibleEmployee { get; set; }

    [JsonProperty("is_main")]
    public bool IsMain { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("code")]
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
