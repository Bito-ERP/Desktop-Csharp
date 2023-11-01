using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class ReasonRepostiory
{
    private const string ReasonColumns = "Id, Name, Description, Type, IsActive, IsTrash, OrderNumber, Code";
    private const string ReasonValues = "@Id, @Name, @Description, @Type, @IsActive, @IsTrash, @OrderNumber, @Code";
    private const string ReasonUpdate = "Id = @Id, Name = @Name, Description = @Description, Type = @Type, IsActive = @IsActive, IsTrash = @IsTrash, OrderNumber = @OrderNumber, Code = @Code";

    public async Task<int> Insert(Reason item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO reason(" + ReasonColumns + ") VALUES(" + ReasonValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + ReasonUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<Reason> items)
    {
        return await DBExcutor.ExecuteAsync(
               "INSERT INTO reason(" + ReasonColumns + ") VALUES(" + ReasonValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + ReasonUpdate, items);
    }


    public async Task<Reason> GetById(string reasonId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Reason>(
           "SELECT * FROM reason WHERE Id = @reasonId",
           new { reasonId }
           );
    }

    public async Task<IEnumerable<Reason>> GetReasons(
        [Required] int offset,
        [Required] int limit,
        string searchQuery,
        [Required] string type,  // 'customer_return' for now
        bool? isActive
    )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * FROM reason WHERE ");
        var args = new Dictionary<string, object>();

        filtered = true;
        query.Append("Type = @type AND ");
        args["@type"] = type;

        if (isActive != null)
        {
            filtered = true;
            query.Append("IsActive = @isActive AND ");
            args["@isActive"] = isActive;
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            query.Append("name LIKE @searchQuery");
            args["@searchQuery"] = $"%{searchQuery}%";
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

        query.Append(" ORDER BY Name ")
           .Append(
             "LIMIT @limit "
            ).Append(
            "OFFSET @offset "
          );

        args["@limit"] = limit;
        args["@offset"] = offset;

        return await DBExcutor.QueryAsync<Reason>(query.ToString(), args);
    }

    public async Task<int> Delete(string reasonId)
    {
        return await DBExcutor.ExecuteAsync(
        "DELETE FROM reason WHERE Id = @reasonId",
        new { reasonId }
        );
    }

    public async Task<int> Delete(List<string> reasonIds)
    {
        return await DBExcutor.ExecuteAsync(
          "DELETE FROM reason WHERE Id IN @reasonIds",
          new { reasonIds }
          );
    }

}
