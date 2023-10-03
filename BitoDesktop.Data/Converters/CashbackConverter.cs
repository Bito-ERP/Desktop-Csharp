using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;

namespace BitoDesktop.Data.Converters
{
    internal class CashbackConverter : JsonConverter<IEnumerable<CashbackSetting.Cashback>>
    {
    }
}
