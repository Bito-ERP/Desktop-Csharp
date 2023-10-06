using BitoDesktop.Domain.Entities.Products;
using System.Collections.Generic;

namespace BitoDesktop.Data.Converters
{

    public class BarcodeConverters : JsonConverter<List<ProductTable.BarcodeItem>>
    {
    };

    public class SupplierConverter : JsonConverter<List<ProductTable.Supplier>>
    {
    };

}
