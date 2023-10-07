using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Pos;

public class RequestPageItemCreate
{
    [JsonProperty("pos_page_id")]
    public string PosPageId { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("is_product")]
    public bool IsProduct { get; set; }

    [JsonProperty("is_category")]
    public bool IsCategory { get; set; }

    [JsonProperty("is_discount")]
    public bool IsDiscount { get; set; }

    [JsonProperty("item_id")]
    public string ItemId { get; set; }

    [JsonProperty("category_id")]
    public string CategoryId { get; set; }

    [JsonProperty("discount_id")]
    public string DiscountId { get; set; }
}

public class RequestPageItemUpdate
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("row")]
    public int? Row { get; set; }

    [JsonProperty("column")]
    public int? Column { get; set; }
}

public class RequestPageUpdate
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

}
