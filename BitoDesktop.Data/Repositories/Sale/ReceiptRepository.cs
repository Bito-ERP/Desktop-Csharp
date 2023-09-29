//using BitoDesktop.Domain.Entities.Sale;
//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BitoDesktop.Data.Repositories.Sale;

//public class ReceiptRepository
//{

//    private static readonly string ReceiptColumns = "Uuid, Id, OrganizationId, Counter, Synced, CalcAddedTaxAfterDiscount, CalcIncludedTaxAfterDiscount, CalcSaleDiscountAfterProducts, TotalToPay, TotalToRefund, TotalPrice, ProductsTotalDiscount, SaleTotalDiscount, TotalIncludedTax, TotalAddedTax, IsRefund, State, Number, RefundNumber, RefundUuid, CashboxId, CashboxName, DeviceId, DeviceName, CreatorId, CreatorName, CustomerId, CustomerName, CurrencyId, CurrencyName, CurrencySide, CurrencySymbol, BaseCurrencyValue, EarnedCashbackId, EarnedCashbackCurrencyId, EarnedCashbackCurrencyName, EarnedCashbackCurrencyValue, EarnedCashbackCurrencySide, EarnedCashbackCurrencySymbol, EarnedCashbackAmount, CustomerBeforeBalance, CustomerAfterBalance, CustomerBeforeCashback, CustomerAfterCashback, WarehouseId, WarehouseName, ContractId, ContractCode, ContractNumber, OrderId, OrderCode, OrderNumber, DeliveryLatitude, DeliveryLongitude, DeliveryLocationName, DeliveryDate, IsTrash, SendSms, SoldAt, Failed, ErrorCode, ErrorData";
//    private static readonly string ReceiptValues = "@Uuid, @Id, @OrganizationId, @Counter, @Synced, @CalcAddedTaxAfterDiscount, @CalcIncludedTaxAfterDiscount, @CalcSaleDiscountAfterProducts, @TotalToPay, @TotalToRefund, @TotalPrice, @ProductsTotalDiscount, @SaleTotalDiscount, @TotalIncludedTax, @TotalAddedTax, @IsRefund, @State, @Number, @RefundNumber, @RefundUuid, @CashboxId, @CashboxName, @DeviceId, @DeviceName, @CreatorId, @CreatorName, @CustomerId, @CustomerName, @CurrencyId, @CurrencyName, @CurrencySide, @CurrencySymbol, @BaseCurrencyValue, @EarnedCashbackId, @EarnedCashbackCurrencyId, @EarnedCashbackCurrencyName, @EarnedCashbackCurrencyValue, @EarnedCashbackCurrencySide, @EarnedCashbackCurrencySymbol, @EarnedCashbackAmount, @CustomerBeforeBalance, @CustomerAfterBalance, @CustomerBeforeCashback, @CustomerAfterCashback, @WarehouseId, @WarehouseName, @ContractId, @ContractCode, @ContractNumber, @OrderId, @OrderCode, @OrderNumber, @DeliveryLatitude, @DeliveryLongitude, @DeliveryLocationName, @DeliveryDate, @IsTrash, @SendSms, @SoldAt, @Failed, @ErrorCode, @ErrorData";
//    private static readonly string ReceiptUpdate = "Uuid = @Uuid, Id = @Id, OrganizationId = @OrganizationId, Counter = @Counter, Synced = @Synced, CalcAddedTaxAfterDiscount = @CalcAddedTaxAfterDiscount, CalcIncludedTaxAfterDiscount = @CalcIncludedTaxAfterDiscount, CalcSaleDiscountAfterProducts = @CalcSaleDiscountAfterProducts, TotalToPay = @TotalToPay, TotalToRefund = @TotalToRefund, TotalPrice = @TotalPrice, ProductsTotalDiscount = @ProductsTotalDiscount, SaleTotalDiscount = @SaleTotalDiscount, TotalIncludedTax = @TotalIncludedTax, TotalAddedTax = @TotalAddedTax, IsRefund = @IsRefund, State = @State, Number = @Number, RefundNumber = @RefundNumber, RefundUuid = @RefundUuid, CashboxId = @CashboxId, CashboxName = @CashboxName, DeviceId = @DeviceId, DeviceName = @DeviceName, CreatorId = @CreatorId, CreatorName = @CreatorName, CustomerId = @CustomerId, CustomerName = @CustomerName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol, BaseCurrencyValue = @BaseCurrencyValue, EarnedCashbackId = @EarnedCashbackId, EarnedCashbackCurrencyId = @EarnedCashbackCurrencyId, EarnedCashbackCurrencyName = @EarnedCashbackCurrencyName, EarnedCashbackCurrencyValue = @EarnedCashbackCurrencyValue, EarnedCashbackCurrencySide = @EarnedCashbackCurrencySide, EarnedCashbackCurrencySymbol = @EarnedCashbackCurrencySymbol, EarnedCashbackAmount = @EarnedCashbackAmount, CustomerBeforeBalance = @CustomerBeforeBalance, CustomerAfterBalance = @CustomerAfterBalance, CustomerBeforeCashback = @CustomerBeforeCashback, CustomerAfterCashback = @CustomerAfterCashback, WarehouseId = @WarehouseId, WarehouseName = @WarehouseName, ContractId = @ContractId, ContractCode = @ContractCode, ContractNumber = @ContractNumber, OrderId = @OrderId, OrderCode = @OrderCode, OrderNumber = @OrderNumber, DeliveryLatitude = @DeliveryLatitude, DeliveryLongitude = @DeliveryLongitude, DeliveryLocationName = @DeliveryLocationName, DeliveryDate = @DeliveryDate, IsTrash = @IsTrash, SendSms = @SendSms, SoldAt = @SoldAt, Failed = @Failed, ErrorCode = @ErrorCode, ErrorData = @ErrorData";

