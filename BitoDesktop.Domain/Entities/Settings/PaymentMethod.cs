using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Settings;
public class PaymentMethod
{

    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public bool IsEnabled { get; set; }
}
