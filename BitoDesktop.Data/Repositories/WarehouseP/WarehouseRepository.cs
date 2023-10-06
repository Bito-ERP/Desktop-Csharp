using BitoDesktop.Domain.Entities.WarehouseP;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.WarehouseP;
// Ombor
public class WarehouseRepository
{

    private const string WarehouseColumns = "Id, Name, OrganizationId, ResponsibleEmployeeId, IsMain, Status, Code";
    private const string WarehouseValues = "@Id, @Name, @OrganizationId, @ResponsibleEmployeeId, @IsMain, @Status, @Code";
    private const string WarehouseUpdate = "Name = @Name, OrganizationId = @OrganizationId, ResponsibleEmployeeId = @ResponsibleEmployeeId, IsMain = @IsMain, Status = @Status, Code = @Code";

    public async Task<int> Insert(IEnumerable<Warehouse> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO warehouse(" + WarehouseColumns + ") VALUES(" + WarehouseValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + WarehouseUpdate, items, connection);
    }

    public async Task<int> Insert(Warehouse item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO warehouse(" + WarehouseColumns + ") VALUES(" + WarehouseValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + WarehouseUpdate, item);
    }


    public async Task<Warehouse> GetById(string warehouseId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Warehouse>(
           "SELECT * FROM warehouse WHERE Id = @warehouseId",
           new { warehouseId }
           );
    }


    // get main warehouse of organization
    public async Task<Warehouse> GetMain(string organizationId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Warehouse>(
           "SELECT * FROM warehouse WHERE IsMain = TRUE AND Status = 'active' AND OrganizationId = @organizationId",
           new { organizationId }
           );
    }

    // check if there is any warehouse related to the organization
    public async Task<bool> IsNotEmpty(string organizationId)
    {
        var filtered = false;
        var query = new StringBuilder("SELECT EXISTS(SELECT Id FROM warehouse WHERE ");
        var args = new Dictionary<string, object>();

        if (organizationId != null)
        {
            filtered = true;
            query.Append("OrganizationId = @organizationId AND ");
            args.Add("organizationId", organizationId);
        }

        if (filtered)
            query.Remove(
                query.Length - 4,
                4
            );
        else
            query.Remove(
                query.Length - 6,
                6
            );
        query.Append(')');

        return await DBExcutor.QuerySingleOrDefaultAsync<bool>(query.ToString(), args);
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses(
       [Required] int offset,
       [Required] int limit,
       string searchQuery,
       string organisationId,  // filter by organization
       string status           // active/inactive or null
       )
    {

        var query = new StringBuilder("SELECT * FROM warehouse WHERE ");
        var args = new Dictionary<string, object>();

        query.Append("OrganizationId = @organisationId AND ");
        args.Add("organisationId", organisationId);

        if (status != null)
        {
            query.Append("Status = @status AND ");
            args.Add("status", status);
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var search = $"%{searchQuery}%";
            query.Append("(Name LIKE @search OR Code LIKE @search)");
            args.Add("search", search);
        }
        else
            query.Remove(
                query.Length - 4,
                4
            );

        query.Append("ORDER BY Name ")
        .Append(
           "LIMIT @limit "
       ).Append(
           "OFFSET @offset "
             );

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await DBExcutor.QueryAsync<Warehouse>(
            query.ToString(),
            args
            );
    }

    public async Task<int> Delete(string warehouseId)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM warehouse WHERE Id = @warehouseId", new { warehouseId });
    }

    public async Task<int> Delete(IEnumerable<string> warehouseIds)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM warehouse WHERE Id IN @warehouseIds", new { warehouseIds });
    }
}
