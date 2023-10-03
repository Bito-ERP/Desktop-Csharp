using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class CashbackSettingRepostiory
{
    private const string CashbackSettingColumns = "OrganizationId, Type, IsActive, Cashbacks";
    private const string CashbackSettingValues = "@OrganizationId, @Type, @IsActive, @Cashbacks";
    private const string CashbackSettingUpdate = "Type = @Type, IsActive = @IsActive, Cashbacks = @Cashbacks";

    public async Task<int> Insert(CashbackSetting item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO cashback_setting(" + CashbackSettingColumns + ") VALUES(" + CashbackSettingValues + ") " +
          "ON CONFLICT (OrganizationId) " +
          "DO UPDATE SET " + CashbackSettingUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<CashbackSetting> items)
    {
        return await DBExcutor.ExecuteAsync(
               "INSERT INTO cashback_setting(" + CashbackSettingColumns + ") VALUES(" + CashbackSettingValues + ") " +
               "ON CONFLICT (OrganizationId) " +
               "DO UPDATE SET " + CashbackSettingUpdate, items);
    }


    public async Task<CashbackSetting> Get(string organizationId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<CashbackSetting>(
           "SELECT * FROM cashback_setting WHERE OrganizationId = @organizationId",
           new { organizationId }
           );
    }
}
