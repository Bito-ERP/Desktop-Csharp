using BitoDesktop.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Converters
{
    internal class CashbackConverter: JsonConverter<IEnumerable<CashbackSetting.Cashback>>
    {
    }
}
