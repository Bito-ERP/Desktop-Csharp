using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Sale;
public class ReceiptResponse
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("total_to_pay")]
    public double TotalToPay { get; set; }

    [JsonPropertyName("total_to_refund")]
    public double? TotalToRefund { get; set; }

    [JsonPropertyName("total_price")]
    public double TotalPrice { get; set; }

    [JsonPropertyName("discount")]
    public double Discount { get; set; } = 0.0;

    [JsonPropertyName("total_discount")]
    public double TotalDiscount { get; set; } = 0.0;

    [JsonPropertyName("total_included_tax")]
    public double TotalIncludedTax { get; set; } = 0.0;

    [JsonPropertyName("total_added_tax")]
    public double TotalAddedTax { get; set; } = 0.0;

    [JsonPropertyName("is_refund")]
    public bool IsRefund { get; set; }

    [JsonPropertyName("calc_tax_after_discount")]
    public bool CalcTaxAfterDiscount { get; set; }

    [JsonPropertyName("calc_sale_discount_after_product")]
    public bool CalcSaleDiscountAfterProducts { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("currency")]
    public ReceiptCurrency Currency { get; set; }

    [JsonPropertyName("base_currency_value")]
    public float BaseCurrencyValue { get; set; }

    [JsonPropertyName("earned_cashback")]
    public ReceiptEarnedCashback EarnedCashback { get; set; }

    [JsonPropertyName("customer_before_balance")]
    public List<Amount> CustomerBeforeBalance { get; set; } = new List<Amount>();

    [JsonPropertyName("customer_after_balance")]
    public List<Amount> CustomerAfterBalance { get; set; } = new List<Amount>();

    [JsonPropertyName("cashback_before_balance")]
    public List<Amount> CashbackBeforeBalance { get; set; } = new List<Amount>();

    [JsonPropertyName("cashback_after_balance")]
    public List<Amount> CashbackAfterBalance { get; set; } = new List<Amount>();

    [JsonPropertyName("cashbox")]
    public DataResponse Cashbox { get; set; }

    [Required]
    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("refund_number")]
    public string RefundNumber { get; set; }

    [JsonPropertyName("refund_uuid")]
    public string RefundUuid { get; set; }

    [JsonPropertyName("total_amount")]
    public double TotalAmount { get; set; } = 0.0;

    [JsonPropertyName("total_refunded_amount")]
    public double TotalRefundedAmount { get; set; } = 0.0;

    [JsonPropertyName("device")]
    public ReceiptDevice Device { get; set; }

    [JsonPropertyName("responsible")]
    public UserResponse Responsible { get; set; }

    [JsonPropertyName("created_by")]
    public UserResponse CreatedBy { get; set; }

    [JsonPropertyName("customer")]
    public DataResponse Customer { get; set; }

    [JsonPropertyName("warehouse")]
    public DataResponse Warehouse { get; set; }

    [JsonPropertyName("contract")]
    public ReceiptContract Contract { get; set; }

    [JsonPropertyName("order")]
    public ReceiptOrder Order { get; set; }

    [JsonPropertyName("delivery_address")]
    public LocationResponse DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_date")]
    public string DeliveryDate { get; set; }

    [JsonPropertyName("sold_at")]
    public string SoldAt { get; set; }

    [JsonPropertyName("is_trash")]
    public bool? IsTrash { get; set; }

    [JsonPropertyName("invoice")]
    public ReceiptInvoice Invoice { get; set; }

    [JsonPropertyName("payments")]
    public List<Payment> Payments { get; set; }

    [JsonPropertyName("installment_plan")]
    public List<InstallmentPlan> InstallmentPlans { get; set; }

    [JsonPropertyName("applied_cashbacks")]
    public List<AppliedCashback> AppliedCashbacks { get; set; }

    [JsonPropertyName("discounts")]
    public List<DiscountResponse> Discounts { get; set; }

    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; }

    [JsonPropertyName("products")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("payment_type")]
        public DataResponse PaymentType { get; set; }

        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        [JsonPropertyName("payment_for")]
        public string PaymentFor { get; set; }

        [JsonPropertyName("is_refund")]
        public bool IsRefund { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("customer")]
        public DataResponse Customer { get; set; }

        [JsonPropertyName("employee")]
        public UserResponse Employee { get; set; }

        [JsonPropertyName("supplier")]
        public DataResponse Supplier { get; set; }

        [JsonPropertyName("person")]
        public DataResponse Person { get; set; }

        [JsonPropertyName("to_be_paid")]
        public double ToBePaid { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("to_be_refunded")]
        public double ToBeRefunded { get; set; }

        [JsonPropertyName("refunded")]
        public double Refunded { get; set; }

        [JsonPropertyName("paid_by_balance")]
        public double PaidByBalance { get; set; } = 0.0;

        [JsonPropertyName("paid_by_cashback")]
        public double PaidByCashback { get; set; } = 0.0;

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("trade_id")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class ReceiptOrder
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class Amount
    {
        [JsonPropertyName("amount")]
        public double Value { get; set; }

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        public Receipt.Amount Get() => new Receipt.Amount
        {
            Value = Value,
            CurrencyId = CurrencyId
        };
    }

    public class ReceiptCurrency
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }

    public class ReceiptDevice
    {
        [JsonPropertyName("device_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ReceiptEarnedCashback
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class Payment
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("payment_method")]
        public DataResponse PaymentMethod { get; set; }

        [JsonPropertyName("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
        public double Paid { get; set; }

        [JsonPropertyName("refunded")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("amount")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("payment_method")]
        public DataResponse PaymentMethod { get; set; }

        [JsonPropertyName("currency")]
        public ReceiptCurrency Currency { get; set; }

        [JsonPropertyName("base_currency_value")]
        public float BaseCurrencyValue { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("paid")]
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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("category")]
        public DataResponse Category { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("measure_id")]
        public string UnitMeasurementId { get; set; }

        [JsonPropertyName("is_marked")]
        public bool IsMarked { get; set; }

        [JsonPropertyName("box_item")]
        public double? BoxItem { get; set; }

        [JsonPropertyName("refunded_amount")]
        public double RefundedAmount { get; set; }

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

        [JsonPropertyName("distributed_discount")]
        public double DistributedDiscount { get; set; }

        [JsonPropertyName("included_tax")]
        public double IncludedTax { get; set; }

        [JsonPropertyName("added_tax")]
        public double AddedTax { get; set; }

        [JsonPropertyName("discounts")]
        public List<DiscountResponse> Discounts { get; set; }

        [JsonPropertyName("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonPropertyName("marks")]
        public List<string> Marks { get; set; }

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