//    private static readonly string ItemColumns = "Id, ReceiptUUID, Synced, ProductId, Name, Image, CategoryName, Sku, Barcode, UnitMeasurement, IsMarked, Amount, AmountInBox, SoldAmount, RefundAmount, Price, RealPrice, ProductDiscount, DistributedDiscount, IncludedTax, AddedTax, Discounts, Taxes, Marks";
//    private static readonly string ItemValues = "@Id, @ReceiptUUID, @Synced, @ProductId, @Name, @Image, @CategoryName, @Sku, @Barcode, @UnitMeasurement, @IsMarked, @Amount, @AmountInBox, @SoldAmount, @RefundAmount, @Price, @RealPrice, @ProductDiscount, @DistributedDiscount, @IncludedTax, @AddedTax, @Discounts, @Taxes, @Marks";
//    private static readonly string ItemUpdate = "Id = @Id, ReceiptUUID = @ReceiptUUID, Synced = @Synced, ProductId = @ProductId, Name = @Name, Image = @Image, CategoryName = @CategoryName, Sku = @Sku, Barcode = @Barcode, UnitMeasurement = @UnitMeasurement, IsMarked = @IsMarked, Amount = @Amount, AmountInBox = @AmountInBox, SoldAmount = @SoldAmount, RefundAmount = @RefundAmount, Price = @Price, RealPrice = @RealPrice, ProductDiscount = @ProductDiscount, DistributedDiscount = @DistributedDiscount, IncludedTax = @IncludedTax, AddedTax = @AddedTax, Discounts = @Discounts, Taxes = @Taxes, Marks = @Marks";

//    private static readonly string PaymentColumns = "Id, ReceiptId, Synced, Amount, Paid, BaseCurrencyValue, PaymentMethodId, PaymentMethodName, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
//    private static readonly string PaymentValues = "@Id, @ReceiptId, @Synced, @Amount, @Paid, @BaseCurrencyValue, @PaymentMethodId, @PaymentMethodName, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
//    private static readonly string PaymentUpdate = "Id = @Id, ReceiptId = @ReceiptId, Synced = @Synced, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, PaymentMethodId = @PaymentMethodId, PaymentMethodName = @PaymentMethodName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

