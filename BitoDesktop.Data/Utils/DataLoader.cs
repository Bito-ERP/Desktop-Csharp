using BitoDesktop.Data.Converters;
using BitoDesktop.Domain.Entities;
using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Products;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Utils;

public class DataLoader
{
    public static void Init()
    {
        SqlMapper.AddTypeHandler(typeof(List<String>),new StringListConverter());
        SqlMapper.AddTypeHandler(typeof(List<ProductTable.BarcodeItem>), new BarcodeConverters());
        SqlMapper.AddTypeHandler(typeof(List<ProductTable.Supplier>), new SupplierConverter());
        SqlMapper.AddTypeHandler(typeof(List<Currency.Value>), new CurrencyValueConverter());
    }
}

