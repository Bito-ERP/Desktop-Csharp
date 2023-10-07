using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

public class BaseResponse<T>
{
    [JsonProperty("code")]
    public int Code { get; set; }
    public bool IsSuccessStatusCode => Code >= 299;
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("time")]
    public string Time { get; set; }
}
