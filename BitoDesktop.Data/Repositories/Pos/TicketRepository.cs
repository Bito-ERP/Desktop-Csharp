using BitoDesktop.Domain.Entities.Hr;
using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Domain.Entities.Sale;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Pos;

public class TicketRepository
{

    private const string TicketColumns = "Id, OrganizationId, Name, OverallSum, PriceId, WarehouseId, CreatedAt, TableId, Comment, CustomerId, Discounts";
    private const string TicketValues = "@Id, @OrganizationId, @Name, @OverallSum, @PriceId, @WarehouseId, @CreatedAt, @TableId, @Comment, @CustomerId, @Discounts";
    private const string TicketUpdate = "OrganizationId = @OrganizationId, Name = @Name, OverallSum = @OverallSum, PriceId = @PriceId, WarehouseId = @WarehouseId, CreatedAt = @CreatedAt, TableId = @TableId, Comment = @Comment, CustomerId = @CustomerId, Discounts = @Discounts";

    private const string TicketItemColumns = "Id, ProductId, Price, Amount, BoxAmount, TicketId, TotalAddedTax, TotalIncludedTax, Taxes, TotalDiscountCash, TotalDiscountPercent, AmountInBox, Discounts, Marks";
    private const string TicketItemValues = "@Id, @ProductId, @Price, @Amount, @BoxAmount, @TicketId, @TotalAddedTax, @TotalIncludedTax, @Taxes, @TotalDiscountCash, @TotalDiscountPercent, @AmountInBox, @Discounts, @Marks";
    private const string TicketItemUpdate = "ProductId = @ProductId, Price = @Price, Amount = @Amount, BoxAmount = @BoxAmount, TicketId = @TicketId, TotalAddedTax = @TotalAddedTax, TotalIncludedTax = @TotalIncludedTax, Taxes = @Taxes, TotalDiscountCash = @TotalDiscountCash, TotalDiscountPercent = @TotalDiscountPercent, AmountInBox = @AmountInBox, Discounts = @Discounts, Marks = @Marks";


