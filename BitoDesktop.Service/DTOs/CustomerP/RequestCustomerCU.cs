using BitoDesktop.Service.DTOs.Common;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.CustomerP;
public class RequestCustomerCU
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("b2c_id")]
    public string B2CId { get; set; }

    [JsonPropertyName("person_id")]
    public string PersonId { get; set; }

    [JsonPropertyName("category_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string CategoryId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("inn"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Inn { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("agent_id")]
    public string AgentId { get; set; }

    [JsonPropertyName("delivery_address")]
    public LocationRequest DeliveryAddress { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

