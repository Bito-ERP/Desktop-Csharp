using BitoDesktop.Domain.Entities.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Pos;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double OverallSum { get; set; }

    [Required]
    public string PriceId { get; set; }

    [Required]
    public string WarehouseId { get; set; }

    [Required]
    public DateTimeOffset CreatedAt { get; set; }

    public string TableId { get; set; }

    public string Comment { get; set; }

    public string CustomerId { get; set; }

    public List<ReceiptDiscount> Discounts { get; set; }
}
