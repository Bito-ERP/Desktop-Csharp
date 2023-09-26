using BitoDesktop.Data.IRepositories;
using BitoDesktop.Domain.Entities.Products;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;
using System;
using BitoDesktop.Domain.Entities;
using System.Diagnostics.Contracts;
using System.Text;
using BitoDesktop.Data.Converters;
using Dapper;

namespace BitoDesktop.Data.Repositories;

public class ProductRepository : IProductRepository
{

    private const string productColumns = "id, name, categoryId, categoryName, boxTypeId, boxItem, boxItemBarcode, unitMeasurementId, sku, barcode, barcodes, image, isMarked, isProduct, isMaterial, isSemiProduct, taxIds, shape, netWeight, grossWeight, height, width, volume, diameter, length, suppliers";
    private const string productValues = "@id, @name, @categoryId, @categoryName, @boxTypeId, @boxItem, @boxItemBarcode, @unitMeasurementId, @sku, @barcode, @barcodes, @image, @isMarked, @isProduct, @isMaterial, @isSemiProduct, @taxIds, @shape, @netWeight, @grossWeight, @height, @width, @volume, @diameter, @length, @suppliers";
    private const string productUpdate = "name = @name, categoryId = @categoryId, categoryName = @categoryName, boxTypeId = @boxTypeId, boxItem = @boxItem, boxItemBarcode = @boxItemBarcode, unitMeasurementId = @unitMeasurementId, sku = @sku, barcode = @barcode, barcodes = @barcodes, image = @image, isMarked = @isMarked, isProduct = @isProduct, isMaterial = @isMaterial, isSemiProduct = @isSemiProduct, taxIds = @taxIds, shape = @shape, netWeight = @netWeight, grossWeight = @grossWeight, height = @height, width = @width, volume = @volume, diameter = @diameter, length = @length, suppliers = @suppliers";

    private const string productOrganizationColumns = "organizationId, productId, amount, inTransit, trash, booked, _yellowLine, _redLine, _maxStock, isAvailable, _isAvailableForSale";
    private const string productOrganizationValues = "@organizationId, @productId, @amount, @inTransit, @trash, @booked, @_yellowLine, @_redLine, @_maxStock, @isAvailable, @_isAvailableForSale";
    private const string productOrganizationUpdate = "amount = @amount, inTransit = @inTransit, trash = @trash, booked = @booked, _yellowLine = @_yellowLine, _redLine = @_redLine, _maxStock = @_maxStock, isAvailable = @isAvailable, _isAvailableForSale = @_isAvailableForSale";

    private const string productWarehouseColumns = "_id, warehouseId, organizationId, productId, booked, inTrash, inTransit, amount";
    private const string productWarehouseValues = "@_id, @warehouseId, @organizationId, @productId, @booked, @inTrash, @inTransit, @amount";
    private const string productWarehouseUpdate = "warehouseId = @warehouseId, organizationId = @organizationId, productId = @productId, booked = @booked, inTrash = @inTrash, inTransit = @inTransit, amount = @amount";

    private const string productPriceColumns = "_id, priceId, organizationId, productId, priceAmount, minPrice, maxPrice, minSaleAmount";
    private const string productPriceValues = "@_id, @priceId, @organizationId, @productId, @priceAmount, @minPrice, @maxPrice, @minSaleAmount";
    private const string productPriceUpdate = "priceId = @priceId, organizationId = @organizationId, productId = @productId, priceAmount = @priceAmount, minPrice = @minPrice, maxPrice = @maxPrice, minSaleAmount = @minSaleAmount";

    private readonly DBExcutor dbe = new();

    public ProductRepository()
    {
    }

    public async void Insert(
       IEnumerable<ProductTable> products,
       IEnumerable<ProductOrganization> organization,
       IEnumerable<ProductWarehouse> warehouses,
       IEnumerable<ProductPrice> prices
        )
    {
        using (var scope = new TransactionScope())
        {
            await Insert(products);
            await InsertOrganizations(organization);
            await InsertWarehouses(warehouses);
            await InsertPrices(prices);
            scope.Complete();
        }
    }

