using BitoDesktop.Data.IRepositories;
using BitoDesktop.Domain.Entities.Products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BitoDesktop.Data.Repositories.WarehouseP;

public class ProductRepository : IProductRepository
{

    private const string ProductColumns = "Id, Name, CategoryId, CategoryName, BoxTypeId, BoxItem, BoxItemBarcode, UnitMeasurementId, Sku, Barcode, Barcodes, Image, IsMarked, IsProduct, IsMaterial, IsSemiProduct, TaxIds, Shape, NetWeight, GrossWeight, Height, Width, Volume, Diameter, Length, Suppliers";
    private const string ProductValues = "@Id, @Name, @CategoryId, @CategoryName, @BoxTypeId, @BoxItem, @BoxItemBarcode, @UnitMeasurementId, @Sku, @Barcode, @Barcodes, @Image, @IsMarked, @IsProduct, @IsMaterial, @IsSemiProduct, @TaxIds, @Shape, @NetWeight, @GrossWeight, @Height, @Width, @Volume, @Diameter, @Length, @Suppliers";
    private const string ProductUpdate = "Name = @Name, CategoryId = @CategoryId, CategoryName = @CategoryName, BoxTypeId = @BoxTypeId, BoxItem = @BoxItem, BoxItemBarcode = @BoxItemBarcode, UnitMeasurementId = @UnitMeasurementId, Sku = @Sku, Barcode = @Barcode, Barcodes = @Barcodes, Image = @Image, IsMarked = @IsMarked, IsProduct = @IsProduct, IsMaterial = @IsMaterial, IsSemiProduct = @IsSemiProduct, TaxIds = @TaxIds, Shape = @Shape, NetWeight = @NetWeight, GrossWeight = @GrossWeight, Height = @Height, Width = @Width, Volume = @Volume, Diameter = @Diameter, Length = @Length, Suppliers = @Suppliers";

    private const string ProductOrganizationColumns = "OrganizationId, ProductId, Amount, InTransit, Trash, Booked, YellowLine, RedLine, MaxStock, IsAvailable, IsAvailableForSale";
    private const string ProductOrganizationValues = "@OrganizationId, @ProductId, @Amount, @InTransit, @Trash, @Booked, @YellowLine, @RedLine, @MaxStock, @IsAvailable, @IsAvailableForSale";
    private const string ProductOrganizationUpdate = "Amount = @Amount, InTransit = @InTransit, Trash = @Trash, Booked = @Booked, YellowLine = @YellowLine, RedLine = @RedLine, MaxStock = @MaxStock, IsAvailable = @IsAvailable, IsAvailableForSale = @IsAvailableForSale";

    private const string ProductWarehouseColumns = "Id, WarehouseId, OrganizationId, ProductId, Booked, InTrash, InTransit, Amount";
    private const string ProductWarehouseValues = "@Id, @WarehouseId, @OrganizationId, @ProductId, @Booked, @InTrash, @InTransit, @Amount";
    private const string ProductWarehouseUpdate = "WarehouseId = @WarehouseId, OrganizationId = @OrganizationId, ProductId = @ProductId, Booked = @Booked, InTrash = @InTrash, InTransit = @InTransit, Amount = @Amount";

    private const string ProductPriceColumns = "Id, PriceId, OrganizationId, ProductId, PriceAmount, MinPrice, MaxPrice, MinSaleAmount";
    private const string ProductPriceValues = "@Id, @PriceId, @OrganizationId, @ProductId, @PriceAmount, @MinPrice, @MaxPrice, @MinSaleAmount";
    private const string ProductPriceUpdate = "PriceId = @PriceId, OrganizationId = @OrganizationId, ProductId = @ProductId, PriceAmount = @PriceAmount, MinPrice = @MinPrice, MaxPrice = @MaxPrice, MinSaleAmount = @MinSaleAmount";


    public ProductRepository()
    {
    }

