using System.Collections.Generic;

namespace BitoDesktop.Domain.Entities.Products
{
    public class ProductOrganization
    {
        public string OrganizationId { get; set; }
        public string ProductId { get; set; }
        public double Amount { get; set; }
        public double InTransit { get; set; }
        public double Trash { get; set; }
        public double Booked { get; set; }
        public double? YellowLine { get; set; }
        public double? RedLine { get; set; }
        public double? MaxStock { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsAvailableForSale { get; set; }
    }

    public class ProductPrice
    {
        public string Id { get; set; }
        public string PriceId { get; set; }
        public string OrganizationId { get; set; }
        public string ProductId { get; set; }
        public double PriceAmount { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public double? MinSaleAmount { get; set; }
    }

    public class ProductWarehouse
    {
        public string Id { get; set; }
        public string WarehouseId { get; set; }
        public string OrganizationId { get; set; }
        public string ProductId { get; set; }
        public double Booked { get; set; }
        public double InTrash { get; set; }
        public double InTransit { get; set; }
        public double Amount { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BoxTypeId { get; set; }
        public double BoxItem { get; set; }
        public string BoxItemBarcode { get; set; }
        public string UnitMeasurementId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public List<ProductTable.BarcodeItem> Barcodes { get; set; }
        public string Image { get; set; }
        public bool IsMarked { get; set; }
        public bool IsProduct { get; set; }
        public bool IsMaterial { get; set; }
        public bool IsSemiProduct { get; set; }
        public List<string> TaxIds { get; set; }
        public string Shape { get; set; }
        public double NetWeight { get; set; }
        public double GrossWeight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Volume { get; set; }
        public double Diameter { get; set; }
        public double Length { get; set; }
        public List<ProductTable.Supplier> Suppliers { get; set; }
        public double WarehouseAmount { get; set; }
        public double OrganizationAmount { get; set; }
        public double MaxStock { get; set; }
        public double YellowLine { get; set; }
        public double RedLine { get; set; }
        public bool IsAvailableForSale { get; set; }
        public string SelectedPriceId { get; set; }
        public double SelectedPriceAmount { get; set; }
        public string SelectedPriceCurrencyId { get; set; }
        public double Booked { get; set; }
        public double InTrash { get; set; }
        public double InTransit { get; set; }
        public List<ProductTable.Price> Prices { get; set; } = null;
    }

    public class ProductTable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BoxTypeId { get; set; }
        public double BoxItem { get; set; }
        public string BoxItemBarcode { get; set; }
        public string UnitMeasurementId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public List<BarcodeItem> Barcodes { get; set; }
        public string Image { get; set; }
        public bool IsMarked { get; set; }
        public bool IsProduct { get; set; }
        public bool IsMaterial { get; set; }
        public bool IsSemiProduct { get; set; }
        public List<string> TaxIds { get; set; }
        public string Shape { get; set; }
        public double NetWeight { get; set; }
        public double GrossWeight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Volume { get; set; }
        public double Diameter { get; set; }
        public double Length { get; set; }
        public List<Supplier> Suppliers { get; set; }

        public class Price
        {
            public string PriceId { get; set; }
            public double? SelectedPriceAmount { get; set; }
        }

        public class BarcodeItem
        {
            public string Barcode { get; set; }
            public bool IsActive { get; set; }
        }

        public class Supplier
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
