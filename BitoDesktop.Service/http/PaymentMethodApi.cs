﻿using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class PaymentMethodApi
{
    public static async Task<BaseResponse<PagingResponse<PaymentMethodResponse>>> GetAll() =>
        await Client.Post<PagingResponse<PaymentMethodResponse>>("employee/settings/payment-method/get-all");
}