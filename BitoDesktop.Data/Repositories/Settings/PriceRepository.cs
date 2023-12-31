﻿using BitoDesktop.Domain.Entities.Settings;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Settings;
public class PriceRepository
{

    private const string PriceColumns = "Id, Code, Name, ShortName, Status, CurrencyId, Type, MinPrice, MaxPrice, ApplyType, MinSaleAmount, IsMain, CanBeUpdated, Employees";
    private const string PriceValues = "@Id, @Code, @Name, @ShortName, @Status, @CurrencyId, @Type, @MinPrice, @MaxPrice, @ApplyType, @MinSaleAmount, @IsMain, @CanBeUpdated, @Employees";
    private const string PriceUpdate = "Id = @Id, Code = @Code, Name = @Name, ShortName = @ShortName, Status = @Status, CurrencyId = @CurrencyId, Type = @Type, MinPrice = @MinPrice, MaxPrice = @MaxPrice, ApplyType = @ApplyType, MinSaleAmount = @MinSaleAmount, IsMain = @IsMain, CanBeUpdated = @CanBeUpdated, Employees = @Employees";
    public async Task<int> Insert(IEnumerable<Price> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO price(" + PriceColumns + ") VALUES(" + PriceValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + PriceUpdate, items, connection);
    }

    public async Task<int> Insert(Price item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO price(" + PriceColumns + ") VALUES(" + PriceValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + PriceUpdate, item);
    }

    public async Task<int> ReplaceAll(IEnumerable<Price> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM price");
            return await Insert(items, connection);
        });
    }


    public async Task<Price> GetById(string priceId)
    {
        return await DBExcutor.QueryFirstOrDefaultAsync<Price>(
           "SELECT * FROM price WHERE Id = @priceId",
           new { priceId }
           );
    }

    // return main price, may be null
    // type is one of 'sale', 'income'
    // provide null to employeeId if he/she is a boss
    public async Task<Price> GetMain(string type, string employeeId)
    {
        return await DBExcutor.QueryFirstOrDefaultAsync<Price>(
           "SELECT * FROM price WHERE IsMain = TRUE AND Type = @type AND Status = 'active' AND (Employees IS NULL OR Employees LIKE @employeeId)",
           new { type, employeeId = $"%{employeeId ?? ""}%" }
           );
    }

    // provide null to employeeId if he/she is a boss
    public async Task<IEnumerable<Price>> GetPrices(string employeeId)
    {
        return await DBExcutor.QueryAsync<Price>("SELECT * FROM price WHERE Employees IS NULL OR Employees LIKE @employeeId", new { employeeId = $"%{employeeId ?? ""}%" });
    }


    public async Task<IEnumerable<Price>> GetPrices(
        [Required] int offset,
        [Required] int limit,
        string searchQuery,
        string type,         // 'sale', 'income'
        string currencyId,   // filter by currency 
        string status,       // active or inactive, null to get all
        string employeeId    // provide null to employeeId if he/she is a boss
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * FROM price WHERE ");
        var args = new Dictionary<string, object>();

        if (type != null)
        {
            filtered = true;
            query.Append("Type = @type AND ");
            args["@type"] = type;
        }

        if (currencyId != null)
        {
            filtered = true;
            query.Append("CurrencyId = @currencyId AND ");
            args["@currencyId"] = currencyId;
        }

        if (status != null)
        {
            filtered = true;
            query.Append("Status = @status AND ");
            args["@status"] = status;
        }

        filtered = true;
        query.Append("(Employees IS NULL OR Employees LIKE @employeeId) AND ");
        args["@employeeId"] = $"%{employeeId ?? ""}%";

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var search = $"%{searchQuery}%";
            query.Append("(Name LIKE @search OR ShortName LIKE @search)");
            args["@search"] = search;
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

        query.Append("ORDER BY Name")
         .Append(
            "LIMIT @limit "
        ).Append(
            "OFFSET @offset "
              );

        args["@limit"] = limit;
        args["@offset"] = offset;

        return await DBExcutor.QueryAsync<Price>(query.ToString(), args);
    }

    public async Task<int> Delete(string priceId)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM price WHERE Id = @priceId", new { priceId });
    }

    public async Task<int> Delete(IEnumerable<string> priceIds)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM price WHERE Id IN @priceId", new { priceIds });
    }
}

