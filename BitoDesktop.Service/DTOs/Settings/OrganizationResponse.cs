﻿using BitoDesktop.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings;

internal class OrganizationResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("currency_id")]
    public string CurrencyId { get; set; }

    public Organization Get()
    {
        return new Organization
        {
            Id = Id,
            Name = Name,
            CurrencyId = CurrencyId
        };
    }
}