    public async void UpdateWarehouseAmount(
        bool inc,
        List<Tuple<String, double>> productAmounts,
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
        return await dbe.ExecuteAsync(
            "INSERT INTO product(" + productColumns + ") VALUES(" + productValues + ") " +
            "ON CONFLICT (id) " +
            "DO UPDATE SET " + productUpdate, entity);
    }

    public async Task<int> Insert(IEnumerable<ProductTable> entities)
    {
        SqlMapper.AddTypeHandler(typeof(StringList), new StringListConverter());
        SqlMapper.AddTypeHandler(typeof(ProductTable.Barcode), new BarcodeConverters());
        SqlMapper.AddTypeHandler(typeof(ProductTable.Supplier), new SupplierConverter());
        return await dbe.ExecuteAsync(
            "INSERT INTO product(" + productColumns + ") VALUES(" + productValues + ") " +
            "ON CONFLICT (id) " +
            "DO UPDATE SET " + productUpdate, entities);
    }

    public async Task<int> InsertOrganizations(IEnumerable<ProductOrganization> entities)
    {
        return await dbe.ExecuteAsync(
            "INSERT INTO product_organization(" + productOrganizationColumns + ") VALUES(" + productOrganizationValues + ") " +
            "ON CONFLICT (id) " +
            "DO UPDATE SET " + productOrganizationUpdate, entities);
    }

    public async Task<int> InsertWarehouses(IEnumerable<ProductWarehouse> entities)
    {
        return await dbe.ExecuteAsync(
            "INSERT INTO product_warehouse(" + productWarehouseColumns + ") VALUES(" + productWarehouseValues + ") " +
            "ON CONFLICT (id) " +
            "DO UPDATE SET " + productWarehouseUpdate, entities);
    }

    public async Task<int> InsertPrices(IEnumerable<ProductPrice> entities)
    {
        return await dbe.ExecuteAsync(
            "INSERT INTO product_price(" + productPriceColumns + ") VALUES(" + productPriceValues + ") " +
            "ON CONFLICT (id) " +
            "DO UPDATE SET " + productPriceUpdate, entities);
    }

    public async Task<int> UpdateAvailability(
        string productId,
        string organizationId,
        bool isAvailable
    )
    {
        return await dbe.ExecuteAsync(
             "UPDATE product_organization SET isAvailable = @isAvailable WHERE productId = @productId AND organizationId = @organizationId",
             new { isAvailable, productId, organizationId }
           );
    }

    private Task<int> UpdateWarehouseAmount(
        double amount,
        string productId,
        string warehouseId
    )
    {
        return dbe.ExecuteAsync(
             "UPDATE product_warehouse SET amount = amount + @amount WHERE productId = @productId AND warehouseId = @warehouseId",
             new { amount, productId, warehouseId }
           );
    }

    public async Task<int> Delete(List<string> productIds)
    {
        return await dbe.ExecuteAsync(
            "DELETE FROM product WHERE id IN @productIds",
            new { productIds }
          );
    }

    public async Task<int> DeleteWarehouses(List<string> warehouseIds)
    {
        return await dbe.ExecuteAsync(
            "DELETE FROM product_warehouse WHERE _id IN @warehouseIds",
            new { warehouseIds }
          );
    }

    public async Task<int> DeletePrices(List<string> priceIds)
    {
        return await dbe.ExecuteAsync(
            "DELETE FROM product_price WHERE _id IN @priceIds",
            new { priceIds }
          );
    }

    //returns tax ids attached to the given product
    public async Task<StringList> GetTaxes(string productId)
    {
        Contract.Requires(productId != null);
        return await dbe.QuerySingleOrDefaultAsync<StringList>(
            "SELECT taxIds FROM product WHERE id = @productId",
            new { productId }
            );
    }

