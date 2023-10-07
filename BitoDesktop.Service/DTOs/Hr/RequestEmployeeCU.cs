using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Hr;

public class RequestEmployeeCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("person_id")]
    public string PersonId { get; set; }

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("birth_date")]
    public string BirthDate { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("acceptance_date")]
    public string AcceptanceDate { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("pincode")]
    public string Pincode { get; set; }

    [JsonProperty("role_id")]
    public string RoleId { get; set; }

    [JsonProperty("positions")]
    public List<Position> Positions { get; set; }

    public class Position
    {
        [JsonProperty("section_id")]
        public string SectionId { get; set; }

        [JsonProperty("position_id")]
        public string PositionId { get; set; }
    }
}
