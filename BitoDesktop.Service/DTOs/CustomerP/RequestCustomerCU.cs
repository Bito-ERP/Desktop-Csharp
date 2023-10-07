using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.CustomerP;
public class RequestCustomerCU
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("b2c_id")]
    public string B2CId { get; set; }

    [JsonProperty("person_id")]
    public string PersonId { get; set; }

    [JsonProperty("category_id")]
    public string CategoryId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("inn")]
    public string Inn { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("agent_id")]
    public string AgentId { get; set; }

    [JsonProperty("delivery_address")]
    public LocationRequest DeliveryAddress { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}

