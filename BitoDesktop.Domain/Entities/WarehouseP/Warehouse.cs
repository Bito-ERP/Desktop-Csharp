using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.WarehouseP;

public class Warehouse
{
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string ResponsibleEmployeeId { get; set; }

    [Required]
    public bool IsMain { get; set; }

    [Required]
    public string Status { get; set; }

    public string Code { get; set; }
}


