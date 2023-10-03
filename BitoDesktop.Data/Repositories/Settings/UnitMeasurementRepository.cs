using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Settings;

public class UnitMeasurementRepository
{
    private const string UnitMeasurementColumns = "Id, Code, ShortName, Name, DecimalCount, Status";
    private const string UnitMeasurementValues = "@Id, @Code, @ShortName, @Name, @DecimalCount, @Status";
    private const string UnitMeasurementUpdate = "Id = @Id, Code = @Code, ShortName = @ShortName, Name = @Name, DecimalCount = @DecimalCount, Status = @Status";
    public async Task<int> Insert(UnitMeasurement unitMeasurement)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO unit_measurement(" + UnitMeasurementColumns + ") VALUES(" + UnitMeasurementValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + UnitMeasurementUpdate, unitMeasurement);
    }

    public async Task<int> ReplaceAll(IEnumerable<UnitMeasurement> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM unit_measurement");
            return await DBExcutor.ExecuteAsync(
               "INSERT INTO unit_measurement(" + UnitMeasurementColumns + ") VALUES(" + UnitMeasurementValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + UnitMeasurementUpdate, items);
        });
    }


    public async Task<UnitMeasurement> GetById(string unitMeasurementId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<UnitMeasurement>(
           "SELECT * FROM unit_measurement WHERE Id = @unitMeasurementId",
           new { unitMeasurementId }
           );
    }

    public async Task<IEnumerable<UnitMeasurement>> GetAll()
    {
        return await DBExcutor.QueryAsync<UnitMeasurement>("SELECT * FROM unit_measurement");
    }
}
