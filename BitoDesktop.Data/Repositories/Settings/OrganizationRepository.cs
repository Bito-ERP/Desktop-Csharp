using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Domain.Entities.Settings;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Settings;

public class OrganizationRepository
{

    private const string OrganizationColumns = "Id, Name, CurrencyId";
    private const string OrganizationValues = "@Id, @Name, @CurrencyId";
    private const string OrganizationUpdate = "Name = @Name, CurrencyId  = @CurrencyId";

    public async Task<int> Insert(IEnumerable<Organization> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO organization(" + OrganizationColumns + ") VALUES(" + OrganizationValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + OrganizationUpdate, items, connection);
    }

    public async Task<int> Insert(Organization paymentMethod)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO organization(" + OrganizationColumns + ") VALUES(" + OrganizationValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + OrganizationUpdate, paymentMethod);
    }

    public async Task<int> ReplaceAll(IEnumerable<Organization> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM organization");
            return await Insert(items, connection); 
        });
    }


    public async Task<Organization> GetById(string organizationId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Organization>(
           "SELECT * FROM organization WHERE Id = @organizationId",
           new { organizationId }
           );
    }

    public async Task<IEnumerable<Organization>> GetAll()
    {
        return await DBExcutor.QueryAsync<Organization>("SELECT * FROM organization");
    }

    public async Task<int> Delete(string organizationId)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM organization WHERE Id = @organizationId", new { organizationId });
    }
}
