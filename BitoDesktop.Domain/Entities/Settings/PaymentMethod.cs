﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Settings;
public class PaymentMethod
{

    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public bool IsEnabled { get; set; }
}
