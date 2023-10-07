using BitoDesktop.Domain.Entities.Settings;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class PrinterResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("paper_width")]
        public int PaperWidth { get; set; }

        [JsonProperty("print_receipts")]
        public bool PrintReceipts { get; set; }

        [JsonProperty("automatically_print_receipts")]
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
