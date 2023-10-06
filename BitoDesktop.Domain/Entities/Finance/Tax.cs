using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Finance;

public class Tax
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public float Rate { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public bool ToPrice { get; set; }

    [Required]
    public bool IsManual { get; set; }

    [Required]
    public bool IsAll { get; set; }

    [Required]
    public bool IsAllCategories { get; set; }

    [Required]
    public bool IsAllSuppliers { get; set; }

    [Required]
    public int ItemCount { get; set; }

    public List<string> CategoryIds { get; set; }

    public List<string> SupplierIds { get; set; }

    public List<string> AddedItemIds { get; set; }

    public List<string> RemovedItemIds { get; set; }

    [Required]
    public List<string> OrganizationIds { get; set; }
}
