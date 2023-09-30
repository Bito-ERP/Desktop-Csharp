using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Common;
internal class UserResponse
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
