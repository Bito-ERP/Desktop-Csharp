using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Sale;
using BitoDesktop.Service.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class SettingApi
{
     
    public static async Task<BaseResponse<GeneralSettingsResponse>> GetGeneralSettings() =>
        await Client.Post<GeneralSettingsResponse>("employee/settings/general-settings/get");

    public static async Task<BaseResponse<SaleSettingsResponse>> GetSaleSettings() =>
       await Client.Post<SaleSettingsResponse>("employee/settings/sale-settings/get");

    public static async Task<BaseResponse<CurrencySettingsResonse>> GetCurrencySettings() =>
    await Client.Post<CurrencySettingsResonse>("employee/settings/currency-settings/get");

    public static async Task<BaseResponse<List<ScaleResponse>>> GetScales() =>
      await Client.Post<List<ScaleResponse>>("employee/settings/scales/get-all");

    public static async Task<BaseResponse<ScaleResponse>> GetScale() =>
     await Client.Post<ScaleResponse>("employee/settings/scales/get");

    public static async Task<BaseResponse<ScaleResponse>> SetScale(RequestScaleSet request) =>
    await Client.Post<ScaleResponse>("employee/settings/scales/set", request);

    public static async Task<BaseResponse<List<CashbackSettingsResponse>>> GetCashbackSettings() =>
      await Client.Post<List<CashbackSettingsResponse>>("employee/cashback-setting/get-all");

}

