using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Finance;
using BitoDesktop.Service.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class UnitMeasurementApi
{
    public static async Task<BaseResponse<List<UnitMeasurementResponse>>> GetAll() =>
        await Client.Post<List<UnitMeasurementResponse>>("employee/settings/warehouse/units-of-measure/get-all");
}