    //check if a product exists with the given barcode
    public async Task<bool> isExistByBarcode(string barcode)
    {
        Contract.Requires(barcode != null);
        return await dbe.QuerySingleOrDefaultAsync<bool>(
            "SELECT EXISTS(SELECT id FROM product WHERE barcode = @barcode)",
            new { barcode }
            );
    }

    public async Task<Product> GetById(
        string productId,
        string? organizationId,
        string? warehouseId,
        string? priceId,
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
       string? organizationId,
       string? warehouseId,
       string? priceId,
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
       string? organizationId,
       string? warehouseId,
       string? priceId,
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
        string? organizationId,
        string? warehouseId,
        string? priceId,
        bool withAmount,
        bool withPrices,
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
        string? organizationId,
        string? warehouseId,
        string? priceId,
        bool withAmount,
        bool withPrices,
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
        int offset,
        int limit,
        string? organizationId,
        string? warehouseId,
        bool? isProduct, // pass null to exclude this param from the filter
        bool? isMaterial, // pass null to exclude this param from the filter
        bool? isSemiProduct, // pass null to exclude this param from the filter
        bool? isAvailableForSale, // pass null to exclude this param from the filter
        string? searchQuery,
        string? priceId,
        string? inStockState, // null, 'yellow_line', 'red_line' or 'negative'
        string? categoryId,
        bool withOrganizationAmount,
        bool filterByWarehouse, // true, return products that exist only in the specified warehouse
        bool filterByPrice,     // true, return products that have the specified price
        bool excludeOutOfStockProducts // true, exclude products that are oud of stock
        )
    {
        var args = new Dictionary<string, object>();

        var query = getProductQuery(
            args,
            offset,
            limit,
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
            excludeOutOfStockProducts
            );

        query.Append(
           "ORDER BY p.name"
       ).Append(
            "LIMIT @limit "
        ).Append(
            "OFFSET @offset"
        );

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await dbe.QueryAsync<Product>(query.ToString(), args);
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

        var query = new StringBuilder("SELECT IFNULL(price.priceAmount, 0) as selectedPriceAmount ");
        var args = new Dictionary<string, object>();

        query.Append("FROM product as p ");

        query.Append("LEFT JOIN product_price price ON price.priceId = @priceId AND price.organizationId = @organizationId AND price.productId = p.id ");
        args.Add("@priceId", priceId);
        args.Add("@organizationId", organizationId);

        query.Append("WHERE p.id IN @products");
        args.Add("@products", products);

        return await dbe.QueryAsync<double>(query.ToString(), args);
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

        return await dbe.QuerySingleOrDefaultAsync<ProductPrice>(
            "SELECT * FROM product_price WHERE priceId = @priceId AND organizationId = @organizationId AND productId = @productId",
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
        args.Add("@organizationId", organizationId);
        args.Add("@productId", productId);

        return await dbe.QueryAsync<ProductTable.Price>(
            "SELECT priceId as priceId, priceAmount as selectedPriceAmount FROM product_price WHERE organizationId = @organizationId AND productId = @productId",
            args
           );
    }

    private async Task<Product> getProductBy(
        string byValue,
        int type,
        string? organizationId,
        string? warehouseId,
        string? priceId,
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
             "p.id = @byvalue " :
             type == 1 ?
             "p.sku = @byvalue " :

             "p.barcode = @byValue OR " +
                    "p.barcodes LIKE @byValue2 "
        );
        args.Add("@byValue", byValue);

        if (type == 2)
            args.Add("@byValue2", "%" + byValue + "%");

        var entity = await dbe.QuerySingleOrDefaultAsync<Product>(
            query.ToString(),
            args
            );

        if (withPrices && entity != null)
            entity.prices = (await GetPrices(args, organizationId!, entity.id)).ToList();

        return entity;
    }

