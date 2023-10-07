using BitoDesktop.Service.DTOs.Common;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Sale;
public class RequestReceiptCreate
{
    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }

    [JsonProperty("total_to_pay")]
    public double TotalToPay { get; set; }

    [JsonProperty("total_to_refund")]
    public double? TotalToRefund { get; set; }

    [JsonProperty("currency")]
    public CurrencyRequest Currency { get; set; }

    [JsonProperty("base_currency_value")]
    public float BaseCurrencyValue { get; set; }

    [JsonProperty("customer_id")]
    public string CustomerId { get; set; }

    [JsonProperty("payments")]
    public List<Payment> Payments { get; set; }

    [JsonProperty("products")]
    public List<Product> Products { get; set; }

    [JsonProperty("created_by")]
    public string CreatedBy { get; set; }

    [JsonProperty("responsible_id")]
    public string ResponsibleId { get; set; }

    [JsonProperty("sold_at")]
    public string SoldAt { get; set; }

    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [JsonProperty("order_id")]
    public string OrderId { get; set; }

    [JsonProperty("contract_id")]
    public string ContractId { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("delivery_address")]
    public LocationRequest DeliveryAddress { get; set; }

    [JsonProperty("delivery_date")]
    public string DeliveryDate { get; set; }

    [JsonProperty("calc_tax_after_discount")]
    public bool CalcTaxAfterDiscount { get; set; }

    [JsonProperty("calc_sale_discount_after_product")]
    public bool CalcSaleDiscountAfterProducts { get; set; }

    [JsonProperty("offline_counter")]
    public long OfflineCounter { get; set; }

    [JsonProperty("products_total_discount")]
    public double ProductsTotalDiscount { get; set; }

    [JsonProperty("sale_total_discount")]
    public double SaleTotalDiscount { get; set; }

    [JsonProperty("discounts")]
    public List<Discount> Discounts { get; set; }

    [JsonProperty("total_included_tax")]
    public double TotalIncludedTax { get; set; }

    [JsonProperty("total_added_tax")]
    public double TotalAddedTax { get; set; }

    [JsonProperty("installment_plan")]
    public List<Installment> Installments { get; set; }

    [JsonProperty("applied_cashbacks")]
    public List<Cashback> Cashbacks { get; set; }

    [JsonProperty("changes")]
    public List<Change> Changes { get; set; }

    [JsonProperty("to_send_customer")]
    public bool ToSendCustomer { get; set; }

    [JsonProperty("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonProperty("note")]
    public string Note { get; set; }

    [JsonProperty("refund_uuid")]
    public string RefundUuid { get; set; }

    [JsonProperty("reason_id")]
    public string ReasonId { get; set; }

    public class CurrencyRequest
    {
        [JsonProperty("_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public class Payment
    {
        [JsonProperty("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }

    public class Product
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("sold_amount")]
        public double SoldAmount { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("real_price")]
        public double RealPrice { get; set; }

        [JsonProperty("product_discount")]
        public double ProductDiscount { get; set; }

        [JsonProperty("total_tax")]
        public double TotalTax { get; set; }

        [JsonProperty("discounts")]
        public List<Discount> Discounts { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonProperty("marks")]
        public List<string> Marks { get; set; }

        [JsonProperty("cost")]
        public double? Cost { get; set; }
    }

    public class PaymentMethod
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Discount
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apply_type")]
        public string ApplyType { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("is_custom")]
        public bool IsCustom { get; set; }
    }

    public class Tax
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rate")]
        public float Rate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("to_price")]
        public bool ToPrice { get; set; }

        [JsonProperty("is_manual")]
        public bool IsManual { get; set; }
    }

    public class Installment
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class Cashback
    {
        [JsonProperty("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }

    public class Change
    {
        [JsonProperty("currency")]
        public CurrencyRequest Currency { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }
    }
}
