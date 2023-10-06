using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Hr;

internal class RequestEmployeeCU
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("birth_date")]
    public string? BirthDate { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("acceptance_date")]
    public string AcceptanceDate { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("pincode")]
    public string? Pincode { get; set; }

    [JsonPropertyName("role_id")]
    public string RoleId { get; set; }

    [JsonPropertyName("positions")]
    public List<Position> Positions { get; set; }

    public class Position
    {
        [JsonPropertyName("section_id")]
        public string SectionId { get; set; }

        [JsonPropertyName("position_id")]
        public string PositionId { get; set; }
    }
}
