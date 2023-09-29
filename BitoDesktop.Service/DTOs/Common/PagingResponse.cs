using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;

internal class PagingResponse<T>
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("data")]
    public List<T> PageData { get; set; }
}

