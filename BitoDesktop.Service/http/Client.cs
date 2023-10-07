using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class Client
{

    const string BASE_URL = "https://api.systematicdev.uz/pos-api/";
    public static string Token { get; set; }
    public static async Task<BaseResponse<T>> Post<T>(string route, object request = null)
    {
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer " + Token);
        httpClient.DefaultRequestHeaders.Add("username", "dev");
        httpClient.DefaultRequestHeaders.Add("pos_id", "64a26a4369ad0c5dbfb1b0d4");
        httpClient.DefaultRequestHeaders.Add("user_id", "63d23484f1cf6851fcaf8140");
        httpClient.DefaultRequestHeaders.Add("organization_id", "63d23495f1cf6851fcaf832b");
        httpClient.DefaultRequestHeaders.Add("time", "2023-09-26T12:42:39.287Z");

        Debug.WriteLine(route);

        var jsonRequest = request == null ? null : new StringContent(JsonConvert.SerializeObject(request),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(request));

        var responce = await httpClient.PostAsync(
            BASE_URL + route,
            jsonRequest
       );

        var stringResponce = await responce.Content.ReadAsStringAsync();
        Debug.WriteLine(stringResponce);

        if (!responce.IsSuccessStatusCode)
            throw new MarketException((int)responce.StatusCode, stringResponce);

        return JsonConvert.DeserializeObject<BaseResponse<T>>(stringResponce);
    }

    public static async Task Post(string route, object request = null)
    {
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        httpClient.DefaultRequestHeaders.Add("username", "dev");
        httpClient.DefaultRequestHeaders.Add("pos_id", "64a26a4369ad0c5dbfb1b0d4");
        httpClient.DefaultRequestHeaders.Add("user_id", "63d23484f1cf6851fcaf8140");
        httpClient.DefaultRequestHeaders.Add("organization_id", "63d23495f1cf6851fcaf832b");
        httpClient.DefaultRequestHeaders.Add("time", "2023-09-26T12:42:39.287Z");

        Debug.WriteLine(route);

        var jsonRequest = request == null ? null : new StringContent(JsonConvert.SerializeObject(request),
            System.Text.Encoding.UTF8,
            "application/json");
        Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(request));

        var responce = await httpClient.PostAsync(
            BASE_URL + route,
            jsonRequest
       );

        Debug.WriteLine(await responce.Content.ReadAsStringAsync());

        if (!responce.IsSuccessStatusCode)
            throw new MarketException((int)responce.StatusCode, await responce.Content.ReadAsStringAsync());
    }

}
