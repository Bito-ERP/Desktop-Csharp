using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

internal class RequestBy
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("barcode")]
    public string Barcode { get; set; }

    [JsonProperty("sku")]
    public string Sku { get; set; }

    [JsonProperty("mark")]
    public string Mark { get; set; }

    [JsonProperty("inn")]
    public string Inn { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }

    [JsonProperty("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonProperty("deleted_at")]
    public string DeletedAt { get; set; }

    [JsonProperty("receiver_warehouse_id")]
    public string ReceiverWarehouseId { get; set; }

    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [JsonProperty("trade_id")]
    public string TradeId { get; set; }

    [JsonProperty("pos_page_id")]
    public string PosPageId { get; set; }

    [JsonProperty("field_name")]
    public string FieldName { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("block_id")]
    public string BlockId { get; set; }

    [JsonProperty("b2c_id")]
    public string B2cId { get; set; }

    [JsonProperty("revision_id")]
    public string RevisionId { get; set; }

    [JsonProperty("category_ids")]
    public string[] CategoryIds { get; set; }

    [JsonProperty("is_all")]
    public bool IsAll { get; set; }

    [JsonProperty("product_id")]
    public string ProductId { get; set; }

    [JsonProperty("service")]
    public string Service { get; set; }

    [JsonProperty("states")]
    public List<string?> States { get; set; }
}