    /*
    * merge all products' organization, warehouses and prices lists into one while mapping
    */
    public async Task Insert(
       IEnumerable<ProductTable> products,
       IEnumerable<ProductOrganization> organization,
       IEnumerable<ProductWarehouse> warehouses,
       IEnumerable<ProductPrice> prices
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await Insert(products, connection);
            await InsertOrganizations(organization, connection);
            await InsertWarehouses(warehouses, connection);
            await InsertPrices(prices, connection);
        });
    }

    // after receipt is created, increase/decrease amount of the products in the given warehouse
    public async void UpdateWarehouseAmount(
        bool inc, // true to increase, false to decrease
        List<Tuple<string, double>> productAmounts,  // {Id, amount which is addded to or subtrackted from product's original amount}
        string warehouseId
       )
    {
        var d = inc ? 1 : -1;
        using (var scope = new TransactionScope())
        {
            foreach (var item in productAmounts)
            {
                await UpdateWarehouseAmount(
                    d * item.Item2,
                    item.Item1,
                    warehouseId
                   );
            }
            scope.Complete();
        }
    }

    public async Task<int> Insert(ProductTable entity)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product(" + ProductColumns + ") VALUES(" + ProductValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + ProductUpdate, entity);
    }

    public async Task<int> Insert(IEnumerable<ProductTable> entities, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product(" + ProductColumns + ") VALUES(" + ProductValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + ProductUpdate, entities, connection);
    }

    public async Task<int> InsertOrganizations(IEnumerable<ProductOrganization> entities, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product_organization(" + ProductOrganizationColumns + ") VALUES(" + ProductOrganizationValues + ") " +
            "ON CONFLICT (OrganizationId, ProductId) " +
            "DO UPDATE SET " + ProductOrganizationUpdate, entities, connection);
    }

    public async Task<int> InsertWarehouses(IEnumerable<ProductWarehouse> entities, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product_warehouse(" + ProductWarehouseColumns + ") VALUES(" + ProductWarehouseValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + ProductWarehouseUpdate, entities, connection);
    }

    public async Task<int> InsertPrices(IEnumerable<ProductPrice> entities, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product_price(" + ProductPriceColumns + ") VALUES(" + ProductPriceValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + ProductPriceUpdate, entities, connection);
    }

    // when user deletes a product, just remove that product from organization, provide false to isAvailable
    public async Task<int> UpdateAvailability(
        string productId,
        string organizationId,
        bool isAvailable
    )
    {
        return await DBExcutor.ExecuteAsync(
             "UPDATE product_organization SET IsAvailable = @isAvailable WHERE ProductId = @productId AND OrganizationId = @organizationId",
             new { isAvailable, productId, organizationId }
           );
    }

    private Task<int> UpdateWarehouseAmount(
        double amount,
        string productId,
        string warehouseId
    )
    {
        return DBExcutor.ExecuteAsync(
             "UPDATE product_warehouse SET Amount = Amount + @amount WHERE ProductId = @productId AND WarehouseId = @warehouseId",
             new { amount, productId, warehouseId }
           );
    }

    public async Task<int> Delete(List<string> productIds)
    {
        return await DBExcutor.ExecuteAsync(
            "DELETE FROM product WHERE Id IN @productIds",
            new { productIds }
          );
    }

    public async Task<int> DeleteWarehouses(List<string> warehouseIds)
    {
        return await DBExcutor.ExecuteAsync(
            "DELETE FROM product_warehouse WHERE Id IN @warehouseIds",
            new { warehouseIds }
          );
    }

    public async Task<int> DeletePrices(List<string> priceIds)
    {
        return await DBExcutor.ExecuteAsync(
            "DELETE FROM product_price WHERE Id IN @priceIds",
            new { priceIds }
          );
    }

    //returns tax ids attached to the given product
    public async Task<List<string>> GetTaxes(string productId)
    {
        Contract.Requires(productId != null);
        return await DBExcutor.QuerySingleOrDefaultAsync<List<string>>(
            "SELECT taxIds FROM product WHERE Id = @productId",
            new { productId }
            );
    }

    //check if a product exists with the given barcode
    public async Task<bool> isExistByBarcode(string barcode)
    {
        Contract.Requires(barcode != null);
        return await DBExcutor.QuerySingleOrDefaultAsync<bool>(
            "SELECT EXISTS(SELECT Id FROM product WHERE B Barcode = @barcode)",
            new { barcode }
            );
    }

    public async Task<Product> GetById(
        string productId,
        string organizationId,
        string warehouseId,
        string priceId,
        bool withAmount,
        bool withPrices,
        bool withTax            // not yet implemented
        )
    {
        return await getProductBy(
            productId,
            0,
            organizationId,
            warehouseId,
            priceId,
            withAmount,
            withPrices,
            withTax
            );
    }

    // returns a product with the same 'sku'
    public async Task<Product> GetBySku(
       string sku,
       string organizationId,
       string warehouseId,
       string priceId,
       bool withAmount,
       bool withPrices,
       bool withTax            // not yet implemented
       )
    {
        return await getProductBy(
            sku,
            1,
            organizationId,
            warehouseId,
            priceId,
            withAmount,
            withPrices,
            withTax
            );
    }

    // returns a product with the same 'barcode' or if its 'barcodes' contains the given value
    public async Task<Product> GetByBarcode(
       string barcode,
       string organizationId,
       string warehouseId,
       string priceId,
       bool withAmount,
       bool withPrices,
       bool withTax            // not yet implemented
       )
    {
        return await getProductBy(
            barcode,
            2,
            organizationId,
            warehouseId,
            priceId,
            withAmount,
            withPrices,
            withTax
            );
    }

    // returns a product with the same 'barcode' or if its 'barcodes' contains the given value
    public async Task<List<Product>> GetMultiple(
        string value,
        string organizationId,
        string warehouseId,
        string priceId,
        bool withAmount,        //  true, infos of product related to given organization will be added
        bool withPrices,        // true, prices of product will be added to response
        bool withTax            // not yet implemented
   )
    {
        return await getProductBy(
            value,
            0,
            organizationId,
            warehouseId,
            priceId,
            withAmount,
            withPrices,
            withTax,
            false
            );
    }

    // GetByCategories(true, {}, ...), returns all products that have a 'categoryId'
    // GetByCategories(false/true, {id1, id2, id3 ...}, ...), returns products that have at least one of the given categories
    public async Task<List<Product>> GetByCategories(
        bool isAll,
        string[] value,
        string organizationId,
        string warehouseId,
        string priceId,
        bool withAmount,         //  true, infos of product related to given organization will be added
        bool withPrices,         // true, prices of product will be added to response
        bool withTax            // not yet implemented
   )
    {
        return await getProductBy(
            value,
            1,
            organizationId,
            warehouseId,
            priceId,
            withAmount,
            withPrices,
            withTax,
            isAll
            );
    }

    public async Task<IEnumerable<Product>> GetProducts(
        string organizationId,
        string warehouseId,
        bool? isProduct, // pass null to exclude this param from the filter
        bool? isMaterial, // pass null to exclude this param from the filter
        bool? isSemiProduct, // pass null to exclude this param from the filter
        bool? isAvailableForSale, // pass null to exclude this param from the filter
        string searchQuery,
        string priceId,        // provide price id to get price of product, it is returndes as SelectedPriceAmount
        string inStockState, // null, 'yellow_line', 'red_line' or 'negative'
        string categoryId, // filter by category
        bool withOrganizationAmount,  //  true, info of product related to given organization will be added
        bool filterByWarehouse, // true, return products that exist only in the specified warehouse
        bool filterByPrice,     // true, return products that have the specified price
        bool excludeOutOfStockProducts, // true, exclude products that are oud of stock
        int? offset = null,
        int? limit = null
        )
    {
        var args = new Dictionary<string, object>();

        var query = getProductQuery(
            args,
            organizationId,
            warehouseId,
            isProduct,
            isMaterial,
            isSemiProduct,
            isAvailableForSale,
            searchQuery,
            priceId,
            inStockState,
            categoryId,
            withOrganizationAmount,
            filterByWarehouse,
            filterByPrice,
            excludeOutOfStockProducts,
            offset,
            limit
            );

        query.Append(
           "ORDER BY p.Name "
       ).Append(
            "LIMIT @limit "
        ).Append(
            "OFFSET @offset "
        );

        args["@limit"] = limit;
        args["@offset"] = offset;

        return await DBExcutor.QueryAsync<Product>(query.ToString(), args);
    }


    public async Task<IEnumerable<double>> getProductPrices(
        List<string> products,
        string organizationId,
        string priceId
        )
    {

        Contract.Requires(products != null);
        Contract.Requires(organizationId != null);
        Contract.Requires(priceId != null);

        var query = new StringBuilder("SELECT COALESCE(price.PriceAmount, 0) as SelectedPriceAmount ");
        var args = new Dictionary<string, object>();

        query.Append("FROM product as p ");

        query.Append("LEFT JOIN product_price price ON price.PriceId = @priceId AND price.OrganizationId = @organizationId AND price.ProductId = p.Id ");
        args["@priceId"] = priceId;
        args["@organizationId"] = organizationId;

        query.Append("WHERE p.Id IN @products");
        args["@products"] = products;

        return await DBExcutor.QueryAsync<double>(query.ToString(), args);
    }


    public async Task<ProductPrice> GetProductPrice(
        string priceId,
        string organizationId,
        string productId
        )
    {
        Contract.Requires(priceId != null);
        Contract.Requires(organizationId != null);
        Contract.Requires(productId != null);

        return await DBExcutor.QuerySingleOrDefaultAsync<ProductPrice>(
            "SELECT * FROM product_price WHERE PriceId = @priceId AND OrganizationId = @organizationId AND ProductId = @productId",
            new { priceId, organizationId, productId }
            );
    }

    private async Task<IEnumerable<ProductTable.Price>> GetPrices(
          Dictionary<string, object> args,
          string organizationId,
          string productId
        )
    {
        args.Clear();
        args["@organizationId"] = organizationId;
        args["@productId"] = productId;

        return await DBExcutor.QueryAsync<ProductTable.Price>(
            "SELECT PriceId as PriceId, PriceAmount as SelectedPriceAmount FROM product_price WHERE OrganizationId = @organizationId AND ProductId = @productId",
            args
           );
    }

    private async Task<Product> getProductBy(
        string byValue,
        int type,
        string organizationId,
        string warehouseId,
        string priceId,
        bool withAmount,
        bool withPrices,
        bool withTax
        )
    {
        var query = new StringBuilder("SELECT p.* ");
        var args = new Dictionary<string, object>();

        MakeGetQuery(
            query, args, organizationId, warehouseId, priceId, withAmount
        );

        query.Append(
            type == 0 ?
             "p.Id = @byvalue " :
             type == 1 ?
             "p.Sku = @byvalue " :

             "p.Barcode = @byValue OR " +
                    "p.Barcodes LIKE @byValue2 "
        );
        args["@byValue"] = byValue;

        if (type == 2)
            args["@byValue2"] = "%" + byValue + "%";

        var entity = await DBExcutor.QuerySingleOrDefaultAsync<Product>(
            query.ToString(),
            args
            );

        if (withPrices && entity != null)
            entity.Prices = (await GetPrices(args, organizationId!, entity.Id)).ToList();

        return entity;
    }

    private async Task<List<Product>> getProductBy(
      object byValue,
      int type,
      string organizationId,
      string warehouseId,
      string priceId,
      bool withAmount,
      bool withPrices,
      bool withTax,
      bool isAll
      )
    {
        var query = new StringBuilder("SELECT p.* ");
        var args = new Dictionary<string, object>();

        MakeGetQuery(
            query, args, organizationId, warehouseId, priceId, withAmount
        );

        if (type == 0)
        {
            query.Append("(p.Sku = @byValue OR p.Barcode = @byValue OR p.Barcodes LIKE @byValue2 ) ");
            args["@byValue"] = byValue;
            args["@byValue2"] = "%" + byValue + "%";
        }
        else if (type == 1)
        {
            var itemIds = (string[])byValue;
            if (isAll && itemIds.Length == 0)
                query.Append("p.CategoryId IS NOT NULL");
            else
            {
                if (isAll)
                    query.Append("p.CategoryId NOT IN @itemIds");
                else
                    query.Append("p.CategoryId IN @itemIds");
                args["@itemIds"] = itemIds;
            }
        }

        var entities = (await DBExcutor.QueryAsync<Product>(
            query.ToString(),
            args
            )).ToList();

        if (withPrices && entities != null)
            entities.ForEach(async p =>
            {
                p.Prices = (await GetPrices(args, organizationId!, p.Id)).ToList();
            });


        return entities;
    }


    private StringBuilder getProductQuery(
        Dictionary<string, object> args,
        string organizationId,
        string warehouseId,
        bool? isProduct, // pass null to exclude this param from the filter
        bool? isMaterial, // pass null to exclude this param from the filter
        bool? isSemiProduct, // pass null to exclude this param from the filter
        bool? isAvailableForSale, // pass null to exclude this param from the filter
        string searchQuery,
        string priceId,
        string inStockState, // null, 'yellow_line', 'red_line' or 'negative'
        string categoryId,
        bool withOrganizationAmount, //  true, infos of product related to given organization will be added
        bool filterByWarehouse, // true, return products that exist only in the specified warehouse
        bool filterByPrice,     // true, return products that have the specified price
        bool excludeOutOfStockProducts, // true, exclude products that are oud of stock
        int? offset = null,
        int? limit = null
        )
    {

        bool filtered = false;

        StringBuilder query = new StringBuilder("SELECT p.*, org.Amount as OrganizationAmount ");

        if (withOrganizationAmount)
            query.Append(", org.YellowLine as YellowLine, ")
               .Append("org.RedLine as RedLine, ")
               .Append("org.MaxStock as MaxStock, ")
               .Append("org.IsAvailableForSale as IsAvailableForSale");

        if (warehouseId == null)
            query.Append(", COALESCE(org.Amount, 0) as WarehouseAmount ");
        else
            query.Append(", COALESCE(warehouse.Amount, 0) as WarehouseAmount ");

        if (priceId != null)
            query.Append(", COALESCE(price.PriceAmount, 0) as SelectedPriceAmount ");

        query.Append("FROM product as p ");

        query.Append("JOIN product_organization org ON org.IsAvailable = TRUE AND org.OrganizationId = @organizationId AND org.ProductId = p.Id ");
        args["@organizationId"] = organizationId;

        if (warehouseId != null)
        {
            query.Append(filterByWarehouse == true ? "JOIN " : "LEFT JOIN ");

            query.Append("product_warehouse warehouse ON warehouse.WarehouseId = @warehouseId AND warehouse.ProductId = p.Id ");
            args["@warehouseId"] = warehouseId;
        }

        if (priceId != null)
        {
            query.Append(filterByPrice == true ? "JOIN " : "LEFT JOIN ");

            query.Append("product_price price ON price.PriceId = @priceId AND price.OrganizationId = @organizationId AND price.ProductId = p.Id ");
            args["@priceId"] = priceId;
        }

        query.Append("WHERE ");

        if (isProduct != null)
        {
            filtered = true;
            query.Append("p.IsProduct = @isProduct AND ");
            args["@isProduct"] = isProduct;
        }
        if (isMaterial != null)
        {
            filtered = true;
            query.Append("p.IsMaterial = @isMaterial AND ");
            args["@isMaterial"] = isMaterial;
        }
        if (isSemiProduct != null)
        {
            filtered = true;
            query.Append("p.IsSemiProduct = @isSemiProduct AND ");
            args["@isSemiProduct"] = isSemiProduct;
        }
        if (isAvailableForSale != null)
        {
            filtered = true;
            query.Append("org.IsAvailableForSale = @isAvailableForSale AND ");
            args["@isAvailableForSale"] = isAvailableForSale;
        }


        if (categoryId != null)
        {
            filtered = true;
            query.Append("p.CategoryId = @categoryId AND ");
            args["@categoryId"] = categoryId;
        }

        if (inStockState != null)
        {
            filtered = true;
            if (inStockState == "YellowLine")
                query.Append(
                    "org.Amount>org.RedLine AND " +
                            "org.Amount<=org.YellowLine AND "
                );
            else if (inStockState == "RedLine")
                query.Append(
                    "org.Amount<=org.RedLine AND " +
                            "org.Amount>=0 AND "
                );
            else
                query.Append(
                    "org.Amount<=0 AND "
                );
        }

        if (excludeOutOfStockProducts)
            query.Append("WarehouseAmount > 0 AND ");

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var transliterator = new Transliterator(searchQuery);
            var native = "%" + transliterator.Native() + "%";
            var transliterated = "%" + transliterator.Transliterated() + "%";

            query.Append(
                "(LOWER(p.Name) LIKE @native OR " +
                        "LOWER(p.Name) LIKE @transliterated OR " +
                        "p.Barcode LIKE @native OR " +
                        "p.Sku LIKE @native OR " +
                        "p.Barcodes LIKE @native) "
            );
            args["@native"] = native;
            args["@transliterated"] = transliterated;
        }
        else if (filtered)
            query.Remove(
                query.Length - 4,
                4
            );
        else
            query.Remove(
                query.Length - 6,
                6
            );

        return query;
    }

    private void MakeGetQuery(
        StringBuilder query,
        Dictionary<string, object> args,
        string organizationId,
        string warehouseId,
        string priceId,
        bool withAmount
        )
    {
        if (withAmount)
        {
            if (warehouseId == null)
            {
                query.Append(", org.Amount as WarehouseAmount ");
            }
            query.Append(", org.Amount as OrganizationAmount, ")
                .Append("org.YellowLine as YellowLine, ")
                .Append("org.RedLine as RedLine, ")
                .Append("org.MaxStock as MaxStock, ")
                .Append("org.IsAvailableForSale as IsAvailableForSale ");
        }

        if (warehouseId != null)
        {
            query.Append(", warehouse.Amount as WarehouseAmount, ")
                .Append("warehouse.Booked as Booked, ")
                .Append("warehouse.InTrash as InTrash, ")
                .Append("warehouse.InTransit as InTransit ");
        }

        if (priceId != null)
            query.Append(", COALESCE(price.PriceAmount, 0) as SelectedPriceAmount ");

        query.Append("FROM product AS p ");

        var filterByOrganization = false;

        if (withAmount)
        {
            query.Append("JOIN product_organization AS org ON org.IsAvailable = TRUE AND org.OrganizationId = @organizationId AND org.ProductId = p.Id ");
            args["@organizationId"] = organizationId;
            filterByOrganization = true;
        }

        if (warehouseId != null)
        {
            query.Append("LEFT JOIN product_warehouse AS warehouse ON warehouse.WarehouseId = @warehouseId AND warehouse.ProductId = p.Id ");
            args["@warehouseId"] = warehouseId;
        }

        if (priceId != null)
        {
            query.Append("LEFT JOIN product_price AS price ON price.PriceId = @priceId AND price.OrganizationId = @organizationId AND price.ProductId = p.Id ");
            args["@priceId"] = priceId;
            args["@organizationId"] = organizationId;
        }

        if (!filterByOrganization)
        {
            query.Append("JOIN product_organization AS org ON org.IsAvailable = TRUE AND org.OrganizationId = @organizationId AND org.ProductId = p.Id ");
            args["@organizationId"] = organizationId;
        }

        query.Append("WHERE ");
    }


}
