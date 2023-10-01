using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.WarehouseP;

internal class RequestCategoryCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("parent_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string ParentId { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }
}

