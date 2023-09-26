using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class Client
{

    const string BASE_URL = "https://api.systematicdev.uz/pos-api/";

    public static async Task<BaseResponse<T>> Post<T>(string route, object request)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            var responce = await httpClient.PostAsync(
                BASE_URL + route,
                new StringContent(JsonConvert.SerializeObject(request))
           );

            if (!responce.IsSuccessStatusCode)
                throw new MarketException((int)responce.StatusCode, await responce.Content.ReadAsStringAsync());

            return await responce.Content.ReadFromJsonAsync<BaseResponse<T>>();
        }
    }

    public static async Task Post(string route, object request)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            var responce = await httpClient.PostAsync(
                BASE_URL + route,
                new StringContent(JsonConvert.SerializeObject(request))
           );

            if (!responce.IsSuccessStatusCode)
                throw new MarketException((int)responce.StatusCode, await responce.Content.ReadAsStringAsync());
        }
    }

}
