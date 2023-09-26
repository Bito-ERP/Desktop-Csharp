using BitoDesktop.Domain.Commons;
using System.Collections.Generic;

namespace BitoDesktop.Domain.Entities.Products;

public class ProductOrganization
{
    public string organizationId { get; set; }
    public string productId { get; set; }
    public double amount { get; set; }
    public double inTransit { get; set; }
    public double trash { get; set; }
    public double booked { get; set; } 
    public double? _yellowLine { get; set; }
    public double? _redLine { get; set; }
    public double? _maxStock { get; set; }
    public bool isAvailable { get; set; }
    public bool _isAvailableForSale { get; set; }
}

public class ProductPrice
{
    public string _id { get; set; }
    public string priceId { get; set; }
    public string organizationId { get; set; }
    public string productId { get; set; }
    public double priceAmount { get; set; }
    public double? minPrice { get; set; }
    public double? maxPrice { get; set; }
    public double? minSaleAmount { get; set; }
}

public class ProductWarehouse
{
    public string _id { get; set; }
    public string warehouseId { get; set; }
    public string organizationId { get; set; }
    public string productId { get; set; }
    public double booked { get; set; }
    public double inTrash { get; set; }
    public double inTransit { get; set; }
    public double amount { get; set; }
}

public class Product
{
    public string id { get; set; }
    public string name { get; set; }
    public string? categoryId { get; set; }
    public string? categoryName { get; set; }
    public string? boxTypeId { get; set; }
    public double boxItem { get; set; }
    public string? boxItemBarcode { get; set; }
    public string unitMeasurementId { get; set; }
    public string sku { get; set; }
    public string? barcode { get; set; }
    public List<ProductTable.Barcode> barcodes { get; set; }
    public string? image { get; set; }
    public bool isMarked { get; set; }
    public bool isProduct { get; set; }
    public bool isMaterial { get; set; }
    public bool isSemiProduct { get; set; }
    public StringList taxIds { get; set; }
    public string? shape { get; set; }
    public double netWeight { get; set; }
    public double grossWeight { get; set; }
    public double height { get; set; }
    public double width { get; set; }
    public double volume { get; set; }
    public double diameter { get; set; }
    public double length { get; set; }
    public List<ProductTable.Supplier> suppliers { get; set; }
    public double warehouseAmount { get; set; }
    public double organizationAmount { get; set; }
    public double maxStock { get; set; }
    public double yellowLine { get; set; }
    public double redLine { get; set; }
    public bool isAvailableForSale { get; set; }
    public string? selectedPriceId { get; set; }
    public double selectedPriceAmount { get; set; }
    public string? selectedPriceCurrencyId { get; set; }
    public double booked { get; set; }
    public double inTrash { get; set; }
    public double inTransit { get; set; }
    public List<ProductTable.Price> prices { get; set; } = null;
}

public class ProductTable
{
    public string id { get; set; }
    public string name { get; set; }
    public string? categoryId { get; set; }
    public string? categoryName { get; set; }
    public string? boxTypeId { get; set; }
    public double boxItem { get; set; }
    public string? boxItemBarcode { get; set; }
    public string unitMeasurementId { get; set; }
    public string sku { get; set; }
    public string? barcode { get; set; }
    public List<Barcode> barcodes { get; set; }
    public string? image { get; set; }
    public bool isMarked { get; set; }
    public bool isProduct { get; set; }
    public bool isMaterial { get; set; }
    public bool isSemiProduct { get; set; }
    public StringList taxIds { get; set; }
    public string? shape { get; set; }
    public double netWeight { get; set; }
    public double grossWeight { get; set; }
    public double height { get; set; }
    public double width { get; set; }
    public double volume { get; set; }
    public double diameter { get; set; }
    public double length { get; set; }
    public List<Supplier> suppliers { get; set; }

    public class Price
    {
        public string priceId { get; set; }
        public double? selectedPriceAmount { get; set; }

    }

    public class Barcode
    {
        public string barcode { get; set; }
        public bool isActive { get; set; }

    }

    public class Supplier
    {
        public string id { get; set; }
        public string name { get; set; }

    }
}