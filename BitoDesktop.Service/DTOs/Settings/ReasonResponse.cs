﻿using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class ReasonResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_trash")]
        public bool? IsTrash { get; set; }

        [JsonProperty("order_number")]
        public long? OrderNumber { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public Reason Get()
        {
            return new Reason
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Type = Type,
                IsActive = IsActive,
                IsTrash = IsTrash,
                OrderNumber = OrderNumber,
                Code = Code
            };
        }
    }
}
