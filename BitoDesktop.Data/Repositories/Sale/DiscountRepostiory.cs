using BitoDesktop.Domain.Entities.Sale;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class DiscountRepostiory
{
    private const string DiscountColumns = "Id, Name, ApplyType, Value, CurrencyId, Image";
    private const string DiscountValues = "@Id, @Name, @ApplyType, @Value, @CurrencyId, @Image";
    private const string DiscountUpdate = "Id = @Id, Name = @Name, ApplyType = @ApplyType, Value = @Value, CurrencyId = @CurrencyId, Image = @Image";

    public async Task<int> Insert(Discount discount)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO discount(" + DiscountColumns + ") VALUES(" + DiscountValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + DiscountUpdate, discount);
    }

    public async Task<int> Insert(IEnumerable<Discount> items)
    {
        return await DBExcutor.ExecuteAsync(
               "INSERT INTO discount(" + DiscountColumns + ") VALUES(" + DiscountValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + DiscountUpdate, items);
    }

    public async Task<int> ReplaceAll(IEnumerable<Discount> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM discount");
            return await DBExcutor.ExecuteAsync(
               "INSERT INTO discount(" + DiscountColumns + ") VALUES(" + DiscountValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + DiscountUpdate, items);
        });
    }


    public async Task<Discount> GetById(string discountId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Discount>(
           "SELECT * FROM discount WHERE Id = @discountId",
           new { discountId }
           );
    }

    public async Task<IEnumerable<Discount>> GetAll(string currencyId)
    {
        return await DBExcutor.QueryAsync<Discount>(
          "SELECT * FROM discount WHERE CurrencyId IS NULL OR CurrencyId = @currencyId",
          new { currencyId }
          );
    }

    public async Task<IEnumerable<Discount>> GetDiscounts(int offset, int limit, string searchQuery)
    {
        return await DBExcutor.QueryAsync<Discount>(
          "SELECT * FROM discount WHERE Name LIKE @searchQuery ORDER BY Name LIMIT @limit OFFSET @offset ",
          new { offset, limit, searchQuery = $"%{searchQuery}%" }
          );
    }

    public async Task<int> Delete(string discountId)
    {
        return await DBExcutor.ExecuteAsync(
        "DELETE FROM discount WHERE Id = @discountId",
        new { discountId }
        );
    }

    public async Task<int> Delete(List<string> discountIds)
    {
        return await DBExcutor.ExecuteAsync(
          "DELETE FROM discount WHERE Id IN @discountIds",
          new { discountIds }
          );
    }

}
