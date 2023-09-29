using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Converters;

public class CurrencyValueConverter : JsonConverter<List<Currency.Value>>
{
};