//    private static readonly string DiscountColumns = "Id, ReceiptId, Name, ApplyType, Value, CurrencyId, IsCustom";
//    private static readonly string DiscountValues = "@Id, @ReceiptId, @Name, @ApplyType, @Value, @CurrencyId, @IsCustom";
//    private static readonly string DiscountUpdate = "Id = @Id, ReceiptId = @ReceiptId, Name = @Name, ApplyType = @ApplyType, Value = @Value, CurrencyId = @CurrencyId, IsCustom = @IsCustom";

//    private static readonly string InstallmentColumns = "Id, ReceiptId, Date, Amount";
//    private static readonly string InstallmentValues = "@Id, @ReceiptId, @Date, @Amount";
//    private static readonly string InstallmentUpdate = "Id = @Id, ReceiptId = @ReceiptId, Date = @Date, Amount = @Amount";

//    private static readonly string CashbackColumns = "Id, ReceiptId, Amount, Paid, BaseCurrencyValue, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
//    private static readonly string CashbackValues = "@Id, @ReceiptId, @Amount, @Paid, @BaseCurrencyValue, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
//    private static readonly string CashbackUpdate = "Id = @Id, ReceiptId = @ReceiptId, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

//    private static readonly string ChangeColumns = "Id, ReceiptId, Amount, Paid, BaseCurrencyValue, PaymentMethodId, PaymentMethodName, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
//    private static readonly string ChangeValues = "@Id, @ReceiptId, @Amount, @Paid, @BaseCurrencyValue, @PaymentMethodId, @PaymentMethodName, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
//    private static readonly string ChangeUpdate = "Id = @Id, ReceiptId = @ReceiptId, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, PaymentMethodId = @PaymentMethodId, PaymentMethodName = @PaymentMethodName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

//    public async Task<bool> IsExists(string uuid)
//    {
//        return await DBExcutor.QuerySingleOrDefaultAsync<bool>(
//            "SELECT EXISTS(SELECT Uuid FROM receipt WHERE Uuid = @uuid)",
//            new { uuid }
//           );
//    }

//    public async Task<int> GetCountOfUnsynceds()
//    {
//        return await DBExcutor.QuerySingleOrDefaultAsync<int>(
//           "SELECT COUNT(Uuid) FROM receipt WHERE Number = 0"
//          );
//    }

//    public async Task<int> SetFailData(
//        string uuid,
//        int failed,
//        int errorCode,
//        string errorData
//        )
//    {
//        return await DBExcutor.ExecuteAsync(
//            "UPDATE receipt SET Failed = @failed, ErrorCode = @errorCode, ErrorData = @errorData WHERE Uuid = @uuid",
//            new { uuid, failed, errorCode, errorData }
//         );
//    }

//    public async Task<int> ClearFailCount()
//    {
//        return await DBExcutor.ExecuteAsync(
//          "UPDATE receipt SET Failed = 0 WHERE Failed != 0"
//       );
//    }

//    public async Task<int> Insert(
//        IEnumerable<Receipt> receipts,
//        IEnumerable<ReceiptPayment> payments,
//        IEnumerable<ReceiptInstallment> installments,
//        IEnumerable<ReceiptCashback> cashbacks,
//        IEnumerable<ReceiptDiscount> discounts,
//        IEnumerable<ReceiptChange> changes
//        )
//    {
//        return await DBExcutor.InTransaction(async connection =>
//        {
//            await Insert(payments, connection);
//            await Insert(installments, connection);
//            await Insert(cashbacks, connection);
//            await Insert(discounts, connection);
//            await Insert(changes, connection);
//            return await Insert(receipts, connection);
//        });
//    }


//    public async Task<int> Insert(Receipt receipt)
//    {
//        return await DBExcutor.ExecuteAsync(
//          "INSERT INTO receipt(" + ReceiptColumns + ") VALUES(" + ReceiptValues + ") " +
//           "ON CONFLICT (Uuid) " +
//           "DO UPDATE SET " + ReceiptUpdate, receipt);
//    }

