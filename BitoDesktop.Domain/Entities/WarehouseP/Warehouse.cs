using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