    private async Task<List<Product>> getProductBy(
      object byValue,
      int type,
      string? organizationId,
      string? warehouseId,
      string? priceId,
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
            query.Append("(p.sku = @byValue OR p.barcode = @byValue OR p.barcodes LIKE @byValue2 ) ");
            args.Add("@byValue", byValue);
            args.Add("@byValue", byValue);
            args.Add("@byValue2"," % " + byValue + "%");
        }
        else if (type == 1)
        {
            var itemIds = (string[])byValue;
            if (isAll && itemIds.Length == 0)
                query.Append("p.categoryId IS NOT NULL");
            else
            {
                if (isAll)
                    query.Append("p.categoryId NOT IN @itemIds");
                else
                    query.Append("p.categoryId IN @itemIds");
                args.Add("@itemIds", itemIds);
            }
        }

        var entities = (await dbe.QueryAsync<Product>(
            query.ToString(),
            args
            )).ToList();

        if (withPrices && entities != null)
            entities.ForEach(async p =>
            {
                p.prices = (await GetPrices(args, organizationId!, p.id)).ToList();
            });


        return entities;
    }


    private StringBuilder getProductQuery(
        Dictionary<string, object> args,
        int offset,
        int limit,
        string? organizationId,
        string? warehouseId,
        bool? isProduct, // pass null to exclude this param from the filter
        bool? isMaterial, // pass null to exclude this param from the filter
        bool? isSemiProduct, // pass null to exclude this param from the filter
        bool? isAvailableForSale, // pass null to exclude this param from the filter
        string? searchQuery,
        string? priceId,
        string? inStockState, // null, 'yellow_line', 'red_line' or 'negative'
        string? categoryId,
        bool withOrganizationAmount,
        bool filterByWarehouse, // true, return products that exist only in the specified warehouse
        bool filterByPrice,     // true, return products that have the specified price
        bool excludeOutOfStockProducts // true, exclude products that are oud of stock
        )
    {

        bool filtered = false;

        StringBuilder query = new StringBuilder("SELECT p.*, org.amount as organizationAmount ");

        if (withOrganizationAmount)
            query.Append(", org._yellowLine as yellowLine, ")
               .Append("org._redLine as redLine, ")
               .Append("org._maxStock as maxStock, ")
               .Append("org._isAvailableForSale as isAvailableForSale");

        if (warehouseId == null)
            query.Append(", IFNULL(org.amount, 0) as warehouseAmount ");
        else
            query.Append(", IFNULL(warehouse.amount, 0) as warehouseAmount ");

        if (priceId != null)
            query.Append(", IFNULL(price.priceAmount, 0) as selectedPriceAmount ");

        query.Append("FROM product as p ");

        query.Append("JOIN product_organization org ON org.isAvailable = 1 AND org.organizationId = @organizationId AND org.productId = p.id ");
        args.Add("@organizationId", organizationId);

        if (warehouseId != null)
        {
            query.Append(filterByWarehouse == true ? "JOIN " : "LEFT JOIN ");

            query.Append("product_warehouse warehouse ON warehouse.warehouseId = @warehouseId AND warehouse.productId = p.id ");
            args.Add("@warehouseId", warehouseId);
        }

        if (priceId != null)
        {
            query.Append(filterByPrice == true ? "JOIN " : "LEFT JOIN ");

            query.Append("product_price price ON price.priceId = @priceId AND price.organizationId = @organizationId AND price.productId = p.id ");
            args.Add("@priceId", priceId);
        }

        query.Append("WHERE ");

        if (isProduct != null)
        {
            filtered = true;
            query.Append("p.isProduct = @isProduct AND ");
            args.Add("@isProduct", isProduct);
        }
        if (isMaterial != null)
        {
            filtered = true;
            query.Append("p.isMaterial = @isMaterial AND ");
            args.Add("@isMaterial", isMaterial);
        }
        if (isSemiProduct != null)
        {
            filtered = true;
            query.Append("p.isSemiProduct = @isSemiProduct AND ");
            args.Add("@isSemiProduct", isSemiProduct);
        }
        if (isAvailableForSale != null)
        {
            filtered = true;
            query.Append("org._isAvailableForSale = @isAvailableForSale AND ");
            args.Add("@isAvailableForSale", isAvailableForSale);
        }


        if (categoryId != null)
        {
            filtered = true;
            query.Append("p.categoryId = @categoryId AND ");
            args.Add("@categoryId", categoryId);
        }

        if (inStockState != null)
        {
            filtered = true;
            if (inStockState == "yellow_line")
                query.Append(
                    "org.amount>org._redLine AND " +
                            "org.amount<=org._yellowLine AND "
                );
            else if (inStockState == "red_line")
                query.Append(
                    "org.amount<=org._redLine AND " +
                            "org.amount>=0 AND "
                );
            else
                query.Append(
                    "org.amount<=0 AND "
                );
        }

        if (excludeOutOfStockProducts)
            query.Append("warehouseAmount > 0 AND ");

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var transliterator = new Transliterator(searchQuery);
            var native = "%" + transliterator.Native() + "%";
            var transliterated = "%" + transliterator.Transliterated() + "%";

            query.Append(
                "(p.name LIKE @native OR " +
                        "p.name LIKE @transliterated OR " +
                        "p.barcode LIKE @native OR " +
                        "p.sku LIKE @native OR " +
                        "p.barcodes LIKE @native) "
            );
            args.Add("@native", native);
            args.Add("@transliterated", transliterated);
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
        string? organizationId,
        string? warehouseId,
        string? priceId,
        bool withAmount
        )
    {
        if (withAmount)
        {
            if (warehouseId == null)
            {
                query.Append(", org.amount as warehouseAmount ");
            }
            query.Append(", org.amount as organizationAmount, ")
                .Append("org._yellowLine as yellowLine, ")
                .Append("org._redLine as redLine, ")
                .Append("org._maxStock as maxStock, ")
                .Append("org._isAvailableForSale as isAvailableForSale ");
        }

        if (warehouseId != null)
        {
            query.Append(", warehouse.amount as warehouseAmount, ")
                .Append("warehouse.booked as booked, ")
                .Append("warehouse.inTrash as inTrash, ")
                .Append("warehouse.inTransit as inTransit ");
        }

        if (priceId != null)
            query.Append(", IFNULL(price.priceAmount, 0) as selectedPriceAmount ");

        query.Append("FROM ${EntityNames.PRODUCT} AS p ");

        var filterByOrganization = false;

        if (withAmount)
        {
            query.Append("JOIN ${EntityNames.PRODUCT_ORGANIZATION} AS org ON org.isAvailable = 1 AND org.organizationId = @organizationId AND org.productId = p.id ");
            args.Add("@organizationId", organizationId);
            filterByOrganization = true;
        }

        if (warehouseId != null)
        {
            query.Append("LEFT JOIN ${EntityNames.PRODUCT_WAREHOUSE} AS warehouse ON warehouse.warehouseId = @warehouseId AND warehouse.productId = p.id ");
            args.Add("@warehouseId", warehouseId);
        }

        if (priceId != null)
        {
            query.Append("LEFT JOIN ${EntityNames.PRODUCT_PRICE} AS price ON price.priceId = @priceId AND price.organizationId = @organizationId AND price.productId = p.id ");
            args.Add("@priceId", priceId);
            args.Add("@organizationId", organizationId);
        }

        if (!filterByOrganization)
        {
            query.Append("JOIN ${EntityNames.PRODUCT_ORGANIZATION} AS org ON org.isAvailable = 1 AND org.organizationId = @organizationId AND org.productId = p.id ");
            args.Add("@organizationId", organizationId);
        }

        query.Append("WHERE ");
    }


}
