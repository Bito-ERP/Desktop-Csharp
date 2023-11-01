using BitoDesktop.Domain.Entities.Pos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Pos;

public class PosRepository
{
    private const string PageColumns = "Id, OrganizationId, \"Order\", Name";
    private const string PageValues = "@Id, @OrganizationId, @Order, @Name";
    private const string PageUpdate = "OrganizationId = @OrganizationId, \"Order\" = @Order, Name = @Name";

    private const string PageItemColumns = "Id, Type, \"Order\", PageId, ItemId, ItemName, ItemImage, ProductUnitMeasurementId, ProductSku, ProductBarcode, IsMarked, AmountInBox, ProductCategoryId, ProductCategoryName, CategoryChildCount, DiscountValue, DiscountCurrencyId";
    private const string PageItemValues = "@Id, @Type, @Order, @PageId, @ItemId, @ItemName, @ItemImage, @ProductUnitMeasurementId, @ProductSku, @ProductBarcode, @IsMarked, @AmountInBox, @ProductCategoryId, @ProductCategoryName, @CategoryChildCount, @DiscountValue, @DiscountCurrencyId";
    private const string PageItemUpdate = "Type = @Type, \"Order\" = @Order, PageId = @PageId, ItemId = @ItemId, ItemName = @ItemName, ItemImage = @ItemImage, ProductUnitMeasurementId = @ProductUnitMeasurementId, ProductSku = @ProductSku, ProductBarcode = @ProductBarcode, IsMarked = @IsMarked, AmountInBox = @AmountInBox, ProductCategoryId = @ProductCategoryId, ProductCategoryName = @ProductCategoryName, CategoryChildCount = @CategoryChildCount, DiscountValue = @DiscountValue, DiscountCurrencyId = @DiscountCurrencyId";


    public async Task<int> Insert(Page item)
    {
        return await DBExcutor.ExecuteAsync(
             "INSERT INTO pos_page(" + PageColumns + ") VALUES(" + PageValues + ") " +
             "ON CONFLICT (Id) " +
             "DO UPDATE SET " + PageUpdate, item);
    }

    public async Task ReplaceAll([Required] string organizationId, IEnumerable<Page> items)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM pos_page WHERE OrganizationId = @organizationId", new { organizationId }, connection);
            await DBExcutor.ExecuteAsync(
             "INSERT INTO pos_page(" + PageColumns + ") VALUES(" + PageValues + ") " +
             "ON CONFLICT (Id) " +
             "DO UPDATE SET " + PageUpdate, items, connection);
        });
    }

    public async Task<int> Insert(PageItem item)
    {
        return await DBExcutor.ExecuteAsync(
             "INSERT INTO pos_page_item(" + PageItemColumns + ") VALUES(" + PageItemValues + ") " +
             "ON CONFLICT (Id) " +
             "DO UPDATE SET " + PageItemUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<PageItem> items)
    {
        return await DBExcutor.ExecuteAsync(
             "INSERT INTO pos_page_item(" + PageItemColumns + ") VALUES(" + PageItemValues + ") " +
             "ON CONFLICT (Id) " +
             "DO UPDATE SET " + PageItemUpdate, items);
    }


    public async Task<int> UpdatePageName(string pageId, string name)
    {
        return await DBExcutor.ExecuteAsync(
             "UPDATE pos_page SET Name = @name WHERE Id = @pageId",
             new { pageId, name }
             );
    }

    public async Task<int> UpdatePageOrder(string pageId, int order)
    {
        return await DBExcutor.ExecuteAsync(
           "UPDATE pos_page SET \"Order\" = @order WHERE Id = @pageId",
           new { pageId, order }
           );
    }

    public async Task<int> UpdatePageItemOrder(string pageItemId, int order)
    {
        return await DBExcutor.ExecuteAsync(
           "UPDATE pos_page_item SET \"Order\" = @order WHERE Id = @pageItemId",
           new { pageItemId, order }
           );
    }

    public async Task<int> DeletePage(string pageId)
    {
        return await DBExcutor.ExecuteAsync(
           "DELETE FROM pos_page WHEReE Id = @pageId",
           new { pageId }
           );
    }

    public async Task<int> DeletePageItem(string pageItemId)
    {
        return await DBExcutor.ExecuteAsync(
           "DELETE FROM pos_page_item WHEReE Id = @pageItemId",
           new { pageItemId }
           );
    }

    public async Task<int> DeleteAllPageItems(string pageId)
    {
        return await DBExcutor.ExecuteAsync(
           "DELETE FROM pos_page_item WHEReE PageId = @pageId",
           new { pageId }
           );
    }

    public async Task<IEnumerable<PageItem>> GetItems(
        [Required] string pageId,
        [Required] string organizationId,
        [Required] string warehouseId,
        [Required] string priceId
        )
    {
        var query = new StringBuilder("SELECT item.*, ")
           .Append("IFNULL(price.PriceAmount, 0) as SelectedPriceAmount, ")
           .Append("IFNULL(warehouse.Amount, 0) as ProductWarehouseAmount ,")
           .Append("org.YellowLine as ProductYellowLine, org.RedLine as ProductRedLine ")
           .Append("FROM pos_page_item item ")
           .Append("JOIN product_organization org ON item.Type == 1 AND org.OrganizationId = @organizationId AND org.ProductId = item.ItemId ")
           .Append("LEFT JOIN product_price price ON item.Type == 1 AND price.PriceId = @priceId AND price.OrganizationId = @organizationId AND price.ProductId = item.ItemId ")
           .Append("LEFT JOIN product_warehouse warehouse ON item.Type == 1 AND warehouse.WarehouseId = @warehouseId AND warehouse.ProductId = item.ItemId ");
        var args = new Dictionary<string, object>();
        args["@organizationId"] = organizationId;
        args["@priceId"] = priceId;
        args["@warehouseId"] = warehouseId;

        query.Append("WHERE PageId = @pageId ");
        args["@pageId"] = pageId;

        query.Append("ORDER BY \"Order\" ASC");

        return await DBExcutor.QueryAsync<PageItem>(
            query.ToString(),
            args
            );
    }

}

