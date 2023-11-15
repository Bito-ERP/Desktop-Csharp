using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class Client
{
    const string BASE_URL = "https://api.systematicdev.uz/pos-api/";
    public static string Token { get; set; }
    public static string DeviceId { get; set; } = null;
    public static string OrganizationId { get; set; }
    public static string Username { get; set; }
    public static string UserId { get; set; }
    public static string PriceId { get; set; }
    public static string WarehouseId { get; set; }
    public static string ServerId { get { return Username; } set { Username = value; } }

    public static async Task<BaseResponse<T>> Post<T>(string route, object request = null)
    {
        string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer " + Token);
        httpClient.DefaultRequestHeaders.Add("username", Username);
        httpClient.DefaultRequestHeaders.Add("pos_id", DeviceId);
        httpClient.DefaultRequestHeaders.Add("user_id", UserId);
        httpClient.DefaultRequestHeaders.Add("organization_id", OrganizationId);
        httpClient.DefaultRequestHeaders.Add("time", time);

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
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer " + Token);
        httpClient.DefaultRequestHeaders.Add("username", Username);
        httpClient.DefaultRequestHeaders.Add("pos_id", DeviceId);
        httpClient.DefaultRequestHeaders.Add("user_id", "63d23484f1cf6851fcaf8140");
        httpClient.DefaultRequestHeaders.Add("organization_id", OrganizationId);
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

    public static bool CheckForInternetConnection()
    {
        try
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            return (reply.Status == IPStatus.Success);
        }
        catch (Exception)
        {
            throw new MarketException(400, "No internet available");
        }
    }
}
