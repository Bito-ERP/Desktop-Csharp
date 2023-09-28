using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class Client
{

    const string BASE_URL = "https://api.systematicdev.uz/pos-api/";

    public static async Task<BaseResponse<T>> Post<T>(string route, object? request = null)
    {
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwaG9uZV9udW1iZXIiOiIrOTk4OTQyNzAwNTUwIiwiYXBwX3R5cGUiOiJtb2JpbGUiLCJ1c2VybmFtZSI6ImRldiIsImlhdCI6MTY5NTczMjEyOSwiZXhwIjoxNjk2MzM2OTI5fQ.ZMFfssLW6S0ggUr5cZ6FOEWsq9pDPOP2v-ZHwlyzCYs");
        httpClient.DefaultRequestHeaders.Add("username", "dev");
        httpClient.DefaultRequestHeaders.Add("pos_id", "64a26a4369ad0c5dbfb1b0d4");
        httpClient.DefaultRequestHeaders.Add("user_id", "63d23484f1cf6851fcaf8140");
        httpClient.DefaultRequestHeaders.Add("organization_id", "63d23495f1cf6851fcaf832b");
        httpClient.DefaultRequestHeaders.Add("time", "2023-09-26T12:42:39.287Z");

        var responce = await httpClient.PostAsync(
            BASE_URL + route,
            request == null ? null : JsonContent.Create(request, options: new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            })
       );

        if (!responce.IsSuccessStatusCode)
            throw new MarketException((int)responce.StatusCode, await responce.Content.ReadAsStringAsync());

        return JsonConvert.DeserializeObject<BaseResponse<T>>(await responce.Content.ReadAsStringAsync());
    }

    public static async Task Post(string route, object? request = null)
    {
        using HttpClient httpClient = new();
        var responce = await httpClient.PostAsync(
            BASE_URL + route,
            request == null ? null : JsonContent.Create(request, options: new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            })
       );

        if (!responce.IsSuccessStatusCode)
            throw new MarketException((int)responce.StatusCode, await responce.Content.ReadAsStringAsync());
    }

}
