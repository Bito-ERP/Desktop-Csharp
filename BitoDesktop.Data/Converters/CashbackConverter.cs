using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;

namespace BitoDesktop.Data.Converters
{
    public class CashbackConverter : JsonConverter<IEnumerable<CashbackSetting.Cashback>>
    {
    }
}
