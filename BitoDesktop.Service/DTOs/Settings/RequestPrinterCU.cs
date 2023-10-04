﻿using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class RequestPrinterCU
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
    }
}
