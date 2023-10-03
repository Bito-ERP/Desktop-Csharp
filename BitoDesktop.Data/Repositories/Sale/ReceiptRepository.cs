using BitoDesktop.Domain.Entities.Sale;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class ReceiptRepository
{

    private static readonly string ReceiptColumns = "Uuid, Id, OrganizationId, Counter, Synced, CalcAddedTaxAfterDiscount, CalcIncludedTaxAfterDiscount, CalcSaleDiscountAfterProducts, TotalToPay, TotalToRefund, TotalPrice, ProductsTotalDiscount, SaleTotalDiscount, TotalIncludedTax, TotalAddedTax, IsRefund, State, Number, RefundNumber, RefundUuid, CashboxId, CashboxName, DeviceId, DeviceName, CreatorId, CreatorName, ResponsibleId, ResponsibleName, CustomerId, CustomerName, CurrencyId, CurrencyName, CurrencySide, CurrencySymbol, BaseCurrencyValue, EarnedCashbackId, EarnedCashbackCurrencyId, EarnedCashbackCurrencyName, EarnedCashbackCurrencyValue, EarnedCashbackCurrencySide, EarnedCashbackCurrencySymbol, EarnedCashbackAmount, CustomerBeforeBalance, CustomerAfterBalance, CustomerBeforeCashback, CustomerAfterCashback, WarehouseId, WarehouseName, ContractId, ContractCode, ContractNumber, OrderId, OrderCode, OrderNumber, DeliveryLatitude, DeliveryLongitude, DeliveryLocationName, DeliveryDate, IsTrash, SendSms, SoldAt, Failed, ErrorCode, ErrorData";
    private static readonly string ReceiptValues = "@Uuid, @Id, @OrganizationId, @Counter, @Synced, @CalcAddedTaxAfterDiscount, @CalcIncludedTaxAfterDiscount, @CalcSaleDiscountAfterProducts, @TotalToPay, @TotalToRefund, @TotalPrice, @ProductsTotalDiscount, @SaleTotalDiscount, @TotalIncludedTax, @TotalAddedTax, @IsRefund, @State, @Number, @RefundNumber, @RefundUuid, @CashboxId, @CashboxName, @DeviceId, @DeviceName, @CreatorId, @CreatorName, @ResponsibleId, @ResponsibleName, @CustomerId, @CustomerName, @CurrencyId, @CurrencyName, @CurrencySide, @CurrencySymbol, @BaseCurrencyValue, @EarnedCashbackId, @EarnedCashbackCurrencyId, @EarnedCashbackCurrencyName, @EarnedCashbackCurrencyValue, @EarnedCashbackCurrencySide, @EarnedCashbackCurrencySymbol, @EarnedCashbackAmount, @CustomerBeforeBalance, @CustomerAfterBalance, @CustomerBeforeCashback, @CustomerAfterCashback, @WarehouseId, @WarehouseName, @ContractId, @ContractCode, @ContractNumber, @OrderId, @OrderCode, @OrderNumber, @DeliveryLatitude, @DeliveryLongitude, @DeliveryLocationName, @DeliveryDate, @IsTrash, @SendSms, @SoldAt, @Failed, @ErrorCode, @ErrorData";
    private static readonly string ReceiptUpdate = "Id = @Id, OrganizationId = @OrganizationId, Counter = @Counter, Synced = @Synced, CalcAddedTaxAfterDiscount = @CalcAddedTaxAfterDiscount, CalcIncludedTaxAfterDiscount = @CalcIncludedTaxAfterDiscount, CalcSaleDiscountAfterProducts = @CalcSaleDiscountAfterProducts, TotalToPay = @TotalToPay, TotalToRefund = @TotalToRefund, TotalPrice = @TotalPrice, ProductsTotalDiscount = @ProductsTotalDiscount, SaleTotalDiscount = @SaleTotalDiscount, TotalIncludedTax = @TotalIncludedTax, TotalAddedTax = @TotalAddedTax, IsRefund = @IsRefund, State = @State, Number = @Number, RefundNumber = @RefundNumber, RefundUuid = @RefundUuid, CashboxId = @CashboxId, CashboxName = @CashboxName, DeviceId = @DeviceId, DeviceName = @DeviceName, CreatorId = @CreatorId, CreatorName = @CreatorName, ResponsibleId = @ResponsibleId, ResponsibleName = @ResponsibleName, CustomerId = @CustomerId, CustomerName = @CustomerName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol, BaseCurrencyValue = @BaseCurrencyValue, EarnedCashbackId = @EarnedCashbackId, EarnedCashbackCurrencyId = @EarnedCashbackCurrencyId, EarnedCashbackCurrencyName = @EarnedCashbackCurrencyName, EarnedCashbackCurrencyValue = @EarnedCashbackCurrencyValue, EarnedCashbackCurrencySide = @EarnedCashbackCurrencySide, EarnedCashbackCurrencySymbol = @EarnedCashbackCurrencySymbol, EarnedCashbackAmount = @EarnedCashbackAmount, CustomerBeforeBalance = @CustomerBeforeBalance, CustomerAfterBalance = @CustomerAfterBalance, CustomerBeforeCashback = @CustomerBeforeCashback, CustomerAfterCashback = @CustomerAfterCashback, WarehouseId = @WarehouseId, WarehouseName = @WarehouseName, ContractId = @ContractId, ContractCode = @ContractCode, ContractNumber = @ContractNumber, OrderId = @OrderId, OrderCode = @OrderCode, OrderNumber = @OrderNumber, DeliveryLatitude = @DeliveryLatitude, DeliveryLongitude = @DeliveryLongitude, DeliveryLocationName = @DeliveryLocationName, DeliveryDate = @DeliveryDate, IsTrash = @IsTrash, SendSms = @SendSms, SoldAt = @SoldAt, Failed = @Failed, ErrorCode = @ErrorCode, ErrorData = @ErrorData";

    private static readonly string ItemColumns = "Id, ReceiptUUID, Synced, ProductId, Name, Image, CategoryName, Sku, Barcode, UnitMeasurement, IsMarked, Amount, AmountInBox, SoldAmount, RefundAmount, Price, RealPrice, ProductDiscount, DistributedDiscount, IncludedTax, AddedTax, Discounts, Taxes, Marks";
    private static readonly string ItemValues = "@Id, @ReceiptUUID, @Synced, @ProductId, @Name, @Image, @CategoryName, @Sku, @Barcode, @UnitMeasurement, @IsMarked, @Amount, @AmountInBox, @SoldAmount, @RefundAmount, @Price, @RealPrice, @ProductDiscount, @DistributedDiscount, @IncludedTax, @AddedTax, @Discounts, @Taxes, @Marks";
    private static readonly string ItemUpdate = "Id = @Id, ReceiptUUID = @ReceiptUUID, Synced = @Synced, ProductId = @ProductId, Name = @Name, Image = @Image, CategoryName = @CategoryName, Sku = @Sku, Barcode = @Barcode, UnitMeasurement = @UnitMeasurement, IsMarked = @IsMarked, Amount = @Amount, AmountInBox = @AmountInBox, SoldAmount = @SoldAmount, RefundAmount = @RefundAmount, Price = @Price, RealPrice = @RealPrice, ProductDiscount = @ProductDiscount, DistributedDiscount = @DistributedDiscount, IncludedTax = @IncludedTax, AddedTax = @AddedTax, Discounts = @Discounts, Taxes = @Taxes, Marks = @Marks";

    private static readonly string PaymentColumns = "Id, ReceiptId, Synced, Amount, Paid, BaseCurrencyValue, Refunded, PaymentMethodId, PaymentMethodName, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
    private static readonly string PaymentValues = "@Id, @ReceiptId, @Synced, @Amount, @Paid, @BaseCurrencyValue, @Refunded, @PaymentMethodId, @PaymentMethodName, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
    private static readonly string PaymentUpdate = "Id = @Id, ReceiptId = @ReceiptId, Synced = @Synced, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, Refunded = @Refunded,PaymentMethodId = @PaymentMethodId, PaymentMethodName = @PaymentMethodName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

    private static readonly string DiscountColumns = "Id, ReceiptId, Name, ApplyType, Value, CurrencyId, IsCustom";
    private static readonly string DiscountValues = "@Id, @ReceiptId, @Name, @ApplyType, @Value, @CurrencyId, @IsCustom";
    private static readonly string DiscountUpdate = "Id = @Id, ReceiptId = @ReceiptId, Name = @Name, ApplyType = @ApplyType, Value = @Value, CurrencyId = @CurrencyId, IsCustom = @IsCustom";

    private static readonly string InstallmentColumns = "Id, ReceiptId, Date, Amount";
    private static readonly string InstallmentValues = "@Id, @ReceiptId, @Date, @Amount";
    private static readonly string InstallmentUpdate = "Id = @Id, ReceiptId = @ReceiptId, Date = @Date, Amount = @Amount";

    private static readonly string CashbackColumns = "Id, ReceiptId, Amount, Paid, BaseCurrencyValue, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
    private static readonly string CashbackValues = "@Id, @ReceiptId, @Amount, @Paid, @BaseCurrencyValue, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
    private static readonly string CashbackUpdate = "Id = @Id, ReceiptId = @ReceiptId, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

    private static readonly string ChangeColumns = "Id, ReceiptId, Amount, Paid, BaseCurrencyValue, PaymentMethodId, PaymentMethodName, CurrencyId, CurrencyName, CurrencyValue, CurrencySide, CurrencySymbol";
    private static readonly string ChangeValues = "@Id, @ReceiptId, @Amount, @Paid, @BaseCurrencyValue, @PaymentMethodId, @PaymentMethodName, @CurrencyId, @CurrencyName, @CurrencyValue, @CurrencySide, @CurrencySymbol";
    private static readonly string ChangeUpdate = "Id = @Id, ReceiptId = @ReceiptId, Amount = @Amount, Paid = @Paid, BaseCurrencyValue = @BaseCurrencyValue, PaymentMethodId = @PaymentMethodId, PaymentMethodName = @PaymentMethodName, CurrencyId = @CurrencyId, CurrencyName = @CurrencyName, CurrencyValue = @CurrencyValue, CurrencySide = @CurrencySide, CurrencySymbol = @CurrencySymbol";

    public async Task<bool> IsExists(string uuid)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<bool>(
            "SELECT EXISTS(SELECT Uuid FROM receipt WHERE Uuid = @uuid)",
            new { uuid }
           );
    }


    // returns the count of unsynchronized receipts
    public async Task<int> GetCountOfUnsynceds()
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<int>(
           "SELECT COUNT(Uuid) FROM receipt WHERE Number = 0"
          );
    }


    // save errorData and errorCode of a exception you get while syncing
    public async Task<int> SetFailData(
        string uuid,
        int failed,
        int errorCode,
        string errorData
        )
    {
        return await DBExcutor.ExecuteAsync(
            "UPDATE receipt SET Failed = @failed, ErrorCode = @errorCode, ErrorData = @errorData WHERE Uuid = @uuid",
            new { uuid, failed, errorCode, errorData }
         );
    }


    // set 0 to failed of all receipts
    public async Task<int> ClearFailCount()
    {
        return await DBExcutor.ExecuteAsync(
          "UPDATE receipt SET Failed = 0 WHERE Failed != 0"
       );
    }

    /*
    * merge all receipts' payments, installments, cashbacks, discounts and changes lists into one while mapping
    * then insert all of them in single transaction
    * usually this is done once after every API page request
    */
    public async Task Insert(
        IEnumerable<Receipt> receipts,
        IEnumerable<ReceiptPayment> payments,
        IEnumerable<ReceiptInstallment> installments,
        IEnumerable<ReceiptCashback> cashbacks,
        IEnumerable<ReceiptDiscount> discounts,
        IEnumerable<ReceiptChange> changes
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            foreach (var item in receipts)
            {
                await DeleteInstallments(item.Uuid);
                await DeleteDiscounts(item.Uuid);
                await DeleteChanges(item.Uuid);
            }
            if (payments != null)
                await Insert(payments, connection);
            if (installments != null)
                await Insert(installments, connection);
            if (cashbacks != null)
                await Insert(cashbacks, connection);
            if (discounts != null)
                await Insert(discounts, connection);
            if (changes != null)
                await Insert(changes, connection);
            await Insert(receipts, connection);
        });
    }

    private async Task<int> Insert(Receipt receipt, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
           "INSERT INTO receipt(" + ReceiptColumns + ") VALUES(" + ReceiptValues + ") " +
            "ON CONFLICT (Uuid) " +
            "DO UPDATE SET " + ReceiptUpdate, receipt, connection);
    }

    /*
    * merge all receipts' payments, installments, cashbacks, discounts and changes lists into one while mapping 
    * then insert all of them in single transaction
    */
    public async Task Insert(
    Receipt receipt,
    IEnumerable<ReceiptItem> items,
    IEnumerable<ReceiptPayment> payments,
    IEnumerable<ReceiptInstallment> installments,
    IEnumerable<ReceiptCashback> cashbacks,
    IEnumerable<ReceiptDiscount> discounts,
    IEnumerable<ReceiptChange> changes,
    bool replace = false
    )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            if (replace)
                await DeleteReceiptAndDetails(receipt.Uuid, connection);
            if (payments != null)
                await Insert(payments, connection);
            await DeleteInstallments(receipt.Uuid, connection);
            if (installments != null)
                await Insert(installments, connection);
            if (cashbacks != null)
                await Insert(cashbacks, connection);
            await DeleteDiscounts(receipt.Uuid, connection);
            if (discounts != null)
                await Insert(discounts, connection);
            await DeleteChanges(receipt.Uuid, connection);
            if (changes != null)
                await Insert(changes, connection);
            await Insert(items, connection);
            await Insert(receipt, connection);
        });
    }

    public async Task<int> Insert(IEnumerable<ReceiptItem> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
        "INSERT INTO receipt(" + ItemColumns + ") VALUES(" + ItemValues + ") " +
         "ON CONFLICT (id) " +
         "DO UPDATE SET " + ItemUpdate, items, connection);
    }


    // Delete all data related to receipt, such as discounts, products, cashbacks ....
    public async Task<int> DeleteReceiptAndDetails(string uuid, NpgsqlConnection connection = null)
    {
        if (connection != null)
            return await DeleteReceiptAndDetails_(uuid, connection);
        else
            return await DBExcutor.InTransaction(async connection => { return await DeleteReceiptAndDetails_(uuid, connection); });
    }

    private async Task<int> DeleteReceiptAndDetails_(string uuid, NpgsqlConnection connection = null)
    {
        await DeletePayments(uuid, connection);
        await DeleteInstallments(uuid, connection);
        await DeleteCashbacks(uuid, connection);
        await DeleteDiscounts(uuid, connection);
        await DeleteChanges(uuid, connection);
        await DeleteItems(uuid, connection);
        return await DeleteReceipt(uuid, connection);
    }


    // used to update amount of products of a receipt just been refunded
    // provide list of tuples containing string(Id) and double(RefundAmount)
    public async Task UpdateRefundAmounts(IEnumerable<Tuple<string, double>> items)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            foreach (var item in items)
            {
                await DBExcutor.ExecuteAsync(
                    "UPDATE receipt_item SET RefundAmount = @value WHERE Id = @id",
                    new
                    {
                        id = item.Item1,
                        value = item.Item2
                    }
                );
            }
        });
    }

    public async Task<Receipt> Get(string uuid)
    {

        var args = new Dictionary<string, object>();
        var query = new StringBuilder("SELECT r.*, ")
            .Append("IFNULL(i.ToBePaid, 0) as ToBePaid, ")
            .Append("IFNULL(i.Paid, 0) as Paid, ")
            .Append("IFNULL(i.ToBeRefunded, 0) as ToBeRefunded, ")
            .Append("IFNULL(i.Refunded, 0) as Refunded ")
            .Append("FROM receipt r ")
            .Append("LEFT JOIN invoice i ON i.TradeId = r.Id ");

        query.Append("WHERE r.Uuid = @uuid");
        args.Add("uuid", uuid);

        var receipt = await DBExcutor.QuerySingleOrDefaultAsync<Receipt>(
            query.ToString(),
            args
            );

        if (receipt != null)
        {
            if (receipt.Synced)
                await DBExcutor.ExecuteAsync("DELTE FROM receipt_payment WHERE ReceiptId = @receiptId AND Synced = FALSE", new { receiptId = receipt.Uuid });
            receipt.Payments = (await GetPayments(receipt.Uuid)).ToList();
            receipt.Installments = (await GetInstallments(receipt.Uuid)).ToList();
            receipt.Cashbacks = (await GetCashbacks(receipt.Uuid)).ToList();
            receipt.Discounts = (await GetDiscounts(receipt.Uuid)).ToList();
            receipt.Changes = (await GetChanges(receipt.Uuid)).ToList();
        }

        return receipt;
    }

    public async Task<IEnumerable<ReceiptItem>> GetItems(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptItem>(
            "SELECT * FROM receipt_item WHERE ReceiptUUID = @uuid",
            new { uuid }
            );
    }


    // returns uuids of receipts which are refund of given receipt(uuid)
    public async Task<IEnumerable<string>> GetRefunds(string uuid)
    {
        return await DBExcutor.QueryAsync<string>(
            "SELECT * FROM receipt WHERE RefundUUID = @uuid",
            new { uuid }
            );
    }

    // used to get receipts to sync, or to export
    public async Task<IEnumerable<Receipt>> GetRange(
        bool? synced,             // false, return only unsynchronized receipts
        int? minFailedAttempts,   // min count of failed attempts
        int? limit
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT r.* FROM receipt r WHERE ");
        var args = new Dictionary<string, object>();

        if (synced != null)
        {
            filtered = true;
            query.Append("r.Synced = @synced AND ");
            args.Add("synced", synced);
        }

        if (minFailedAttempts != null)
        {
            filtered = true;
            query.Append("r.Failed < @minFailedAttempts AND ");
            args.Add("minFailedAttempts", minFailedAttempts);
        }

        if (filtered)
            query.Remove(
                query.Length - 4,
                4
            );
        else
            query.Remove(
                query.Length - 6,
                6
            );

        query.Append(" ORDER BY r.SoldAt ASC ");

        if (limit != null)
        {
            query.Append("LIMIT @limit");
            args.Add("limit", limit);
        }

        var receipts = await DBExcutor.QueryAsync<Receipt>(
               query.ToString(),
               args
           );

        foreach (var receipt in receipts)
        {
            receipt.Payments = (await GetPayments(receipt.Uuid)).ToList();
            receipt.Installments = (await GetInstallments(receipt.Uuid)).ToList();
            receipt.Cashbacks = (await GetCashbacks(receipt.Uuid)).ToList();
            receipt.Discounts = (await GetDiscounts(receipt.Uuid)).ToList();
            receipt.Changes = (await GetChanges(receipt.Uuid)).ToList();
        }
        return receipts;
    }

    public async Task<IEnumerable<Receipt>> GetReceipts(
        [Required] int offset,
        [Required] int limit,
        [Required] string organizationId,  // filter by organization
        string state,                      // filter by state
        string searchQuery,
        string customerId,                 // returns receipts associated with this customer
        string productId,                  // if receipt contains a product with this Id 
        DateTimeOffset? fromDate,          // returns receipts sold after the given date  [exclusive]
        DateTimeOffset? toDate,            // returns receipts sold before the given date [exclusive]
        string currencyId,                 // returns receipts sold in this currency
        double? fromSum,                   // check if TotalToPay >= this
        double? toSum,                     // check if TotalToPay <= this
        bool? isRefund,                    // true to get refund receipts, null to get all items
        bool notCompletelyRefunded         // returns not completely refunded receipts
        )
    {
        var filtered = true;

        var query =
            new StringBuilder("SELECT r.* FROM receipt r WHERE r.OrganizationId = @organizationId AND ");
        var args = new Dictionary<string, object>();

        args.Add("organizationId", organizationId);

        if (fromDate != null)
        {
            filtered = true;
            query.Append("SoldAt >= @fromDate AND ");
            args.Add("fromDate", fromDate);
        }

        if (toDate != null)
        {
            filtered = true;
            query.Append("SoldAt <= @toDate AND ");
            args.Add("toDate", toDate);
        }

        if (customerId != null)
        {
            filtered = true;
            query.Append("CustomerId = @customerId AND ");
            args.Add("customerId", customerId);
        }

        if (productId != null)
        {
            filtered = true;
            query.Append("EXISTS(SELECT Id FROM receipt_item i WHERE i.ReceiptUUID = r.Uuid AND i.ProductId = @productId) AND ");
            args.Add("productId", productId);
        }

        if (currencyId != null)
        {
            filtered = true;
            query.Append("CurrencyId = @currencyId AND ");
            args.Add("currencyId", currencyId);
        }

        if (fromSum != null)
        {
            filtered = true;
            query.Append("TotalToPay >= @fromSum AND ");
            args.Add("fromSum", fromSum);
        }

        if (toSum != null)
        {
            filtered = true;
            query.Append("TotalToPay <= @toSum AND ");
            args.Add("toSum", toSum);
        }

        if (isRefund != null)
        {
            filtered = true;
            query.Append("IsRefund = ? AND ");
            args.Add("isRefund", isRefund);
        }

        if (notCompletelyRefunded == true)
        {
            filtered = true;
            query.Append("TotalAmount != TotalRefundedAmount AND ");
        }

        if (state != null)
        {
            filtered = true;
            query.Append("State = ? AND ");
            args.Add("state", state);
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            //            val transliterator = Transliterator(search)
            var native = $"%{searchQuery}%";
            //            val translitated: String
            //            if (transliterator.isLatin) {
            //                native = "%${transliterator.toLatin()}%"
            //                translitated = "%${transliterator.toCyrillic()}%"
            //            } else {
            //                native = "%${transliterator.toCyrillic()}%"
            //                translitated = "%${transliterator.toLatin()}%"
            //            }

            query.Append(
                "(r.Uuid LIKE @native) "
            );
            args.Add("native", native);
        }
        else if (filtered)
            query.Remove(
                query.Length - 4,
                4
            );
        else
            query.Remove(
                query.Length - 6,
                6
            );

        query.Append(
            "ORDER BY r.SoldAt DESC "
        ).Append(
            "LIMIT @limit "
        ).Append(
            "OFFSET @offset "
        );

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await DBExcutor.QueryAsync<Receipt>(query.ToString(), args);
    }

    private async Task<IEnumerable<ReceiptPayment>> GetPayments(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptPayment>(
            "SELECT * FROM receipt_payment WHERE ReceiptId = @uuid",
            new { uuid }
         );
    }

    private async Task<IEnumerable<ReceiptInstallment>> GetInstallments(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptInstallment>(
            "SELECT * FROM receipt_installment WHERE ReceiptId = @uuid",
            new { uuid }
         );
    }

    private async Task<IEnumerable<ReceiptCashback>> GetCashbacks(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptCashback>(
            "SELECT * FROM receipt_cashback WHERE ReceiptId = @uuid",
            new { uuid }
         );
    }

    private async Task<IEnumerable<ReceiptDiscount>> GetDiscounts(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptDiscount>(
            "SELECT * FROM receipt_discount WHERE ReceiptId = @uuid",
            new { uuid }
         );
    }

    private async Task<IEnumerable<ReceiptChange>> GetChanges(string uuid)
    {
        return await DBExcutor.QueryAsync<ReceiptChange>(
            "SELECT * FROM receipt_changes WHERE ReceiptId = @uuid",
            new { uuid }
         );
    }


    private async Task<int> Insert(IEnumerable<Receipt> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
           "INSERT INTO receipt(" + ReceiptColumns + ") VALUES(" + ReceiptValues + ") " +
            "ON CONFLICT (Uuid) " +
            "DO UPDATE SET " + ReceiptUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<ReceiptPayment> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
           "INSERT INTO receipt_payment(" + PaymentColumns + ") VALUES(" + PaymentValues + ") " +
            "ON CONFLICT (Id, ReceiptId) " +
            "DO UPDATE SET " + PaymentUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<ReceiptInstallment> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
         "INSERT INTO receipt_installment(" + InstallmentColumns + ") VALUES(" + InstallmentValues + ") " +
          "ON CONFLICT (Id, ReceiptId) " +
          "DO UPDATE SET " + InstallmentUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<ReceiptCashback> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
         "INSERT INTO receipt_cashback(" + CashbackColumns + ") VALUES(" + CashbackValues + ") " +
          "ON CONFLICT (Id, ReceiptId) " +
          "DO UPDATE SET " + CashbackUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<ReceiptDiscount> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
         "INSERT INTO receipt_discount(" + DiscountColumns + ") VALUES(" + DiscountValues + ") " +
          "ON CONFLICT (Id, ReceiptId) " +
          "DO UPDATE SET " + DiscountUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<ReceiptChange> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
         "INSERT INTO receipt_change(" + ChangeColumns + ") VALUES(" + ChangeValues + ") " +
          "ON CONFLICT (Id, ReceiptId) " +
          "DO UPDATE SET " + ChangeUpdate, items, connection);
    }

    private async Task<int> DeleteReceipt(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt WHERE Uuid = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeletePayments(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_payment WHERE receiptId = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeleteInstallments(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_installment WHERE receiptId = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeleteCashbacks(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_cashback WHERE receiptId = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeleteDiscounts(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_discount WHERE receiptId = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeleteChanges(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_change WHERE receiptId = @uuid", new { uuid }, connection);
    }
    private async Task<int> DeleteItems(string uuid, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync("DELETE FROM receipt_item WHERE ReceiptUUID = @uuid", new { uuid }, connection);
    }
}
