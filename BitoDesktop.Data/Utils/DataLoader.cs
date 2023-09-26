using BitoDesktop.Data.Converters;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Utils
{
    public class DataLoader
    {
        public static void init()
        {
            SqlMapper.AddTypeHandler(new StringListConverter());
            SqlMapper.AddTypeHandler(new BarcodeConverters());
            SqlMapper.AddTypeHandler(new SupplierConverter());
        }
    }
}
