using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;

public class RequestPage
{
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 50;

    [JsonPropertyName("page")]
    public int Page { get; set; } = 1;

    [JsonPropertyName("search")]
    public string Search { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    [JsonPropertyName("supplier_id")]
    public string SupplierId { get; set; }

    [JsonPropertyName("employee_id")]
    public string EmployeeId { get; set; }

    [JsonPropertyName("person_id")]
    public string PersonId { get; set; }

    [JsonPropertyName("cashbox_id")]
    public string CashBoxId { get; set; }

    [JsonPropertyName("category_id")]
    public string CategoryId { get; set; }

    [JsonPropertyName("section_id")]
    public string SectionId { get; set; }

    [JsonPropertyName("list_id")]
    public string ListId { get; set; }

    [JsonPropertyName("process_id")]
    public string ProcessId { get; set; }

    [JsonPropertyName("block_id")]
    public string BlockId { get; set; }

    [JsonPropertyName("revision_id")]
    public string RevisionId { get; set; }

    [JsonPropertyName("parent_id")]
    public string ParentId { get; set; }

    [JsonPropertyName("destination_organization_id")]
    public string DestinationOrganizationId { get; set; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    [JsonPropertyName("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonPropertyName("price_id")]
    public string PriceId { get; set; }

    [JsonPropertyName("currency_id")]
    public string CurrencyId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("states")]
    public List<string> States { get; set; }

    [JsonPropertyName("statuses")]
    public List<string> Statuses { get; set; }

    [JsonPropertyName("in_stock")]
    public string InStock { get; set; }

    [JsonPropertyName("is_product")]
    public bool? IsProduct { get; set; }

    [JsonPropertyName("is_material")]
    public bool? IsMaterial { get; set; }

    [JsonPropertyName("is_semi_product")]
    public bool? IsSemiProduct { get; set; }

    [JsonPropertyName("is_available_for_sale")]
    public bool? IsAvailableForSale { get; set; }

    [JsonPropertyName("is_marked")]
    public bool? IsMarked { get; set; }

    [JsonPropertyName("is_main")]
    public bool? IsMain { get; set; }

    [JsonPropertyName("is_fully_income")]
    public bool? IsFullyIncome { get; set; }

    [JsonPropertyName("is_fully_refunded")]
    public bool? IsFullyRefunded { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("top")]
    public bool? Top { get; set; }

    [JsonPropertyName("date_from")]
    public string DateFrom { get; set; }

    [JsonPropertyName("date_to")]
    public string DateTo { get; set; }

    [JsonPropertyName("total_from")]
    public float? TotalFrom { get; set; }

    [JsonPropertyName("total_to")]
    public float? TotalTo { get; set; }

    [JsonPropertyName("is_fully_paid")]
    public bool? IsFullyPaid { get; set; }

    [JsonPropertyName("imei")]
    public string Imei { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
}

