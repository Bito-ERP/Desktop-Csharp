using BitoDesktop.Domain.Entities.Sale;
using System.Collections.Generic;

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
