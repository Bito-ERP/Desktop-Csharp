using BitoDesktop.Domain.Entities.CustomerP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Converters;
internal class CustomerAmountConverter: JsonConverter<IEnumerable<CustomerAmount>>
{
}

