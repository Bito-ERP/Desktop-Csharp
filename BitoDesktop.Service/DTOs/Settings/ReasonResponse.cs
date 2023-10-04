﻿using BitoDesktop.Domain.Entities.Settings;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class ReasonResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("is_trash")]
        public bool? IsTrash { get; set; }

        [JsonPropertyName("order_number")]
        public long? OrderNumber { get; set; }

        [JsonPropertyName("code")]
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
