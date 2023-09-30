﻿using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;
internal class CurrencyApi
{
    public static async Task<BaseResponse<PagingResponse<CurrencyResponse>>> GetAll() =>
       await Client.Post<PagingResponse<CurrencyResponse>>("employee/finance/currency/get-all");

    public static async Task<BaseResponse<CurrencyResponse>> Update(RequestCurrencyCU request) =>
      await Client.Post<CurrencyResponse>("employee/finance/currency/update", request);

}