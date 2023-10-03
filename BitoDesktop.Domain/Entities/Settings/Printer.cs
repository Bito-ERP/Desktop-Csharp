namespace BitoDesktop.Domain.Entities.Settings;

public class Printer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public int PaperWidth { get; set; }
    public bool PrintReceipts { get; set; }
    public bool AutomaticallyPrintReceipts { get; set; }
}