//    public async Task Insert(
//    Receipt receipt,
//    IEnumerable<ReceiptPayment> payments,
//    IEnumerable<ReceiptInstallment> installments,
//    IEnumerable<ReceiptCashback> cashbacks,
//    IEnumerable<ReceiptDiscount> discounts,
//    IEnumerable<ReceiptChange> changes,
//    bool replace = false
//    )
//    {
//        return await DBExcutor.InTransaction(async connection =>
//        {
//            if (replace)
//                await DeleteReceiptAndDetails(receipt.Uuid);
//            if (receipt != null)
//                await Insert(payments, connection);
//            await Insert(installments, connection);
//            await Insert(cashbacks, connection);
//            await Insert(discounts, connection);
//            await Insert(changes, connection);
//            return await Insert(receipts, connection);
//        });
//    }

//    public async Task<int> Insert(IEnumerable<ReceiptItem> items)
//    {

//    }

//    public async Task DeleteReceiptAndDetails()
//    {

//    }


//    public async Task UpdateRefundAmounts(IEnumerable<Tuple<string, double>> items)
//    {

//    }

//    public async Task<Receipt> Get(string uuid)
//    {

//    }

//    public async Task<IEnumerable<ReceiptItem>> GetItems(string uuid)
//    {

//    }

//    public async Task<IEnumerable<string>> GetRefunds(string uuid)
//    {

//    }

//    public async Task<IEnumerable<Receipt>> GetRange(
//        bool synced,
//        int minFailedAttempts,
//        int limit
//        )
//    {

//    }

//    public async Task<IEnumerable<Receipt>> GetReceipts(
//        [Required] int offset,
//        [Required] int limit,
//        [Required] string organizationId,
//        string state,
//        string searchQuery,
//        string customerId,
//        string productId,
//        DateTimeOffset fromDate,
//        DateTimeOffset toDate,
//        string currencyId,
//        double fromSum,
//        double toSum,
//        bool isRefund,
//        bool notCompletelyRefunded
//        )
//    {

//    }

//    private async Task<int> Insert(IEnumerable<Receipt> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//           "INSERT INTO receipt(" + ReceiptColumns + ") VALUES(" + ReceiptValues + ") " +
//            "ON CONFLICT (Uuid) " +
//            "DO UPDATE SET " + ReceiptUpdate, items, connection);
//    }

//    private async Task<int> Insert(IEnumerable<ReceiptPayment> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//           "INSERT INTO receipt_payment(" + PaymentColumns + ") VALUES(" + PaymentValues + ") " +
//            "ON CONFLICT (Id) " +
//            "DO UPDATE SET " + PaymentUpdate, items, connection);
//    }

//    private async Task<int> Insert(IEnumerable<ReceiptInstallment> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//         "INSERT INTO receipt_installment(" + InstallmentColumns + ") VALUES(" + InstallmentValues + ") " +
//          "ON CONFLICT (Id, ReceiptId) " +
//          "DO UPDATE SET " + InstallmentUpdate, items, connection);
//    }

//    private async Task<int> Insert(IEnumerable<ReceiptCashback> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//         "INSERT INTO receipt_cashback(" + CashbackColumns + ") VALUES(" + CashbackValues + ") " +
//          "ON CONFLICT (Id, ReceiptId) " +
//          "DO UPDATE SET " + CashbackUpdate, items, connection);
//    }

//    private async Task<int> Insert(IEnumerable<ReceiptDiscount> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//         "INSERT INTO receipt_discount(" + DiscountColumns + ") VALUES(" + DiscountValues + ") " +
//          "ON CONFLICT (Id, ReceiptId) " +
//          "DO UPDATE SET " + DiscountUpdate, items, connection);
//    }

//    private async Task<int> Insert(IEnumerable<ReceiptChange> items, NpgsqlConnection connection = null)
//    {
//        return await DBExcutor.ExecuteAsync(
//         "INSERT INTO receipt_change(" + ChangeColumns + ") VALUES(" + ChangeValues + ") " +
//          "ON CONFLICT (Id, ReceiptId) " +
//          "DO UPDATE SET " + ChangeUpdate, items, connection);
//    }
//}
