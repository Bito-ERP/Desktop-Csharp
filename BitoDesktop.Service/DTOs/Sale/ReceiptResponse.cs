using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Sale;
public class ReceiptResponse
{
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("total_to_pay")]
    public double TotalToPay { get; set; }

    [JsonProperty("total_to_refund")]
    public double? TotalToRefund { get; set; }

    [JsonProperty("total_price")]
    public double TotalPrice { get; set; }

    [JsonProperty("discount")]
    public double Discount { get; set; } = 0.0;
    [JsonProperty("total_discount")]
    public double TotalDiscount { get; set; } = 0.0;

    [JsonProperty("total_included_tax")]
    public double TotalIncludedTax { get; set; } = 0.0;

    [JsonProperty("total_added_tax")]
    public double TotalAddedTax { get; set; } = 0.0;

    [JsonProperty("is_refund")]
    public bool IsRefund { get; set; }

    [JsonProperty("calc_tax_after_discount")]
    public bool CalcTaxAfterDiscount { get; set; }

    [JsonProperty("calc_sale_discount_after_product")]
    public bool CalcSaleDiscountAfterProducts { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("currency")]
    public ReceiptCurrency Currency { get; set; }

    [JsonProperty("base_currency_value")]
    public float BaseCurrencyValue { get; set; }

    [JsonProperty("earned_cashback")]
    public ReceiptEarnedCashback EarnedCashback { get; set; }

    [JsonProperty("customer_before_balance")]
    public List<Amount> CustomerBeforeBalance { get; set; } = new List<Amount>();

    [JsonProperty("customer_after_balance")]
    public List<Amount> CustomerAfterBalance { get; set; } = new List<Amount>();

    [JsonProperty("cashback_before_balance")]
    public List<Amount> CashbackBeforeBalance { get; set; } = new List<Amount>();

    [JsonProperty("cashback_after_balance")]
    public List<Amount> CashbackAfterBalance { get; set; } = new List<Amount>();

    [JsonProperty("cashbox")]
    public DataResponse Cashbox { get; set; }

    [Required]
    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("refund_number")]
    public string RefundNumber { get; set; }

    [JsonProperty("refund_uuid")]
    public string RefundUuid { get; set; }

    [JsonProperty("total_amount")]
    public double TotalAmount { get; set; } = 0.0;

    [JsonProperty("total_refunded_amount")]
    public double TotalRefundedAmount { get; set; } = 0.0;

    [JsonProperty("device")]
    public ReceiptDevice Device { get; set; }

    [JsonProperty("responsible")]
    public UserResponse Responsible { get; set; }

    [JsonProperty("created_by")]
    public UserResponse CreatedBy { get; set; }

    [JsonProperty("customer")]
    public DataResponse Customer { get; set; }

    [JsonProperty("warehouse")]
    public DataResponse Warehouse { get; set; }

    [JsonProperty("contract")]
    public ReceiptContract Contract { get; set; }

    [JsonProperty("order")]
    public ReceiptOrder Order { get; set; }

    [JsonProperty("delivery_address")]
    public LocationResponse DeliveryAddress { get; set; }

    [JsonProperty("delivery_date")]
    public string DeliveryDate { get; set; }

    [JsonProperty("sold_at")]
    public string SoldAt { get; set; }

    [JsonProperty("is_trash")]
    public bool? IsTrash { get; set; }

    [JsonProperty("invoice")]
    public ReceiptInvoice Invoice { get; set; }

    [JsonProperty("payments")]
    public List<Payment> Payments { get; set; }

    [JsonProperty("installment_plan")]
    public List<InstallmentPlan> InstallmentPlans { get; set; }

    [JsonProperty("applied_cashbacks")]
    public List<AppliedCashback> AppliedCashbacks { get; set; }

    [JsonProperty("discounts")]
    public List<DiscountResponse> Discounts { get; set; }

    [JsonProperty("changes")]
    public List<Change> Changes { get; set; }

    [JsonProperty("products")]
    public List<Product> Products { get; set; }

    public Receipt Get(string organizationId)
    {
        return new Receipt
        {
            Uuid = Uuid,
            Id = Id,
            OrganizationId = organizationId,
            Counter = 0,
            Synced = true,
            CalcAddedTaxAfterDiscount = CalcTaxAfterDiscount,
            CalcIncludedTaxAfterDiscount = CalcTaxAfterDiscount,
            CalcSaleDiscountAfterProducts = CalcSaleDiscountAfterProducts,
            TotalToPay = TotalToPay,
            TotalToRefund = TotalToRefund,
            TotalPrice = TotalPrice,
            ProductsTotalDiscount = TotalDiscount - Discount,
            SaleTotalDiscount = Discount,
            TotalIncludedTax = TotalIncludedTax,
            TotalAddedTax = TotalAddedTax,
            IsRefund = IsRefund,
            State = State,
            Number = long.Parse(Number),
            RefundNumber = RefundNumber == null ? null : long.Parse(RefundNumber),
            RefundUuid = RefundUuid,
            CashboxId = Cashbox.Id,
            CashboxName = Cashbox.Name,
            DeviceId = Device?.Id,
            DeviceName = Device?.Name,
            CreatorId = CreatedBy.Id,
            CreatorName = CreatedBy.FullName,
            ResponsibleId = Responsible?.Id,
            ResponsibleName = Responsible?.Name,
            CustomerId = Customer?.Id,
            CustomerName = Customer?.Name,
            CurrencyId = Currency?.Id,
            CurrencyName = Currency?.Name,
            CurrencySide = Currency?.Side,
            CurrencySymbol = Currency?.Symbol,
            BaseCurrencyValue = BaseCurrencyValue,
            EarnedCashbackId = EarnedCashback?.Id,
            EarnedCashbackCurrencyId = EarnedCashback?.Currency?.Id,
            EarnedCashbackCurrencyName = EarnedCashback?.Currency?.Name,
            EarnedCashbackCurrencyValue = EarnedCashback?.Currency?.Value,
            EarnedCashbackCurrencySide = EarnedCashback?.Currency?.Side,
            EarnedCashbackCurrencySymbol = EarnedCashback?.Currency?.Symbol,
            EarnedCashbackAmount = EarnedCashback?.Amount,
            CustomerBeforeBalance = CustomerBeforeBalance.Select(it => it.Get()).ToList(),
            CustomerAfterBalance = CustomerAfterBalance.Select(it => it.Get()).ToList(),
            CustomerBeforeCashback = CashbackBeforeBalance.Select(it => it.Get()).ToList(),
            CustomerAfterCashback = CashbackAfterBalance.Select(it => it.Get()).ToList(),
            WarehouseId = Warehouse?.Id,
            WarehouseName = Warehouse?.Name,
            ContractId = Contract?.Id,
            ContractCode = Contract?.Code,
            ContractNumber = Contract?.Number,
            OrderId = Order?.Id,
            OrderCode = Order?.Code,
            OrderNumber = Order?.Number,
            DeliveryLatitude = DeliveryAddress?.Lat,
            DeliveryLongitude = DeliveryAddress?.Long,
            DeliveryLocationName = DeliveryAddress?.Address?.Name,
            DeliveryDate = DeliveryDate == null ? null : DateTimeOffset.Parse(DeliveryDate),
            IsTrash = IsTrash,
            SendSms = false,
            SoldAt = DateTimeOffset.Parse(SoldAt),
            Failed = 0,
            ErrorCode = -1,
            ErrorData = null
        };
    }

    public class ReceiptInvoice
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("payment_type")]
        public DataResponse PaymentType { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("payment_for")]
        public string PaymentFor { get; set; }

        [JsonProperty("is_refund")]
        public bool IsRefund { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("customer")]
        public DataResponse Customer { get; set; }

        [JsonProperty("employee")]
        public UserResponse Employee { get; set; }

        [JsonProperty("supplier")]
        public DataResponse Supplier { get; set; }

        [JsonProperty("person")]
        public DataResponse Person { get; set; }

        [JsonProperty("to_be_paid")]
        public double ToBePaid { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("to_be_refunded")]
        public double ToBeRefunded { get; set; }

        [JsonProperty("refunded")]
        public double Refunded { get; set; }

        [JsonProperty("paid_by_balance")]
        public double PaidByBalance { get; set; } = 0.0;

        [JsonProperty("paid_by_cashback")]
        public double PaidByCashback { get; set; } = 0.0;

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("trade_id")]
        public string TradeId { get; set; }

        public Invoice Get(string organizationId)
        {
            return new Invoice
            {
                Id = Id,
                OrganizationId = organizationId,
                Type = Type,
                Number = Number,
                PaymentTypeId = PaymentType.Id,
                PaymentTypeName = PaymentType.Name,
                UserType = UserType,
                PaymentFor = PaymentFor,
                IsRefund = IsRefund,
                Date = DateTimeOffset.Parse(Date),
                CustomerId = Customer?.Id,
                CustomerName = Customer?.Name,
                EmployeeId = Employee?.Id,
                EmployeeName = Employee?.Name,
                SupplierId = Supplier?.Id,
                SupplierName = Supplier?.Name,
                PersonId = Person?.Id,
                PersonName = Person?.Name,
                ToBePaid = ToBePaid,
                Paid = Paid,
                ToBeRefunded = ToBeRefunded,
                Refunded = Refunded,
                PaidByBalance = PaidByBalance,
                PaidByCashback = PaidByCashback,
                CurrencyId = CurrencyId,
                TradeId = TradeId
            };
        }
    }

    public class ReceiptContract
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class ReceiptOrder
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Amount
    {
        [JsonProperty("amount")]
        public double Value { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        public Receipt.Amount Get() => new Receipt.Amount
        {
            Value = Value,
            CurrencyId = CurrencyId
        };
    }

    public class ReceiptCurrency
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public class ReceiptDevice
    {
        [JsonProperty("device_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ReceiptEarnedCashback
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class Payment
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("payment_method")]
        public DataResponse PaymentMethod { get; set; }

        [JsonProperty("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("refunded")]
        public double Refunded { get; set; }

        public ReceiptPayment Get(string receiptUuid)
        {
            return new ReceiptPayment
            {
                Id = Id,
                ReceiptId = receiptUuid,
                Synced = true,
                Amount = Amount,
                Paid = Paid,
                BaseCurrencyValue = BaseCurrencyValue,
                Refunded = Refunded,
                PaymentMethodId = PaymentMethod.Id,
                PaymentMethodName = PaymentMethod.Name,
                CurrencyId = Currency.Id,
                CurrencyName = Currency.Name,
                CurrencyValue = Currency.Value,
                CurrencySide = Currency.Side,
                CurrencySymbol = Currency.Symbol
            };
        }
    }

    public class InstallmentPlan
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        public ReceiptInstallment Get(string receiptUuid)
        {
            return new ReceiptInstallment
            {
                Id = Id,
                ReceiptId = receiptUuid,
                Date = DateTimeOffset.Parse(Date),
                Amount = Amount
            };
        }
    }

    public class AppliedCashback
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        public ReceiptCashback Get(string receiptUuid)
        {
            return new ReceiptCashback
            {
                Id = Id,
                ReceiptId = receiptUuid,
                Amount = Amount,
                Paid = Paid,
                BaseCurrencyValue = BaseCurrencyValue,
                CurrencyId = Currency.Id,
                CurrencyName = Currency.Name,
                CurrencyValue = Currency.Value,
                CurrencySide = Currency.Side,
                CurrencySymbol = Currency.Symbol
            };
        }
    }

    public class DiscountResponse
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

        public ReceiptDiscount Get(string receiptUuid, string currencyId)
        {
            return new ReceiptDiscount
            {
                Id = Id ?? "",
                ReceiptId = receiptUuid,
                Name = Name,
                ApplyType = ApplyType,
                Value = Value,
                CurrencyId = (ApplyType == "cash") ? currencyId : null,
                IsCustom = IsCustom
            };
        }
    }

    public class Change
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("payment_method")]
        public DataResponse PaymentMethod { get; set; }

        [JsonProperty("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonProperty("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        public ReceiptChange Get(string receiptUuid)
        {
            return new ReceiptChange
            {
                Id = Id,
                ReceiptId = receiptUuid,
                Amount = Amount,
                Paid = Paid,
                BaseCurrencyValue = BaseCurrencyValue,
                PaymentMethodId = PaymentMethod.Id,
                PaymentMethodName = PaymentMethod.Name,
                CurrencyId = Currency.Id,
                CurrencyName = Currency.Name,
                CurrencyValue = Currency.Value,
                CurrencySide = Currency.Side,
                CurrencySymbol = Currency.Symbol
            };
        }
    }

    public class Product
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("category")]
        public DataResponse Category { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("measure_id")]
        public string UnitMeasurementId { get; set; }

        [JsonProperty("is_marked")]
        public bool IsMarked { get; set; }

        [JsonProperty("box_item")]
        public double? BoxItem { get; set; }

        [JsonProperty("refunded_amount")]
        public double RefundedAmount { get; set; }

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

        [JsonProperty("distributed_discount")]
        public double DistributedDiscount { get; set; }

        [JsonProperty("included_tax")]
        public double IncludedTax { get; set; }

        [JsonProperty("added_tax")]
        public double AddedTax { get; set; }

        [JsonProperty("discounts")]
        public List<DiscountResponse> Discounts { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonProperty("marks")]
        public List<string> Marks { get; set; }

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

            public ReceiptItem.Tax Get()
            {
                return new ReceiptItem.Tax
                {
                    Id = Id,
                    Name = Name,
                    Rate = Rate,
                    Type = Type,
                    ToPrice = ToPrice,
                    IsManual = IsManual
                };
            }
        }

        public ReceiptItem Get(string receiptUuid, string currencyId)
        {
            return new ReceiptItem
            {
                Id = Id,
                ReceiptUUID = receiptUuid,
                Synced = true,
                ProductId = ProductId,
                Name = Name,
                Image = Image,
                CategoryName = Category?.Name,
                Sku = Sku,
                Barcode = Barcode,
                UnitMeasurement = UnitMeasurementId,
                IsMarked = IsMarked,
                Amount = Amount,
                AmountInBox = BoxItem,
                SoldAmount = SoldAmount,
                RefundAmount = RefundedAmount,
                Price = Price,
                RealPrice = RealPrice,
                ProductDiscount = ProductDiscount,
                DistributedDiscount = DistributedDiscount,
                IncludedTax = IncludedTax,
                AddedTax = AddedTax,
                Discounts = Discounts.Select(d => d.Get(receiptUuid, currencyId)).ToList(),
                Taxes = Taxes.Select(t => t.Get()).ToList(),
                Marks = Marks
            };
        }
    }



}
