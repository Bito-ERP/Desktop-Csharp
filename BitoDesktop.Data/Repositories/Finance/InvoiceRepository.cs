using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Finance;

internal class InvoiceRepository
{

    private const string InvoiceColumns = "Id, OrganizationId, Type, Number, PaymentTypeId, PaymentTypeName, UserType, PaymentFor, IsRefund, Date, CustomerId, CustomerName, EmployeeId, EmployeeName, SupplierId, SupplierName, PersonId, PersonName, ToBePaid, Paid, ToBeRefunded, Refunded, PaidByBalance, PaidByCashback, CurrencyId, TradeId";
    private const string InvoiceValues = "@Id, @OrganizationId, @Type, @Number, @PaymentTypeId, @PaymentTypeName, @UserType, @PaymentFor, @IsRefund, @Date, @CustomerId, @CustomerName, @EmployeeId, @EmployeeName, @SupplierId, @SupplierName, @PersonId, @PersonName, @ToBePaid, @Paid, @ToBeRefunded, @Refunded, @PaidByBalance, @PaidByCashback, @CurrencyId, @TradeId";
    private const string InvoiceUpdate = "Id = @Id, OrganizationId = @OrganizationId, Type = @Type, Number = @Number, PaymentTypeId = @PaymentTypeId, PaymentTypeName = @PaymentTypeName, UserType = @UserType, PaymentFor = @PaymentFor, IsRefund = @IsRefund, Date = @Date, CustomerId = @CustomerId, CustomerName = @CustomerName, EmployeeId = @EmployeeId, EmployeeName = @EmployeeName, SupplierId = @SupplierId, SupplierName = @SupplierName, PersonId = @PersonId, PersonName = @PersonName, ToBePaid = @ToBePaid, Paid = @Paid, ToBeRefunded = @ToBeRefunded, Refunded = @Refunded, PaidByBalance = @PaidByBalance, PaidByCashback = @PaidByCashback, CurrencyId = @CurrencyId, TradeId = @TradeId";


    public async Task<int> Insert(Invoice item)
    {
        return await DBExcutor.ExecuteAsync("INSERT INTO receipt(" + InvoiceColumns + ") VALUES(" + InvoiceValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + InvoiceUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<Invoice> items)
    {
        return await DBExcutor.ExecuteAsync("INSERT INTO receipt(" + InvoiceColumns + ") VALUES(" + InvoiceValues + ") " +
         "ON CONFLICT (Id) " +
         "DO UPDATE SET " + InvoiceUpdate, items);
    }

    // Get(invoiceId, 0), by invoiceId
    // Get(TradeId, 1), by tradeId, Id of Receipt
    public async Task<Invoice> Get(string value, int type)
    {
        var query = new StringBuilder("SELECT e.* FROM invoice e WHERE ");
        var args = new Dictionary<string, object>();

        if (type == 0)
        {
            query.Append("e.id = @value ");
        }
        else
        {
            query.Append("e.tradeId = @value ");
        }
        args.Add("value", value);

        return await DBExcutor.QuerySingleOrDefaultAsync<Invoice>(query.ToString(), args);
    }

    public async Task<IEnumerable<Invoice>> GetPage(
        [Required] int offset,
        [Required] int limit,
        string searchQuery,
        string organizationId,    // filter by organization
        string type,              // income/expense
        bool? fullyPaid           // if provided, returns only fully paids or not-yet-paids
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT e.* FROM invoice e WHERE ");
        var args = new Dictionary<string, object>();

        if (organizationId != null)
        {
            filtered = true;
            query.Append("organizationId = @organizationId AND ");
            args.Add("organizationId", organizationId);
        }

        if (type != null)
        {
            filtered = true;
            query.Append("type = @type AND ");
            args.Add("type", type);
        }

        if (fullyPaid != null)
        {
            filtered = true;
            if (fullyPaid == true)
            {
                query.Append("toBePaid - paid = 0 AND ");
            }
            else
            {
                query.Append("toBePaid - paid != 0 AND ");
            }
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            query.Append("(number LIKE @searchQuery)");
            args.Add("searchQuery", $"%{searchQuery}%");
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
            "LIMIT @limit "
        ).Append(
            "OFFSET @offset "
        );

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await DBExcutor.QueryAsync<Invoice>(query.ToString(), args);

    }
}
