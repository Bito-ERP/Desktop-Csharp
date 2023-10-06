using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Finance;
internal class InvoiceResponse
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
}
