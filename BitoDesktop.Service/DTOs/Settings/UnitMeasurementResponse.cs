using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings;
internal class UnitMeasurementResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("decimal_count")]
    public int DecimalCount { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    public UnitMeasurement Get() =>
        new()
        {
            Id = Id,
            Code = Code,
            ShortName = ShortName,
            Name = Name,
            DecimalCount = DecimalCount,
            Status = Status
        };

}
