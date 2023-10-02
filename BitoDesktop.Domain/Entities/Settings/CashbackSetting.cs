using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Settings
{
    public class CashbackSetting
    {
        public string OrganizationId { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Cashback> Cashbacks { get; set; }

        public class Cashback
        {
            public string Type { get; set; }
            public double MinAmount { get; set; }
            public double Amount { get; set; }
            public string CurrencyId { get; set; }
        }

    }
}
