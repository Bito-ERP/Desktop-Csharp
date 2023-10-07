using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;
public class LocationResponse
{
    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("long")]
    public double Long { get; set; }

    [JsonProperty("human_address")]
    public AddressResponse Address { get; set; }

    public class AddressResponse
    {
        [JsonProperty("address")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }
    }
}
