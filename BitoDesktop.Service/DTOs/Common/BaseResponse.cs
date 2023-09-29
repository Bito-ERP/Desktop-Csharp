using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;

internal class BaseResponse<T>
{
    [JsonPropertyName("code")]
    public int Code { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("data")]
    public T Data { get; set; }
    [JsonPropertyName("time")]
    public string Time { get; set; }
}
