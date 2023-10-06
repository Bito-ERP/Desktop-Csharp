using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class UnitMeasurementApi
{
    public static async Task<BaseResponse<List<UnitMeasurementResponse>>> GetAll() =>
        await Client.Post<List<UnitMeasurementResponse>>("employee/settings/warehouse/units-of-measure/get-all");
}
