﻿using BitoDesktop.Data.Converters;
using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Domain.Entities.Settings;
using Dapper;
using System.Collections.Generic;

namespace BitoDesktop.Data.Utils;

public class DataLoader
{
    public static void Init()
    {
        SqlMapper.AddTypeHandler(typeof(List<string>), new StringListConverter());
        SqlMapper.AddTypeHandler(typeof(List<ProductTable.BarcodeItem>), new BarcodeConverters());
        SqlMapper.AddTypeHandler(typeof(List<ProductTable.Supplier>), new SupplierConverter());
        SqlMapper.AddTypeHandler(typeof(List<Currency.Value>), new CurrencyValueConverter());
        SqlMapper.AddTypeHandler(typeof(List<Receipt.Amount>), new ReceiptAmountConverters());
        SqlMapper.AddTypeHandler(typeof(List<ReceiptItem.Tax>), new ReceiptItemTaxConverters());
        SqlMapper.AddTypeHandler(typeof(List<ReceiptDiscount>), new ReceiptItemDiscountConverters());
        SqlMapper.AddTypeHandler(typeof(IEnumerable<CustomerAmount>), new CustomerAmountConverter());
        SqlMapper.AddTypeHandler(typeof(IEnumerable<CashbackSetting.Cashback>), new CashbackConverter());
    }
}

