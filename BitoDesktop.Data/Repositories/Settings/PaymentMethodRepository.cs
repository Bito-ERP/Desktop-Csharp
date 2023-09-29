using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Domain.Entities.Settings;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Settings;

public class PaymentMethodRepository
{

    private const string PaymentMethodColumns = "Id, Name, IsEnabled";
    private const string PaymentMethodValues = "@Id, @Name, @IsEnabled";
    private const string PaymentMethodUpdate = "Name = @Name, IsEnabled = @IsEnabled";

    public async Task<int> Insert(IEnumerable<PaymentMethod> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO payment_method(" + PaymentMethodColumns + ") VALUES(" + PaymentMethodValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + PaymentMethodUpdate, items, connection);
    }

    public async Task<int> Insert(PaymentMethod paymentMethod)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO payment_method(" + PaymentMethodColumns + ") VALUES(" + PaymentMethodValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + PaymentMethodUpdate, paymentMethod);
    }

    public async Task<int> ReplaceAll(IEnumerable<PaymentMethod> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM payment_method");
            return await Insert(items, connection); 
        });
    }


    public async Task<PaymentMethod> GetById(string paymentMethodId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<PaymentMethod>(
           "SELECT * FROM payment_method WHERE Id = @paymentMethodId",
           new { paymentMethodId }
           );
    }

    public async Task<IEnumerable<PaymentMethod>> GetAll()
    {
        return await DBExcutor.QueryAsync<PaymentMethod>("SELECT * FROM payment_method");
    }

}
