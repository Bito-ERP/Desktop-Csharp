using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitoDesktop.Service.DTOs.Common;


namespace BitoDesktop.Service.DTOs;

internal class ProductResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("category")]
    public DataResponse? Category { get; set; }

    [JsonProperty("box_type_id")]
    public string BoxTypeId { get; set; }

    [JsonProperty("box_item")]
    public double BoxItem { get; set; } = 0.0;

    [JsonProperty("box_item_barcode")]
    public string BoxItemBarcode { get; set; }

    [JsonProperty("measure_id")]
    public string UnitMeasurementId { get; set; }

    [JsonProperty("sku")]
    public string Sku { get; set; }

    [JsonProperty("barcode")]
    public string Barcode { get; set; }

    [JsonProperty("dimension")]
    public DimensionResponse? Dimension { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("is_marked")]
    public bool IsMarked { get; set; }

    [JsonProperty("is_product")]
    public bool IsProduct { get; set; }

    [JsonProperty("is_material")]
    public bool IsMaterial { get; set; }

    [JsonProperty("is_semi_product")]
    public bool IsSemiProduct { get; set; }

    [JsonProperty("barcodes")]
    public List<BarcodeResponse> Barcodes { get; set; } = new List<BarcodeResponse>();

    [JsonProperty("suppliers")]
    public List<DataResponse> Suppliers { get; set; } = new List<DataResponse>();

    [JsonProperty("organizations")]
    public List<Organization> Organizations { get; set; } = new List<Organization>();

    [JsonProperty("prices")]
    public List<Price> Prices { get; set; } = new List<Price>();

    [JsonProperty("warehouses")]
    public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [JsonProperty("tax_ids")]
    public List<string> TaxIds { get; set; } = new List<string>();

    public class Part
    {
        [JsonProperty("mark")]
        public string Mark { get; set; }
    }

    public class BarcodeResponse
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
    }

    public class Organization
    {
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("in_transit")]
        public float InTransit { get; set; }

        [JsonProperty("trash")]
        public float Trash { get; set; }

        [JsonProperty("booked")]
        public float Booked { get; set; }

        [JsonProperty("yellow_line")]
        public float? YellowLine { get; set; }

        [JsonProperty("red_line")]
        public float? RedLine { get; set; }

        [JsonProperty("max_stock")]
        public float? MaxStock { get; set; }

        [JsonProperty("is_available")]
        public bool IsAvailable { get; set; }

        [JsonProperty("is_available_for_sale")]
        public bool IsAvailableForSale { get; set; }
    }

    public class Price
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("price_id")]
        public string PriceId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("min_price")]
        public double? MinPrice { get; set; }

        [JsonProperty("max_price")]
        public double? MaxPrice { get; set; }

        [JsonProperty("min_sale_amount")]
        public double? MinSaleAmount { get; set; }
    }

    public class Warehouse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseId { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("booked")]
        public float Booked { get; set; }

        [JsonProperty("in_trash")]
        public float InTrash { get; set; }

        [JsonProperty("in_transit")]
        public float InTransit { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class DimensionResponse
    {
        [JsonProperty("shape")]
        public string Shape { get; set; }

        [JsonProperty("netto_weight")]
        public float NetWeight { get; set; }

        [JsonProperty("gross_weight")]
        public float GrossWeight { get; set; }

        [JsonProperty("height")]
        public float Height { get; set; }

        [JsonProperty("width")]
        public float Width { get; set; }

        [JsonProperty("volume")]
        public float Volume { get; set; }

        [JsonProperty("diameter")]
        public float Diameter { get; set; }

        [JsonProperty("length")]
        public float Length { get; set; }
    }
}

