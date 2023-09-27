﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Auth;

internal class RequestResetPassword
{
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("confirm_password")]
    public string ConfirmPassword { get; set; }

    [JsonProperty("otp")]
    public string Otp { get; set; }

    [JsonProperty("brand")]
    public string Brand { get; set; }

    [JsonProperty("device")]
    public string Device { get; set; }

    [JsonProperty("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("product")]
    public string Product { get; set; }
}