    public async Task<long> Insert(Ticket item)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO ticket(" + TicketColumns + ") VALUES(" + TicketValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + TicketUpdate, item
            );
    }

    public async Task Insert([Required] string organizationId, IEnumerable<Table> items)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM ticket WHERE OrgnizationId = @organizationId", connection);
            await DBExcutor.ExecuteAsync(
               "INSERT INTO ticket(" + TicketColumns + ") VALUES(" + TicketValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + TicketUpdate, items, connection
            );
        });
    }

    public async Task<int> UpdateTicket(
        [Required] long ticketId,
        double? overallSum,
        string name,
        string customerId,
        IEnumerable<ReceiptDiscount> discounts,
        string comment
        )
    {
        var query = new StringBuilder("UPDATE ticket SET ");
        var args = new Dictionary<string, object>();

        if (overallSum != null)
        {
            query.Append("overallSum = @, ");
            args.Add("overallSum", overallSum);
        }

        if (name != null)
        {
            query.Append("name = @name, ");
            args.Add("name", name);
        }

        if (customerId != null)
        {
            query.Append("customerId = @customerId, ");
            args.Add("customerId", customerId);
        }

        if (discounts != null)
        {
            query.Append("discounts = @discounts, ");
            args.Add("discounts", discounts);
        }

        if (comment != null)
        {
            query.Append("comment = @comment, ");
            args.Add("comment", comment);
        }

        query.Remove(query.Length - 2, 2);

        query.Append(" WHERE Id = @ticketId");
        args.Add("ticketId", ticketId);


        return await DBExcutor.ExecuteAsync(query.ToString(), args);
    }

    public async Task ReplaceItems(
        long ticketId,
        IEnumerable<TicketItem> ticketItems
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM ticket_item WHERE TicketId = @ticketId", new { ticketId }, connection);
            await DBExcutor.ExecuteAsync(
               "INSERT INTO ticket_item(" + TicketItemColumns + ") VALUES(" + TicketItemValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + TicketItemUpdate, ticketItems, connection
            );
        });
    }

    public async Task<Ticket> Get(long ticketId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Ticket>(
            "SELECT * FROM ticket WHERE Id = @ticketId",
            new { ticketId }
            );
    }

    public async Task<IEnumerable<Ticket>> getAll([Required] string organizationId)
    {
        return await DBExcutor.QueryAsync<Ticket>(
            "SELECT * FROM ticket WHERE OrganizationId = @organizationId ORDER BY Name ASC",
            new { organizationId }
            );
    }

    public async Task<IEnumerable<TicketItem>> getItems(
        [Required] string ticketId,
        [Required] string priceId,
        [Required] string organizationId,
        [Required] string warehouseId
        )
    {
        var query = new StringBuilder("SELECT i.*, ")
            .Append("p.Name as productName, p.Image as ProductImage, ")
            .Append("p.CategoryName as ProductCategoryName, p.Sku as ProductSku, p.Barcode as ProductBarcode, ")
            .Append("p.UnitMeasurementId as ProductUnitMeasureId, p.IsMarked as ProductIsMarked, ")
            .Append("price.PriceAmount as SelectedPriceAmount, ")
            .Append("po.RedLine as RedLine, po.YellowLine as YellowLine, ")
            .Append("COALESCE(warehouse.Amount, 0) as WarehouseAmount ");
        var args = new Dictionary<string, object>();

        query.Append("FROM ticket_item as i ");

        query.Append("JOIN product p ON p.Id = i.ProductId ");
        query.Append("JOIN product_organization po ON po.ProductId = p.Id AND po.OrganizationId = @organizationId ");

        query.Append("LEFT JOIN product_price price ON price.PriceId = @priceId AND price.OrganizationId = @organizationId AND price.ProductId = i.ProductId ");
        query.Append("LEFT JOIN product_warehouse warehouse ON warehouse.WarehouseId = @warehouseId AND warehouse.ProductId = i.ProductId ");

        args.Add("organizationId", organizationId);
        args.Add("priceId", priceId);
        args.Add("warehouseId", warehouseId);


        query.Append("WHERE i.TicketId = @ticketId");
        args.Add("ticketId", ticketId);

        return await DBExcutor.QueryAsync<TicketItem>(query.ToString(), args);

    }

    public async Task Delete(long ticketId)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync(
             "DELETE FROM ticket WHERE Id = @ticketId",
            new { ticketId },
            connection
          );
            await DBExcutor.ExecuteAsync(
            "DELETE FROM ticket_item WHERE TicketId = @ticketId",
            new { ticketId },
            connection
          );
        });
    }

    public async Task Delete(IEnumerable<long> ticketIds)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync(
             "DELETE FROM ticket WHERE Id IN @ticketIds",
            new { ticketIds },
            connection
          );
            await DBExcutor.ExecuteAsync(
            "DELETE FROM ticket_item WHERE TicketId IN @ticketIds",
            new { ticketIds },
            connection
          );
        });
    }

    public async Task Merge(
        IEnumerable<long> ticketIds,
        long toTicketId
        )
    {
        await DBExcutor.InTransaction(async connection =>
        {
            var discounts = new List<ReceiptDiscount>();
            DateTimeOffset? createdAt = null;

            foreach (var ticketId in ticketIds)
            {
                var ticket = await Get(ticketId);
                if (ticket != null && ticket.Discounts != null && ticket.Discounts.Count() > 0)
                {
                    if (discounts == null)
                        discounts = new List<ReceiptDiscount>();

                    foreach (var enDis in ticket.Discounts)
                    {
                        var existingIndex = discounts.FindIndex(dis => dis.Id == enDis.Id);

                        if (existingIndex != -1)
                        {
                            if (enDis.IsCustom && ticket.CreatedAt > createdAt)
                            {
                                createdAt = ticket.CreatedAt;
                                discounts[existingIndex] = enDis;
                            }
                        }
                        else
                        {
                            discounts.Add(enDis);
                            if (enDis.IsCustom)
                                createdAt = ticket.CreatedAt;
                        }
                    }
                }
                await Delete(ticketId);

                await DBExcutor.ExecuteAsync(
                    "UPDATE ticket_item SET TicketId = @toTicketId WHERE ticketId = @ticketId",
                    new { toTicketId, ticketId }
                    );
            }

            var items = await DBExcutor.QueryAsync<TicketItem>(
                "SELECT " +
                "ProductId, Price, SUM(Amount) as Amount, BoxAmount," +
                " TicketId, TotalAddedTax, " +
                "TotalIncludedTax, Taxes, TotalDiscountCash, TotalDiscountPercent, AmountInBox, " +
                "Discounts, Id as Id FROM ticket_item WHERE TicketId = @toTicketId GROUP BY ProductId, Price",
                new { toTicketId }
             );

            await ReplaceItems(toTicketId, items);  

            if (discounts.Count > 0)
            {
                await UpdateTicket(
                    toTicketId,
                    null,
                    null,
                    null,
                    discounts,
                    null
                );
            }


        });
    }

    public async Task<IEnumerable<Table>> GetUnusedTables([Required] string organizationId)
    {
        return await DBExcutor.QueryAsync<Table>(
              "SELECT table.* FROM table " +
                "LEFT JOIN ticket ON table.Id = ticket.TableId " +
                "WHERE OrganizationId = @organizationId AND ticket.TableId IS NULL " +
                "ORDER BY table.`Order` ASC",
              new { organizationId }
            );
    }
}
