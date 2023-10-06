using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;

namespace BitoDesktop.Data.Converters;

public class CurrencyValueConverter : JsonConverter<List<Currency.Value>>
{
};
