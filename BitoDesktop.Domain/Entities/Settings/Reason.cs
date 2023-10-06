namespace BitoDesktop.Domain.Entities.Settings;
public class Reason
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; }
    public bool? IsTrash { get; set; }
    public long? OrderNumber { get; set; }
    public string Code { get; set; }
}

