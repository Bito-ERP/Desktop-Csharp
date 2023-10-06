using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class CurrencySettingsResonse
    {
        [JsonProperty("apply_in_main")]
        public bool ApplyInMain { get; set; }
    }
}
