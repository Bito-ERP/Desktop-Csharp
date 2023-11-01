using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Pos;
public class PageItemResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("is_product")]
    public bool IsProduct { get; set; }

    [JsonProperty("is_material")]
    public bool IsMaterial { get; set; }

    [JsonProperty("is_category")]
    public bool IsCategory { get; set; }

    [JsonProperty("is_discount")]
    public bool IsDiscount { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("item")]
    public Product Item { get; set; }

    [JsonProperty("category")]
    public CategoryResponse Category { get; set; }

    [JsonProperty("discount")]
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
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("measure_id")]
        public string UnitMeasurementId { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("is_marked")]
        public bool IsMarked { get; set; }

        [JsonProperty("box_item")]
        public double? BoxItem { get; set; }

        [JsonProperty("category")]
        public DataResponse Category { get; set; }
    }

    public class CategoryResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("child_count")]
        public int ChildCount { get; set; }
    }

    public class DiscountResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apply_type")]
        public string ApplyType { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }
    }
}