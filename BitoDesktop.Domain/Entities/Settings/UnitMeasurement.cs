using System.ComponentModel.DataAnnotations;

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