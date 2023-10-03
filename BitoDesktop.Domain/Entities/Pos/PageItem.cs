namespace BitoDesktop.Domain.Entities.Pos;
public class PageItem
{
    public string Id { get; set; }

    public int Type { get; set; }
    public int Order { get; set; }
    public string PageId { get; set; }

    // Common
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public string ItemImage { get; set; }

    // Item
    public string ProductUnitMeasurementId { get; set; }
    public string ProductSku { get; set; }
    public string ProductBarcode { get; set; }
    public bool? IsMarked { get; set; }
    public double? AmountInBox { get; set; }
    public string ProductCategoryId { get; set; }
    public string ProductCategoryName { get; set; }

    // Category
    public int? CategoryChildCount { get; set; }

    // Discount
    public float? DiscountValue { get; set; }
    public string DiscountCurrencyId { get; set; }

    public static PageItem CreateProduct(
        string id,
        int order,
        string pageId,
        string productId,
        string name,
        string image,
        string unitMeasurement,
        string sku,
        string barcode,
        bool isMarked,
        double? amountInBox,
        string categoryId,
        string categoryName)
    {
        return new PageItem
        {
            Id = id,
            Type = 1,
            Order = order,
            PageId = pageId,
            ItemId = productId,
            ItemName = name,
            ItemImage = image,
            ProductUnitMeasurementId = unitMeasurement,
            ProductSku = sku,
            ProductBarcode = barcode,
            IsMarked = isMarked,
            AmountInBox = amountInBox,
            ProductCategoryId = categoryId,
            ProductCategoryName = categoryName
        };
    }

    public static PageItem CreateCategory(
        string id,
        int order,
        string pageId,
        string categoryId,
        string name,
        string image,
        int childCount)
    {
        return new PageItem
        {
            Id = id,
            Type = 2,
            Order = order,
            PageId = pageId,
            ItemId = categoryId,
            ItemName = name,
            ItemImage = image,
            CategoryChildCount = childCount
        };
    }

    public static PageItem CreateDiscount(
        string id,
        int order,
        string pageId,
        string discountId,
        string name,
        float value,
        string currencyId)
    {
        return new PageItem
        {
            Id = id,
            Type = 3,
            Order = order,
            PageId = pageId,
            ItemId = discountId,
            ItemName = name,
            DiscountValue = value,
            DiscountCurrencyId = currencyId
        };
    }

}
