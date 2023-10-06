using BitoDesktop.Domain.Entities.Sale;
using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Sale;

public class PrinterRepostiory
{
    private const string PrinterColumns = "Id, Name, Type, Address, PaperWidth, PrintReceipts, AutomaticallyPrintReceipts";
    private const string PrinterValues = "@Id, @Name, @Type, @Address, @PaperWidth, @PrintReceipts, @AutomaticallyPrintReceipts";
    private const string PrinterUpdate = "Id = @Id, Name = @Name, Type = @Type, Address = @Address, PaperWidth = @PaperWidth, PrintReceipts = @PrintReceipts, AutomaticallyPrintReceipts = @AutomaticallyPrintReceipts";

    public async Task<int> Insert(Printer item)
    {
        return await DBExcutor.ExecuteAsync(
          "INSERT INTO printer(" + PrinterColumns + ") VALUES(" + PrinterValues + ") " +
          "ON CONFLICT (Id) " +
          "DO UPDATE SET " + PrinterUpdate, item);
    }

    public async Task<int> Insert(IEnumerable<Printer> items)
    {
        return await DBExcutor.ExecuteAsync(
               "INSERT INTO printer(" + PrinterColumns + ") VALUES(" + PrinterValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + PrinterUpdate, items);
    }

    public async Task<int> ReplaceAll(IEnumerable<Printer> items)
    {
        return await DBExcutor.InTransaction(async connection =>
        {
            await DBExcutor.ExecuteAsync("DELETE FROM printer");
            return await DBExcutor.ExecuteAsync(
               "INSERT INTO printer(" + PrinterColumns + ") VALUES(" + PrinterValues + ") " +
               "ON CONFLICT (Id) " +
               "DO UPDATE SET " + PrinterUpdate, items);
        });
    }


    public async Task<Printer> GetById(string printerId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Printer>(
           "SELECT * FROM printer WHERE Id = @printerId",
           new { printerId }
           );
    }

    public async Task<IEnumerable<Printer>> GetAll(string searchQuery)
    {
        return await DBExcutor.QueryAsync<Printer>(
          "SELECT * FROM printer WHERE Name LIKE @searchQuery",
          new { searchQuery = $"%{searchQuery??""}%" }
          );
    }

    // only PrintReceipts = TRUE
    public async Task<IEnumerable<Printer>> GetPrintAll(string searchQuery)
    {
        return await DBExcutor.QueryAsync<Printer>(
          "SELECT * FROM printer WHERE Name LIKE @searchQuery AND PrintReceipts = TRUE",
          new { searchQuery = $"%{searchQuery ?? ""}%" }
          );
    }


    // only AutomaticallyPrintReceipts = TRUE
    public async Task<IEnumerable<Printer>> GetAutomaticallyPrintAll(string searchQuery)
    {
        return await DBExcutor.QueryAsync<Printer>(
          "SELECT * FROM printer WHERE Name LIKE @searchQuery AND AutomaticallyPrintReceipts = TRUE",
          new { searchQuery = $"%{searchQuery ?? ""}%" }
          );
    }

    public async Task<int> Delete(string printerId)
    {
        return await DBExcutor.ExecuteAsync(
        "DELETE FROM printer WHERE Id = @printerId",
        new { printerId }
        );
    }

}
