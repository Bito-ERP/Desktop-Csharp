using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Domain.Entities.Products;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.WarehouseP;

internal class ProductResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("category")]
    public DataResponse Category { get; set; }

    [JsonPropertyName("box_type_id")]
    public string BoxTypeId { get; set; }

    [JsonPropertyName("box_item")]
    public double BoxItem { get; set; } = 0.0;

    [JsonPropertyName("box_item_barcode")]
    public string BoxItemBarcode { get; set; }

    [JsonPropertyName("measure_id")]
    public string UnitMeasurementId { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("barcode")]
    public string Barcode { get; set; }

    [JsonPropertyName("dimension")]
    public DimensionResponse Dimension { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("is_marked")]
    public bool IsMarked { get; set; }

    [JsonPropertyName("is_product")]
    public bool IsProduct { get; set; }

    [JsonPropertyName("is_material")]
    public bool IsMaterial { get; set; }

    [JsonPropertyName("is_semi_product")]
    public bool IsSemiProduct { get; set; }

    [JsonPropertyName("barcodes")]
    public List<BarcodeResponse> Barcodes { get; set; } = new List<BarcodeResponse>();

    [JsonPropertyName("suppliers")]
    public List<DataResponse> Suppliers { get; set; } = new List<DataResponse>();

    [JsonPropertyName("organizations")]
    public List<Organization> Organizations { get; set; } = new List<Organization>();

    [JsonPropertyName("prices")]
    public List<Price> Prices { get; set; } = new List<Price>();

    [JsonPropertyName("warehouses")]
    public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [JsonPropertyName("tax_ids")]
    public List<string> TaxIds { get; set; } = new List<string>();

    public class Part
    {
        [JsonPropertyName("mark")]
        public string Mark { get; set; }
    }

    public class BarcodeResponse
    {
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        public ProductTable.BarcodeItem Get() => new ProductTable.BarcodeItem
        {
            Barcode = Barcode,
            IsActive = IsActive
        };
    }

    public class Organization
    {
        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("in_transit")]
        public float InTransit { get; set; }

        [JsonPropertyName("trash")]
        public float Trash { get; set; }

        [JsonPropertyName("booked")]
        public float Booked { get; set; }

        [JsonPropertyName("yellow_line")]
        public float? YellowLine { get; set; }

        [JsonPropertyName("red_line")]
        public float? RedLine { get; set; }

        [JsonPropertyName("max_stock")]
        public float? MaxStock { get; set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; }

        [JsonPropertyName("is_available_for_sale")]
        public bool IsAvailableForSale { get; set; }

        public ProductOrganization Get(string ProductId) => new()
        {
            OrganizationId = OrganizationId,
            ProductId = ProductId,
            Amount = Amount,
            InTransit = InTransit,
            Trash = Trash,
            Booked = Booked,
            YellowLine = YellowLine,
            RedLine = RedLine,
            MaxStock = MaxStock,
            IsAvailable = IsAvailable,
            IsAvailableForSale = IsAvailableForSale
        };
    }

    public class Price
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("min_price")]
        public double? MinPrice { get; set; }

        [JsonPropertyName("max_price")]
        public double? MaxPrice { get; set; }

        [JsonPropertyName("min_sale_amount")]
        public double? MinSaleAmount { get; set; }

        public ProductPrice Get() => new()
        {
            Id = Id,
            PriceId = PriceId,
            OrganizationId = OrganizationId,
            ProductId = ProductId,
            PriceAmount = Amount,
            MinPrice = MinPrice,
            MaxPrice = MaxPrice,
            MinSaleAmount = MinSaleAmount
        };
    }

    public class Warehouse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("warehouse_id")]
        public string WarehouseId { get; set; }

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("booked")]
        public float Booked { get; set; }

        [JsonPropertyName("in_trash")]
        public float InTrash { get; set; }

        [JsonPropertyName("in_transit")]
        public float InTransit { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }


        public ProductWarehouse Get() => new()
        {
            Id = Id,
            WarehouseId = WarehouseId,
            OrganizationId = OrganizationId,
            ProductId = ProductId,
            Booked = Booked,
            InTrash = InTrash,
            InTransit = InTransit,
            Amount = Amount
        };
    }

    public class DimensionResponse
    {
        [JsonPropertyName("shape")]
        public string Shape { get; set; }

        [JsonPropertyName("netto_weight")]
        public double NetWeight { get; set; }

        [JsonPropertyName("gross_weight")]
        public double GrossWeight { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("diameter")]
        public double Diameter { get; set; }

        [JsonPropertyName("length")]
        public double Length { get; set; }
    }

    public ProductTable Get() => new()
    {
        Id = Id,
        Name = Name,
        CategoryId = Category?.Id,
        CategoryName = Category?.Name,
        BoxTypeId = BoxTypeId,
        BoxItem = BoxItem,
        BoxItemBarcode = BoxItemBarcode,
        UnitMeasurementId = UnitMeasurementId,
        Sku = Sku,
        Barcode = Barcode,
        Barcodes = Barcodes.Select(it => it.Get()).ToList(),
        Image = Image,
        IsMarked = IsMarked,
        IsProduct = IsProduct,
        IsMaterial = IsMaterial,
        IsSemiProduct = IsSemiProduct,
        TaxIds = TaxIds,
        Shape = Dimension?.Shape,
        NetWeight = Dimension?.NetWeight ?? 0.0,
        GrossWeight = Dimension?.GrossWeight ?? 0.0,
        Height = Dimension?.Height ?? 0.0,
        Width = Dimension?.Width ?? 0.0,
        Volume = Dimension?.Volume ?? 0.0,
        Diameter = Dimension?.Diameter ?? 0.0,
        Length = Dimension?.Length ?? 0.0,
        Suppliers = Suppliers.Select(it => new ProductTable.Supplier { Id = it.Id, Name = it.Name }).ToList()
    };

}

