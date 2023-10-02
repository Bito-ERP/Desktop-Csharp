using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class PrinterResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("paper_width")]
        public int PaperWidth { get; set; }

        [JsonPropertyName("print_receipts")]
        public bool PrintReceipts { get; set; }

        [JsonPropertyName("automatically_print_receipts")]
        public bool AutomaticallyPrintReceipts { get; set; }

        public Printer Get()
        {
            return new Printer
            {
                Id = Id,
                Name = Name,
                Type = Type,
                Address = Address,
                PaperWidth = PaperWidth,
                PrintReceipts = PrintReceipts,
                AutomaticallyPrintReceipts = AutomaticallyPrintReceipts
            };
        }
    }
}
