using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class ScaleRepostiory
{
    private const string ScaleColumns = "Id, OrganizationId, Type, SkuCount, SumCheckIndex, PriceCount, WeightCount, DepartmentCode, CountAfterDot";
    private const string ScaleValues = "@Id, @OrganizationId, @Type, @SkuCount, @SumCheckIndex, @PriceCount, @WeightCount, @DepartmentCode, @CountAfterDot";
    private const string ScaleUpdate = "OrganizationId = @OrganizationId, Type = @Type, SkuCount = @SkuCount, SumCheckIndex = @SumCheckIndex, PriceCount = @PriceCount, WeightCount = @WeightCount, DepartmentCode = @DepartmentCode, CountAfterDot = @CountAfterDot";

    public async Task<int> Insert(Scale item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO scale(" + ScaleColumns + ") VALUES(" + ScaleValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + ScaleUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<Scale> items)
    {
        return await DBExcutor.ExecuteAsync(
               "INSERT INTO scale(" + ScaleColumns + ") VALUES(" + ScaleValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + ScaleUpdate, items);
    }


    public async Task<Scale> GetById(string organizationId)
    {
        return await DBExcutor.QueryFirstOrDefaultAsync<Scale>(
           "SELECT * FROM scale WHERE OrganizationId = @organizationId",
           new { organizationId }
           );
    }
}
