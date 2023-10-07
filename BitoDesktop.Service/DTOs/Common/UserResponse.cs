using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Common;
public class UserResponse
{
    [Required]
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("middle_name")]
    public string MiddleName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }
}
