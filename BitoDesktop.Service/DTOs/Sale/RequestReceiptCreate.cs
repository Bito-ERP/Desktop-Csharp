using BitoDesktop.Service.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Sale;
public class RequestReceiptCreate
{
    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("total_to_pay")]
    public double TotalToPay { get; set; }

    [JsonPropertyName("total_to_refund")]
    public double? TotalToRefund { get; set; }

    [JsonPropertyName("currency")]
    public CurrencyRequest Currency { get; set; }

    [JsonPropertyName("base_currency_value")]
    public float BaseCurrencyValue { get; set; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    [JsonPropertyName("payments")]
    public List<Payment> Payments { get; set; }

    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }

    [JsonPropertyName("created_by")]
    public string CreatedBy { get; set; }

    [JsonPropertyName("responsible_id")]
    public string ResponsibleId { get; set; }

    [JsonPropertyName("sold_at")]
    public string SoldAt { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("order_id")]
    public string OrderId { get; set; }

    [JsonPropertyName("contract_id")]
    public string ContractId { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("delivery_address")]
    public LocationRequest DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_date")]
    public string DeliveryDate { get; set; }

    [JsonPropertyName("calc_tax_after_discount")]
    public bool CalcTaxAfterDiscount { get; set; }

    [JsonPropertyName("calc_sale_discount_after_product")]
    public bool CalcSaleDiscountAfterProducts { get; set; }

    [JsonPropertyName("offline_counter")]
    public long OfflineCounter { get; set; }

    [JsonPropertyName("products_total_discount")]
    public double ProductsTotalDiscount { get; set; }

    [JsonPropertyName("sale_total_discount")]
    public double SaleTotalDiscount { get; set; }

    [JsonPropertyName("discounts")]
    public List<Discount> Discounts { get; set; }

    [JsonPropertyName("total_included_tax")]
    public double TotalIncludedTax { get; set; }

    [JsonPropertyName("total_added_tax")]
    public double TotalAddedTax { get; set; }

    [JsonPropertyName("installment_plan")]
    public List<Installment> Installments { get; set; }

    [JsonPropertyName("applied_cashbacks")]
    public List<Cashback> Cashbacks { get; set; }

    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; }

    [JsonPropertyName("to_send_customer")]
    public bool ToSendCustomer { get; set; }

    [JsonPropertyName("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("refund_uuid")]
    public string RefundUuid { get; set; }

    [JsonPropertyName("reason_id")]
    public string ReasonId { get; set; }

    public class CurrencyRequest
    {
        [JsonPropertyName("_id")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }

    public class Payment
    {
        [JsonPropertyName("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("sold_amount")]
        public double SoldAmount { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("real_price")]
        public double RealPrice { get; set; }

        [JsonPropertyName("product_discount")]
        public double ProductDiscount { get; set; }

        [JsonPropertyName("total_tax")]
        public double TotalTax { get; set; }

        [JsonPropertyName("discounts")]
        public List<Discount> Discounts { get; set; }

        [JsonPropertyName("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonPropertyName("marks")]
        public List<string> Marks { get; set; }

        [JsonPropertyName("cost")]
        public double? Cost { get; set; }
    }

    public class PaymentMethod
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Discount
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("apply_type")]
        public string ApplyType { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("is_custom")]
        public bool IsCustom { get; set; }
    }

    public class Tax
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rate")]
        public float Rate { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("to_price")]
        public bool ToPrice { get; set; }

        [JsonPropertyName("is_manual")]
        public bool IsManual { get; set; }
    }

    public class Installment
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class Cashback
    {
        [JsonPropertyName("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }

    public class Change
    {
        [JsonPropertyName("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }
}
