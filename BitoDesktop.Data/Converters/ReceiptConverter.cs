using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Domain.Entities.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Converters
{
    public class ReceiptAmountConverters : JsonConverter<List<Receipt.Amount>>
    {
    };

    public class ReceiptItemTaxConverters : JsonConverter<List<ReceiptItem.Tax>>
    {
    };

    public class ReceiptItemDiscountConverters : JsonConverter<List<ReceiptDiscount>>
    {
    };
}
