using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Pos;

public class TicketItem
{
    public int Id { get; set; }

    [Required]
    public string ProductId { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public int BoxAmount { get; set; } // keremas

    [Required]
    public int TicketId { get; set; }

    [Required]
    public double TotalAddedTax { get; set; }

    [Required]
    public double TotalIncludedTax { get; set; }

    public string Taxes { get; set; }

    [Required]
    public double TotalDiscountCash { get; set; } 

    [Required]
    public double TotalDiscountPercent { get; set; } 

    public double? AmountInBox { get; set; } // keremas

    public string Discounts { get; set; }

    public string Marks { get; set; }

    // autofill
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public string ProductCategoryName { get; set; }
    public string ProductSku { get; set; }
    public string ProductBarcode { get; set; }
    public string ProductUnitMeasureId { get; set; }
    public bool? ProductIsMarked { get; set; }
    public double? SelectedPriceAmount { get; set; }
    public double? RedLine { get; set; }
    public double? YellowLine { get; set; }
    public double? WarehouseAmount { get; set; }

}

