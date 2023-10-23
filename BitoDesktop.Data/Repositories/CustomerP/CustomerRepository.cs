using BitoDesktop.Domain.Entities.CustomerP;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.CustomerP;

public class CustomerRepository
{

    private const string CustomerColumns = "Id, Type, PersonId, PersonName, CategoryId, CategoryName, Name, Inn, PhoneNumber, AgentId, AgentName, Latitude, Longitude, AddressName, Description, FirstSale, LastSale, TotalSale, Point, Organizations";
    private const string CustomerValues = "@Id, @Type, @PersonId, @PersonName, @CategoryId, @CategoryName, @Name, @Inn, @PhoneNumber, @AgentId, @AgentName, @Latitude, @Longitude, @AddressName, @Description, @FirstSale, @LastSale, @TotalSale, @Point, @Organizations";
    private const string CustomerUpdate = "Type = @Type, PersonId = @PersonId, PersonName = @PersonName, CategoryId = @CategoryId, CategoryName = @CategoryName, Name = @Name, Inn = @Inn, PhoneNumber = @PhoneNumber, AgentId = @AgentId, AgentName = @AgentName, Latitude = @Latitude, Longitude = @Longitude, AddressName = @AddressName, Description = @Description, FirstSale = @FirstSale, LastSale = @LastSale, TotalSale = @TotalSale, Point = @Point, Organizations = @Organizations";

    private const string CashbackColumns = "Id, CustomerId, Amount, CurrencyId";
    private const string CashbackValues = "@Id, @CustomerId, @Amount, @CurrencyId";
    private const string CashbackUpdate = "Id = @Id, CustomerId = @CustomerId, Amount = @Amount, CurrencyId = @CurrencyId";

    private const string TotalBalanceColumns = "CustomerId, OrganizationId, BalanceList";
    private const string TotalBalanceValues = "@CustomerId, @OrganizationId, @BalanceList";
    private const string TotalBalanceUpdate = "CustomerId = @CustomerId, OrganizationId = @OrganizationId, BalanceList = @BalanceList";

    private const string BalanceListColumns = "CustomerId, OrganizationId, BalanceList";
    private const string BalanceListValues = "@CustomerId, @OrganizationId, @BalanceList";
    private const string BalanceListUpdate = "CustomerId = @CustomerId, OrganizationId = @OrganizationId, BalanceList = @BalanceList";

