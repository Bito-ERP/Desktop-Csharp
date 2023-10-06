using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Finance;

public class CurrencyRepository
{
    private const string CurrencyColumns = "Id, Name, Values, Side, IsMain, Symbol, UpdatedAt";
    private const string CurrencyValues = "@Id, @Name, @Values, @Side, @IsMain, @Symbol, @UpdatedAt";
    private const string CurrencyUpdate = "Id = @Id, Name = @Name, Values = @Values, Side = @Side, IsMain = @IsMain, Symbol = @Symbol, UpdatedAt = @UpdatedAt";

    public async Task<int> Insert(Currency currency)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO currency(" + CurrencyColumns + ") VALUES(" + CurrencyValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + CurrencyUpdate, currency);
    }

    public async Task<int> ReplaceAll(IEnumerable<Currency> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM currency");
            return await DBExcutor.ExecuteAsync(
               "INSERT INTO currency(" + CurrencyColumns + ") VALUES(" + CurrencyValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + CurrencyUpdate, items);
        });
    }


    public async Task<Currency> GetById(string currencyId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Currency>(
           "SELECT * FROM currency WHERE Id = @currencyId",
           new { currencyId }
           );
    }

    public async Task<IEnumerable<Currency>> GetAll(string searchQuery)
    {
        return await DBExcutor.QueryAsync<Currency>(
          "SELECT * FROM currency WHERE name LIKE @searchQuery",
          new { searchQuery = $"%{searchQuery}%" }
          );
    }

}
