﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;

public class PagingResponse<T>
{
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("data")]
    public List<T> PageData { get; set; }
}

