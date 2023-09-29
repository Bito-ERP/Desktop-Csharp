using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Warehouse;

internal class RequestProductCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("category_id")]
    public string CategoryId { get; set; }
    [JsonPropertyName("measure_id")]
    public string UnitMeasurementId { get; set; }
    [JsonPropertyName("box_type_id")]
    public string BoxTypeId { get; set; }
    [JsonPropertyName("box_item")]
    public double? BoxItem { get; set; }
    [JsonPropertyName("box_item_barcode")]
    public string BoxItemBarcode { get; set; }
    [JsonPropertyName("sku")]
    public string Sku { get; set; }
    [JsonPropertyName("barcode")]
    public string Barcode { get; set; }
    [JsonPropertyName("is_available_for_sale")]
    public bool? IsAvailableForSale { get; set; }
    [JsonPropertyName("is_product")]
    public bool IsProduct { get; set; }
    [JsonPropertyName("is_material")]
    public bool IsMaterial { get; set; }
    [JsonPropertyName("is_semi_product")]
    public bool IsSemiProduct { get; set; }
    [JsonPropertyName("is_marked")]
    public bool IsMarked { get; set; }
    [JsonPropertyName("max_stock")]
    public float? MaxStock { get; set; }
    [JsonPropertyName("yellow_line")]
    public float? YellowLine { get; set; }
    [JsonPropertyName("red_line")]
    public float? RedLine { get; set; }
    [JsonPropertyName("image")]
    public string Image { get; set; }
    [JsonPropertyName("prices")]
    public List<Price> Prices { get; set; }

    public class Price
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }
}

