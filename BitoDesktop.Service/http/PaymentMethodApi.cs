using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class PaymentMethodApi
{
    public static async Task<BaseResponse<PagingResponse<PaymentMethodResponse>>> GetAll() =>
        await Client.Post<PagingResponse<PaymentMethodResponse>>("employee/settings/payment-method/get-all");
}
