using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings;
public class UnitMeasurementResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("decimal_count")]
    public int DecimalCount { get; set; }

    [JsonProperty("status")]
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
