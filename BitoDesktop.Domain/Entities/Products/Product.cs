using BitoDesktop.Domain.Commons;

namespace BitoDesktop.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}