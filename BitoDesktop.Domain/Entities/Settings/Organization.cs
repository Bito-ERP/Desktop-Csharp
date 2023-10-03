using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Settings;

public class Organization
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string CurrencyId { get; set; }
}
