using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

internal class RequestBy
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("barcode")]
    public string Barcode { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("mark")]
    public string Mark { get; set; }

    [JsonPropertyName("inn")]
    public string Inn { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonPropertyName("deleted_at")]
    public string DeletedAt { get; set; }

    [JsonPropertyName("receiver_warehouse_id")]
    public string ReceiverWarehouseId { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("trade_id")]
    public string TradeId { get; set; }

    [JsonPropertyName("pos_page_id")]
    public string PosPageId { get; set; }

    [JsonPropertyName("field_name")]
    public string FieldName { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("block_id")]
    public string BlockId { get; set; }

    [JsonPropertyName("b2c_id")]
    public string B2cId { get; set; }

    [JsonPropertyName("revision_id")]
    public string RevisionId { get; set; }

    [JsonPropertyName("category_ids")]
    public string[] CategoryIds { get; set; }

    [JsonPropertyName("is_all")]
    public bool IsAll { get; set; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    [JsonPropertyName("service")]
    public string Service { get; set; }

    [JsonPropertyName("states")]
    public List<string?> States { get; set; }
}
