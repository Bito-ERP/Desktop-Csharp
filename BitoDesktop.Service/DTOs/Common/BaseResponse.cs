using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

internal class BaseResponse<T>
{
    [JsonProperty("code")]
    public int Code { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("time")]
    public string Time { get; set; }
}
