using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Sale;

public class Receipt
{
    [Required]
    public string Uuid { get; set; }

    [Required]
    public string Id { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public int Counter { get; set; }

    [Required]
    public bool Synced { get; set; }

    [Required]
    public bool CalcAddedTaxAfterDiscount { get; set; }

    [Required]
    public bool CalcIncludedTaxAfterDiscount { get; set; }

    [Required]
    public bool CalcSaleDiscountAfterProducts { get; set; }

    [Required]
    public double TotalToPay { get; set; }

    public double? TotalToRefund { get; set; }

    [Required]
    public double TotalPrice { get; set; }

    [Required]
    public double ProductsTotalDiscount { get; set; }

    [Required]
    public double SaleTotalDiscount { get; set; }

    [Required]
    public double TotalIncludedTax { get; set; }

    [Required]
    public double TotalAddedTax { get; set; }

    [Required]
    public bool IsRefund { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public long Number { get; set; }

    public long? RefundNumber { get; set; }

    public string RefundUuid { get; set; }

    [Required]
    public string CashboxId { get; set; }

    [Required]
    public string CashboxName { get; set; }

    public string DeviceId { get; set; }

    public string DeviceName { get; set; }

    [Required]
    public string CreatorId { get; set; }

    [Required]
    public string CreatorName { get; set; }
    public string ResponsibleId { get; set; }

    public string ResponsibleName { get; set; }
    public string CustomerId { get; set; }

    public string CustomerName { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    [Required]
    public string CurrencyName { get; set; }

    [Required]
    public string CurrencySide { get; set; }

    public string CurrencySymbol { get; set; }

    [Required]
    public double BaseCurrencyValue { get; set; }

    public string EarnedCashbackId { get; set; }

    public string EarnedCashbackCurrencyId { get; set; }

    public string EarnedCashbackCurrencyName { get; set; }

    public double? EarnedCashbackCurrencyValue { get; set; }

    public string EarnedCashbackCurrencySide { get; set; }

    public string EarnedCashbackCurrencySymbol { get; set; }

    public double? EarnedCashbackAmount { get; set; }

    [Required]
    public List<Amount> CustomerBeforeBalance { get; set; }

    [Required]
    public List<Amount> CustomerAfterBalance { get; set; }

    [Required]
    public List<Amount> CustomerBeforeCashback { get; set; }

    [Required]
    public List<Amount> CustomerAfterCashback { get; set; }

    [Required]
    public string WarehouseId { get; set; }

    [Required]
    public string WarehouseName { get; set; }

    public string ContractId { get; set; }

    public string ContractCode { get; set; }

    public string ContractNumber { get; set; }

    public string OrderId { get; set; }

    public string OrderCode { get; set; }

    public string OrderNumber { get; set; }

    public double? DeliveryLatitude { get; set; }

    public double? DeliveryLongitude { get; set; }

    public string DeliveryLocationName { get; set; }

    public DateTimeOffset? DeliveryDate { get; set; }

    public bool? IsTrash { get; set; }

    [Required]
    public bool SendSms { get; set; }

    [Required]
    public DateTimeOffset SoldAt { get; set; }

    [Required]
    public int Failed { get; set; } // count of failed attempts to sync, used to filter receipts in order to prevent infinite requests

    [Required]
    public int ErrorCode { get; set; }  // code of error returned from a server

    public string ErrorData { get; set; } // might be used to save productId which is caused a exception while syncing, you get it from a error response

    public List<ReceiptPayment> Payments { get; set; } = null;
    public List<ReceiptInstallment> Installments { get; set; } = null;
    public List<ReceiptCashback> Cashbacks { get; set; } = null;
    public List<ReceiptDiscount> Discounts { get; set; } = null;
    public List<ReceiptChange> Changes { get; set; } = null;


    public class Amount
    {
        public double Value { get; set; }
        public string CurrencyId { get; set; }
    }
}

public class ReceiptItem
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptUUID { get; set; }

    [Required]
    public bool Synced { get; set; }

    [Required]
    public string ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Image { get; set; }

    public string CategoryName { get; set; }

    [Required]
    public string Sku { get; set; }

    public string Barcode { get; set; }

    [Required]
    public string UnitMeasurement { get; set; }

    [Required]
    public bool IsMarked { get; set; }

    [Required]
    public double Amount { get; set; }

    public double? AmountInBox { get; set; }

    [Required]
    public double SoldAmount { get; set; }

    [Required]
    public double RefundAmount { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public double RealPrice { get; set; }

    [Required]
    public double ProductDiscount { get; set; }

    [Required]
    public double DistributedDiscount { get; set; }

    [Required]
    public double IncludedTax { get; set; }

    [Required]
    public double AddedTax { get; set; }

    public List<ReceiptDiscount> Discounts { get; set; }

    public List<Tax> Taxes { get; set; }

    public List<String> Marks { get; set; }


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
    }

}

public class ReceiptPayment
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptId { get; set; }

    [Required]
    public bool Synced { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public double Paid { get; set; }

    [Required]
    public float BaseCurrencyValue { get; set; }

    [Required]
    public double Refunded { get; set; }

    [Required]
    public string PaymentMethodId { get; set; }

    [Required]
    public string PaymentMethodName { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    [Required]
    public string CurrencyName { get; set; }

    [Required]
    public float CurrencyValue { get; set; }

    [Required]
    public string CurrencySide { get; set; }

    public string CurrencySymbol { get; set; }
}


public class ReceiptDiscount
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptId { get; set; }

    public string Name { get; set; }

    [Required]
    public string ApplyType { get; set; }

    [Required]
    public double Value { get; set; }

    public string CurrencyId { get; set; }

    [Required]
    public bool IsCustom { get; set; }
}

public class ReceiptInstallment
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptId { get; set; }

    [Required]
    public DateTimeOffset Date { get; set; }

    [Required]
    public double Amount { get; set; }
}

public class ReceiptCashback
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptId { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public double Paid { get; set; }

    [Required]
    public float BaseCurrencyValue { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    [Required]
    public string CurrencyName { get; set; }

    [Required]
    public float CurrencyValue { get; set; }

    [Required]
    public string CurrencySide { get; set; }

    public string CurrencySymbol { get; set; }
}

public class ReceiptChange
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string ReceiptId { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public double Paid { get; set; }

    [Required]
    public float BaseCurrencyValue { get; set; }

    [Required]
    public string PaymentMethodId { get; set; }

    [Required]
    public string PaymentMethodName { get; set; }

    [Required]
    public string CurrencyId { get; set; }

    [Required]
    public string CurrencyName { get; set; }

    [Required]
    public float CurrencyValue { get; set; }

    [Required]
    public string CurrencySide { get; set; }

    public string CurrencySymbol { get; set; }
}
