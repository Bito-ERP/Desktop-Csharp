using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Common;
public class UserResponse
{
    [Required]
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("middle_name")]
    public string MiddleName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
}
