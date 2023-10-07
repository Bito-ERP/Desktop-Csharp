using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.DTOs.Common;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.WarehouseP;

public class ProductResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("category")]
    public DataResponse Category { get; set; }

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
    public DimensionResponse Dimension { get; set; }

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

        public ProductTable.BarcodeItem Get() => new ProductTable.BarcodeItem
        {
            Barcode = Barcode,
            IsActive = IsActive
        };
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
        [JsonProperty("shape")]
        public string Shape { get; set; }

        [JsonProperty("netto_weight")]
        public double NetWeight { get; set; }

        [JsonProperty("gross_weight")]
        public double GrossWeight { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("diameter")]
        public double Diameter { get; set; }

        [JsonProperty("length")]
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

