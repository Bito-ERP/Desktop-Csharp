using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Settings;

public class UnitMeasurement
{
    [Required]
    public string Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int DecimalCount { get; set; }
    [Required]
    public string Status { get; set; }
}