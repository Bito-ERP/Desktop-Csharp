using BitoDesktop.Domain.Entities.WarehouseP;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.WarehouseP;

public class CategoryRepository
{
    private const string CategoryColumns = "Id, Name, ParentId, ParentName, Image, ItemCount, ChildCount, OrganizationIds";
    private const string CategoryValues = "@Id, @Name, @ParentId, @ParentName, @Image, @ItemCount, @ChildCount, @OrganizationIds";
    private const string CategoryUpdate = "Name = @Name, ParentId = @ParentId, ParentName = @ParentName, Image = @Image, ItemCount = @ItemCount, ChildCount = @ChildCount, OrganizationIds = @OrganizationIds";

    public async Task<int> Insert(IEnumerable<Category> items, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product_category(" + CategoryColumns + ") VALUES(" + CategoryValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + CategoryUpdate, items, connection);
    }

    public async Task<int> Insert(Category item, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO product_category(" + CategoryColumns + ") VALUES(" + CategoryValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + CategoryUpdate, item, connection);
    }


    public async Task<int> DeletePosition(string categoryId, string organizationId)
    {
        var category = await Get(categoryId);
        if (category == null)
            return 0;
        category.OrganizationIds.Remove(organizationId);
        return await Insert(category);
    }

    public async Task<int> Delete(List<string> itemIds)
    {
        return await DBExcutor.ExecuteAsync(
          "DELETE FROM product_category WHERE Id IN (@itemIds)",
          new { itemIds }
          );
    }
    private async Task<Category> Get(string categoryId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Category>(
            "SELECT * FROM product_category WHERE Id = @categoryId",
            new { categoryId }
            );
    }

    public async Task<IEnumerable<Category>> GetCategories(
        [Required] int offset,
        [Required] int limit,
        string searchQuery,
        string parentCategoryId, // provide categoryId, returns its childres
        bool? onlyTops,          // true, returns categories that don't have parent category
        string organizationId    // filter by organizationId
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * FROM product_category WHERE ");
        var args = new Dictionary<string, object>();

        if (parentCategoryId != null)
        {
            filtered = true;
            query.Append("parentId = @parentCategoryId AND ");
            args.Add("parentCategoryId", parentCategoryId);
        }
        else if (onlyTops == true)
        {
            filtered = true;
            query.Append("parentId IS NULL AND ");
        }

        if (organizationId != null)
        {
            filtered = true;
            query.Append("organizationIds LIKE @organizationId AND ");
            args.Add("organizationId", $"%organizationId%");
        }

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var transliterator = new Transliterator(searchQuery);
            var native = $"%{transliterator.Native()}%";
            var transliterated = $"%{transliterator.Transliterated()}%";

            query.Append(
                "(name LIKE @search1 OR " +
                        "name LIKE @search2) "
            );
            args.Add("search1", native);
            args.Add("search2", transliterated);
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

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await DBExcutor.QueryAsync<Category>(
            query.ToString(),
            args
            );
    }

}
