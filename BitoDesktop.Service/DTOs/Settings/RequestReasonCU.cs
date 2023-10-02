﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class RequestReasonCU
    {
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("is_trash")]
        public bool? IsTrash { get; set; }

        [JsonPropertyName("order_number")]
        public long? OrderNumber { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