    public async Task Insert(
        Customer item,
        IEnumerable<CustomerBalanceList> balanceList,
        IEnumerable<CustomerTotalBalance> totalBalance,
        IEnumerable<CustomerCashback> cashbacks
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await Insert(item, connection);
            await Insert(totalBalance, connection);
            await Insert(balanceList, connection);
            if (cashbacks != null)
                await Insert(cashbacks, connection);
        });
    }
    // merge all customers balanceList, totalBalance and chashback lists into one while mapping
    public async Task Insert(
        IEnumerable<Customer> items,
        IEnumerable<CustomerBalanceList> balanceList,
        IEnumerable<CustomerTotalBalance> totalBalance,
        IEnumerable<CustomerCashback> cashbacks
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync(
               "INSERT INTO customer(" + CustomerColumns + ") VALUES(" + CustomerValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + CustomerUpdate, items, connection);
            await Insert(totalBalance, connection);
            await Insert(balanceList, connection);
            if (cashbacks != null)
                await Insert(cashbacks, connection);
        });
    }

    private async Task<int> Insert(Customer item, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
             "INSERT INTO customer(" + CustomerColumns + ") VALUES(" + CustomerValues + ") " +
             "ON CONFLICT (Id) " +
             "DO UPDATE SET " + CustomerUpdate, item, connection);
    }

    public async Task<int> Insert(IEnumerable<CustomerCashback> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
              "INSERT INTO customer_cashback(" + CashbackColumns + ") VALUES(" + CashbackValues + ") " +
              "ON CONFLICT (Id) " +
              "DO UPDATE SET " + CashbackUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<CustomerBalanceList> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO customer_balance_list(" + BalanceListColumns + ") VALUES(" + BalanceListValues + ") " +
            "ON CONFLICT (CustomerId, OrganizationId) " +
            "DO UPDATE SET " + BalanceListUpdate, items, connection);
    }

    private async Task<int> Insert(IEnumerable<CustomerTotalBalance> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO customer_total_balance(" + TotalBalanceColumns + ") VALUES(" + TotalBalanceValues + ") " +
            "ON CONFLICT (CustomerId, OrganizationId) " +
            "DO UPDATE SET " + TotalBalanceUpdate, items, connection);
    }

    public async Task<int> RemoveCustomerFromOrganization(string customerId, string organizationId)
    {
        var customer = await GetById(customerId, null, false, false);
        if (customer == null)
            return 0;
        customer.Organizations.Remove(organizationId);
        return await Insert(customer);
    }


    public async Task Delete(List<string> customerIds)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync(
              "DELETE FROM customer WHERE Id IN (@customerIds)",
               new { customerIds }
             );
            await DBExcutor.ExecuteAsync(
             "DELETE FROM customer_cashback WHERE CustomerId IN (@customerIds)",
              new { customerIds }
            );
            await DBExcutor.ExecuteAsync(
             "DELETE FROM customer_total_balance WHERE CustomerId IN (@customerIds)",
              new { customerIds }
            );
            await DBExcutor.ExecuteAsync(
             "DELETE FROM customer_balance_list WHERE CustomerId IN (@customerIds)",
              new { customerIds }
            );
        });
    }

    public async Task<Customer> GetById(
        [Required] string customerId,
        string organizationId,
        [Required] bool withTotalSpent, // true, TotalBalance is added to the returning customer model 
        [Required] bool withBalance     // true, BalanceList is added to the returning customer model 
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * ");
        if (withTotalSpent)
            query.Append(", totalSpent.BalanceList as TotalSpent ");
        if (withBalance)
            query.Append(", balanceList.BalanceList as Balance ");

        query.Append("FROM customer ");

        var args = new Dictionary<string, object>();
        if (withTotalSpent)
        {
            query.Append("LEFT JOIN customer_total_balance totalSpent ON totalSpent.CustomerId = Id ");
            //            if (organizationId != null){
            //                query.Append("AND totalSpent.organizationId = ? ")
            //                args.add(organizationId)
            //            }
        }
        if (withBalance)
        {
            query.Append("LEFT JOIN customer_balance_list balanceList ON balanceList.CustomerId = Id ");
            if (organizationId != null)
            {
                query.Append("AND balanceList.OrganizationId = @organizationId ");
                args.Add("organizationId", organizationId);
            }
        }

        filtered = true;
        query.Append("WHERE Id = @customerId AND ");
        args.Add("customerId", customerId);

        if (organizationId != null)
        {
            filtered = true;
            query.Append("organizations LIKE @organizationId AND ");
            args.Add("organizationId", $"%{organizationId}%");
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

        return await DBExcutor.QuerySingleOrDefaultAsync<Customer>(
         query.ToString(),
         args
        );
    }

    public async Task<IEnumerable<CustomerCashback>> GetCashbacks(string customerId)
    {
        return await DBExcutor.QueryAsync<CustomerCashback>(
            "SELECT * FROM customer_cashback WHERE CustomerId = @customerId",
            new { customerId }
            );
    }

    public async Task<CustomerBalanceList> GetBalance(string customerId, string organizationId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<CustomerBalanceList>(
            "SELECT * FROM customer_balance_list WHERE CustomerId = @customerId AND OrganizationId = @organizationId",
            new { customerId, organizationId }
            );
    }

    /*
     * returns customers which are located inside of the given rect
     */
    public async Task<IEnumerable<CustomerAddress>> GetCustomers(
       double topLeftLatitude,
       double topLeftLongitude,
       double bottomRightLatitude,
       double bottomRightLongitude,
       string organizationId
       )
    {
        return await DBExcutor.QueryAsync<CustomerAddress>(
            "SELECT Id, Name, PhoneNumber, Latitude, Longitude, AddressName FROM customer " +
            "WHERE Organizations LIKE @AND " +
            "Latitude >= @bottomRightLatitude AND " +
            "Latitude <= @topLeftLatitude AND " +
            "Longitude >= @topLeftLongitude AND " +
            "Longitude <= @bottomRightLongitude",
            new { organizationId, topLeftLatitude, topLeftLongitude, bottomRightLatitude, bottomRightLongitude }
            );
    }

    #region Buni ishlatamiz
    public async Task<IEnumerable<Customer>> GetCustomers(
        string searchQuery,
        string organizationId,            // if provided, returns customers that are available only in that organization
        bool withTotalSpent,   // true, TotalBalance is added to the returning customer model 
        bool withBalance,      // true, BalanceList is added to the returning customer model 
        bool forMap,            // true, returns ones only with location info.
        int? offset = null,
        int? limit = null)
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * ");
        if (withTotalSpent)
            query.Append(", totalSpent.BalanceList as TotalSpent ");
        if (withBalance)
            query.Append(", balanceList.BalanceList as Balance ");

        query.Append("FROM customer ");

        var args = new Dictionary<string, object>();

        if (withTotalSpent)
        {
            query.Append("LEFT JOIN customer_total_balance totalSpent ON totalSpent.CustomerId = Id ");
            if (organizationId != null)
            {
                query.Append("AND totalSpent.OrganizationId = @organizationId ");
                args.Add("organizationId", organizationId);
            }
        }
        if (withBalance)
        {
            query.Append("LEFT JOIN customer_balance_list balanceList ON balanceList.CustomerId = Id ");
            if (organizationId != null)
            {
                query.Append("AND balanceList.organizationId = @organizationId ");
                args.Add("organizationId", organizationId);
            }
        }
        query.Append("WHERE ");
        if (organizationId != null)
        {
            filtered = true;
            query.Append("organizations LIKE @organizationId AND ");
            args.Add("organizationId", $"%{organizationId}%");
        }

        if (forMap)
        {
            filtered = true;
            query.Append("Latitude IS NOT NULL AND ");
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var search = $"%{searchQuery}%";
            query.Append("(name LIKE @search OR phoneNumber LIKE @search");
            if (forMap)
            {
                query.Append(" OR addressName LIKE @search)");
            }
            else
                query.Append(")");
            args.Add("search", search);
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

        if (limit != null)
        {
            query.Append("ORDER BY Name ")
                .Append("LIMIT @limit ");
            args.Add("@limit", limit);
        }

        if (offset != null)
        {
            query.Append("OFFSET @offset "); 
            args.Add("@offset", offset);
        }

        return await DBExcutor.QueryAsync<Customer>(
            query.ToString(),
            args
            );
    }
    #endregion
}

