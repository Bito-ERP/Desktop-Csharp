using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Pos;

public class RequestPageItemCreate
{
    [JsonPropertyName("pos_page_id")]
    public string PosPageId { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("is_product")]
    public bool IsProduct { get; set; }

    [JsonPropertyName("is_category")]
    public bool IsCategory { get; set; }

    [JsonPropertyName("is_discount")]
    public bool IsDiscount { get; set; }

    [JsonPropertyName("item_id")]
    public string ItemId { get; set; }

    [JsonPropertyName("category_id")]
    public string CategoryId { get; set; }

    [JsonPropertyName("discount_id")]
    public string DiscountId { get; set; }
}

public class RequestPageItemUpdate
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("row")]
    public int? Row { get; set; }

    [JsonPropertyName("column")]
    public int? Column { get; set; }
}

public class RequestPageUpdate
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

}
