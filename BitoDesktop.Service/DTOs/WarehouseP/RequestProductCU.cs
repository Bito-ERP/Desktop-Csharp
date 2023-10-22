using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitoDesktop.Service.DTOs.WarehouseP;

public class RequestProductCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("category_id")]
    public string CategoryId { get; set; }
    [JsonProperty("measure_id")]
    public string UnitMeasurementId { get; set; }
    [JsonProperty("box_type_id")]
    public string BoxTypeId { get; set; }
    [JsonProperty("box_item")]
    public double? BoxItem { get; set; }
    [JsonProperty("box_item_barcode")]
    public string BoxItemBarcode { get; set; }
    [JsonProperty("sku")]
    public string Sku { get; set; }
    [JsonProperty("barcode")]
    public string Barcode { get; set; }
    [JsonProperty("is_available_for_sale")]
    public bool? IsAvailableForSale { get; set; }
    [JsonProperty("is_product")]
    public bool IsProduct { get; set; }
    [JsonProperty("is_material")]
    public bool IsMaterial { get; set; }
    [JsonProperty("is_semi_product")]
    public bool IsSemiProduct { get; set; }
    [JsonProperty("is_marked")]
    public bool IsMarked { get; set; }
    [JsonProperty("max_stock")]
    public float? MaxStock { get; set; }
    [JsonProperty("yellow_line")]
    public float? YellowLine { get; set; }
    [JsonProperty("red_line")]
    public float? RedLine { get; set; }
    [JsonProperty("image")]
    public string Image { get; set; }
    [JsonProperty("prices")]
    public List<Price> Prices { get; set; }

    public class Price
    {
        [JsonProperty("price_id")]
        public string PriceId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}

