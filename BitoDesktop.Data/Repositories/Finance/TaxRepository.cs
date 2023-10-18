using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Finance;

public class TaxRepository
{
    private const string TaxColumns = "Id, Name, Rate, Type, ToPrice, IsManual, IsAll, IsAllCategories, IsAllSuppliers, ItemCount, CategoryIds, SupplierIds, AddedItemIds, RemovedItemIds, OrganizationIds";
    private const string TaxValues = "@Id, @Name, @Rate, @Type, @ToPrice, @IsManual, @IsAll, @IsAllCategories, @IsAllSuppliers, @ItemCount, @CategoryIds, @SupplierIds, @AddedItemIds, @RemovedItemIds, @OrganizationIds";
    private const string TaxUpdate = "@Name = Name, @Rate = Rate, @Type = Type, @ToPrice = ToPrice, @IsManual = IsManual, @IsAll = IsAll, @IsAllCategories = IsAllCategories, @IsAllSuppliers = IsAllSuppliers, @ItemCount = ItemCount, @CategoryIds = CategoryIds, @SupplierIds = SupplierIds, @AddedItemIds = AddedItemIds, @RemovedItemIds = RemovedItemIds, @OrganizationIds = OrganizationIds";

    public async Task<int> Insert(Tax tax)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO finance_tax(" + TaxColumns + ") VALUES(" + TaxValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + TaxUpdate, tax);
    }

    public async Task<int> Insert(IEnumerable<Tax> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM finance_tax", connection);
            return await DBExcutor.ExecuteAsync(
               "INSERT INTO finance_tax(" + TaxColumns + ") VALUES(" + TaxValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + TaxUpdate, items, connection);
        });
    }


    public async Task<Tax> GetById(string taxId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Tax>(
           "SELECT * FROM finance_tax WHERE Id = @taxId",
           new { taxId }
           );
    }

    public async Task<IEnumerable<Tax>> GetAll(string searchQuery, [Required] string organizationId)
    {
        return await DBExcutor.QueryAsync<Tax>(
          "SELECT * FROM finance_tax WHERE Name LIKE @searchQuery AND OrganizationIds LIKE @organizationId",
          new { searchQuery = $"%{searchQuery ?? ""}%", organizationId = $"%{organizationId}%" }
          );
    }

    // Get Taxes by their ids, used to get taxes of a product
    public async Task<IEnumerable<Tax>> Get(IEnumerable<string> taxIds, [Required] string organizationId)
    {
        return await DBExcutor.QueryAsync<Tax>(
          "SELECT * FROM finance_tax WHERE (IsManual = TRUE OR Id IN @taxIds) AND OrganizationIds LIKE @organizationId",
          new { taxIds, organizationId = $"%{organizationId}%" }
          );
    }

    public async Task<int> Delete(string taxId)
    {
        return await DBExcutor.ExecuteAsync(
        "DELETE FROM finance_tax WHERE Id = @taxId",
        new { taxId }
        );
    }

    public async Task<int> Delete(List<string> taxIds)
    {
        return await DBExcutor.ExecuteAsync(
          "DELETE FROM finance_tax WHERE Id IN @taxIds",
          new { taxIds }
          );
    }

}
