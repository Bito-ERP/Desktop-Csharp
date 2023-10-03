using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Service.DTOs.Common;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Pos;
internal class PageItemResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("is_product")]
    public bool IsProduct { get; set; }

    [JsonPropertyName("is_material")]
    public bool IsMaterial { get; set; }

    [JsonPropertyName("is_category")]
    public bool IsCategory { get; set; }

    [JsonPropertyName("is_discount")]
    public bool IsDiscount { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("item")]
    public Product Item { get; set; }

    [JsonPropertyName("category")]
    public CategoryResponse Category { get; set; }

    [JsonPropertyName("discount")]
    public DiscountResponse Discount { get; set; }

    public PageItem Get(string pageId)
    {
        if (IsProduct)
        {
            return PageItem.CreateProduct(
                Id,
                Order,
                pageId,
                Item.Id,
                Item.Name,
                Item.Image,
                Item.UnitMeasurementId,
                Item.Sku,
                Item.Barcode,
                Item.IsMarked,
                Item.BoxItem,
                Item.Category?.Id,
                Item.Category?.Name
            );
        }
        else if (IsCategory)
        {
            return PageItem.CreateCategory(
                Id,
                Order,
                pageId,
                Category.Id,
                Category.Name,
                Category.Image,
                Category.ChildCount
            );
        }
        else
        {
            return PageItem.CreateDiscount(
                Id,
                Order,
                pageId,
                Discount.Id,
                Discount.Name,
                Discount.Value,
                Discount.CurrencyId
            );
        }
    }

    public class Product
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("measure_id")]
        public string UnitMeasurementId { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("is_marked")]
        public bool IsMarked { get; set; }

        [JsonPropertyName("box_item")]
        public double? BoxItem { get; set; }

        [JsonPropertyName("category")]
        public DataResponse Category { get; set; }
    }

    public class CategoryResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("child_count")]
        public int ChildCount { get; set; }
    }

    public class DiscountResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("apply_type")]
        public string ApplyType { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }
    }
}
