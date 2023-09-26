using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Data.Converters;

namespace BitoDesktop.Data.Converters
{

    public class BarcodeConverters : JsonConverter<ProductTable.Barcode>
    {
    };

    public class SupplierConverter : JsonConverter<ProductTable.Supplier>
    {
    };

}
