using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;
using System;

namespace BitoDesktop.Service.DTOs.Finance;
public class InvoiceResponse
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
            CustomerId = Customer.Id,
            CustomerName = Customer.Name,
            EmployeeId = Employee.Id,
            EmployeeName = Employee.Name,
            SupplierId = Supplier.Id,
            SupplierName = Supplier.Name,
            PersonId = Person.Id,
            PersonName = Person.Name,
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
