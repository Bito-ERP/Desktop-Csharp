using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitoDesktop.Service.DTOs.Common;

public class RequestPage
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("page")]
    public int Page { get; set; } = 1;

    [JsonProperty("search")]
    public string Search { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }

    [JsonProperty("customer_id")]
    public string CustomerId { get; set; }

    [JsonProperty("supplier_id")]
    public string SupplierId { get; set; }

    [JsonProperty("employee_id")]
    public string EmployeeId { get; set; }

    [JsonProperty("person_id")]
    public string PersonId { get; set; }

    [JsonProperty("cashbox_id")]
    public string CashBoxId { get; set; }

    [JsonProperty("category_id")]
    public string CategoryId { get; set; }

    [JsonProperty("section_id")]
    public string SectionId { get; set; }

    [JsonProperty("list_id")]
    public string ListId { get; set; }

    [JsonProperty("process_id")]
    public string ProcessId { get; set; }

    [JsonProperty("block_id")]
    public string BlockId { get; set; }

    [JsonProperty("revision_id")]
    public string RevisionId { get; set; }

    [JsonProperty("parent_id")]
    public string ParentId { get; set; }

    [JsonProperty("destination_organization_id")]
    public string DestinationOrganizationId { get; set; }

    [JsonProperty("product_id")]
    public string ProductId { get; set; }

    [JsonProperty("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonProperty("price_id")]
    public string PriceId { get; set; }

    [JsonProperty("currency_id")]
    public string CurrencyId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("states")]
    public List<string> States { get; set; }

    [JsonProperty("statuses")]
    public List<string> Statuses { get; set; }

    [JsonProperty("in_stock")]
    public string InStock { get; set; }

    [JsonProperty("is_product")]
    public bool? IsProduct { get; set; }

    [JsonProperty("is_material")]
    public bool? IsMaterial { get; set; }

    [JsonProperty("is_semi_product")]
    public bool? IsSemiProduct { get; set; }

    [JsonProperty("is_available_for_sale")]
    public bool? IsAvailableForSale { get; set; }

    [JsonProperty("is_marked")]
    public bool? IsMarked { get; set; }

    [JsonProperty("is_main")]
    public bool? IsMain { get; set; }

    [JsonProperty("is_fully_income")]
    public bool? IsFullyIncome { get; set; }

    [JsonProperty("is_fully_refunded")]
    public bool? IsFullyRefunded { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("top")]
    public bool? Top { get; set; }

    [JsonProperty("date_from")]
    public string DateFrom { get; set; }

    [JsonProperty("date_to")]
    public string DateTo { get; set; }

    [JsonProperty("total_from")]
    public float? TotalFrom { get; set; }

    [JsonProperty("total_to")]
    public float? TotalTo { get; set; }

    [JsonProperty("is_fully_paid")]
    public bool? IsFullyPaid { get; set; }

    [JsonProperty("imei")]
    public string Imei { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
}

