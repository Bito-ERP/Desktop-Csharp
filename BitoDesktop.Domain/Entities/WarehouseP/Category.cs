using System.Collections.Generic;

namespace BitoDesktop.Domain.Entities.WarehouseP;
public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ParentId { get; set; }
    public string ParentName { get; set; }
    public string Image { get; set; }
    public int ItemCount { get; set; }
    public int ChildCount { get; set; }
    public List<string> OrganizationIds { get; set; }
}
