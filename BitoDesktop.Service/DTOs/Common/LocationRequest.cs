using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Common;
internal class LocationRequest
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("long")]
    public double Long { get; set; }

    [JsonPropertyName("human_address")]
    public AddressResponse Address { get; set; }

    public class AddressResponse
    {
        [JsonPropertyName("address")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}
