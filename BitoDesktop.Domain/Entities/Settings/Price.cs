using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Settings;

public class Price
{
    [Required]
    public string Id { get; set; }
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public string ShortName { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    [Required]
    public string Type { get; set; }

    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }

    [Required]
    public string ApplyType { get; set; }

    public double? MinSaleAmount { get; set; }
    [Required]
    public bool IsMain { get; set; }
    [Required]
    public bool CanBeUpdated { get; set; }
    public List<string> Employees { get; set; }
}
