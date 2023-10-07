using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;

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
}
