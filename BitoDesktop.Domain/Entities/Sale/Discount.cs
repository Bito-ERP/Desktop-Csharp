using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Sale;

public class Discount
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string ApplyType { get; set; }

    [Required]
    public float Value { get; set; }

    public string CurrencyId { get; set; }

    public string Image { get; set; }
}

