using System;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Finance;

public class Invoice
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string Number { get; set; }

    [Required]
    public string PaymentTypeId { get; set; }

    [Required]
    public string PaymentTypeName { get; set; }

    public string UserType { get; set; }
    public string PaymentFor { get; set; }

    [Required]
    public bool IsRefund { get; set; }

    [Required]
    public DateTimeOffset Date { get; set; }

    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string PersonId { get; set; }
    public string PersonName { get; set; }

    [Required]
    public double ToBePaid { get; set; }

    [Required]
    public double Paid { get; set; }

    [Required]
    public double ToBeRefunded { get; set; }

    [Required]
    public double Refunded { get; set; }

    [Required]
    public double PaidByBalance { get; set; }

    [Required]
    public double PaidByCashback { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    public string TradeId { get; set; }

}

