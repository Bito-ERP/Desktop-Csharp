using BitoDesktop.Domain.Entities.Hr;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Hr;

public class EmployeeRepository
{
    private const string EmployeeColumns = "Id, FullName, PersonId, PersonName, IsBoss, EmploymentType, WorkRate, Holidays, Salary, PhoneNumber, BossId, Address, BirthDate, AcceptanceDate, Pincode, Image, Comment";
    private const string EmployeeValues = "@Id, @FullName, @PersonId, @PersonName, @IsBoss, @EmploymentType, @WorkRate, @Holidays, @Salary, @PhoneNumber, @BossId, @Address, @BirthDate, @AcceptanceDate, @Pincode, @Image, @Comment";
    private const string EmployeeUpdate = "Id = @Id, FullName = @FullName, PersonId = @PersonId, PersonName = @PersonName, IsBoss = @IsBoss, EmploymentType = @EmploymentType, WorkRate = @WorkRate, Holidays = @Holidays, Salary = @Salary, PhoneNumber = @PhoneNumber, BossId = @BossId, Address = @Address, BirthDate = @BirthDate, AcceptanceDate = @AcceptanceDate, Pincode = @Pincode, Image = @Image, Comment = @Comment";

    private const string EmployeePositionColumns = "EmployeeId, OrganizationId, RoleId, RoleName, SectionId, SectionName, PositionId, PositionName";
    private const string EmployeePositionValues = "@EmployeeId, @OrganizationId, @RoleId, @RoleName, @SectionId, @SectionName, @PositionId, @PositionName";
    private const string EmployeePositionUpdate = "EmployeeId = @EmployeeId, OrganizationId = @OrganizationId, RoleId = @RoleId, RoleName = @RoleName, SectionId = @SectionId, SectionName = @SectionName, PositionId = @PositionId, PositionName = @PositionName";


    public async Task Insert(Employee employee)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            var result = await Insert(employee, connection);
            if (employee.Positions != null)
            {
                await Insert(employee.Positions, connection);
            }
            return result;
        });
    }

    public async Task Insert(IEnumerable<Employee> employees)
    {
        await DBExcutor.InTransaction(async connection =>
        {
            await Insert(employees, connection);
            var positions = new List<EmployeePosition>();
            foreach (var employee in employees)
            {
                if (employee.Positions != null)
                {
                    positions.AddRange(employee.Positions);
                }
            }
            return await Insert(positions, connection);
        });
    }

    public async Task<int> DeletePosition([Required] string employeeId, [Required] string organizationId)
    {
        return await DBExcutor.ExecuteAsync(
            "DELETE FROM employee_postion WHERE EmployeeId=@employeeId AND OrganizationId = @organizationId",
            new { employeeId, organizationId }
            );
    }

    public async Task<int> Delete(List<string> employeeIds)
    {
        return await DBExcutor.ExecuteAsync(
          "DELETE FROM employee WHERE Id IN (@employeeIds)",
          new { employeeIds }
          );
    }

    public async Task<int> Delete(string employeeId)
    {
        return await DBExcutor.ExecuteAsync(
        "DELETE FROM employee WHERE Id = @employeeId",
        new { employeeId }
        );
    }

    public async Task<bool> IsBoss(string employeeId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<bool>(
       "SELECT IsBoss FROM employee WHERE Id = @employeeId",
       new { employeeId }
       );
    }

    public async Task<int> UpdateFullName(string employeeId, string fullName)
    {
        return await DBExcutor.ExecuteAsync(
      "UPDATE employee SET FullName = @fullName WHERE Id = @employeeId",
      new { fullName, employeeId }
      );
    }


    public async Task<Employee> Get(string employeeId, string organizationId)
    {
        if (organizationId == null)
            return await Get(employeeId);

        var employee = await Get(employeeId);
        if (employee != null)
            employee.Positions = await GetPositions(employeeId, organizationId);
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetEmployees(
        [Required] int offset,
        [Required] int limit,
        string searchQuery,
        string organizationId // filter by organizaton
        )
    {
        var filtered = false;

        var query = new StringBuilder("SELECT * FROM employee ");
        var args = new Dictionary<string, object>();

        if (organizationId != null)
        {
            query.Append("JOIN employee_position pos ON pos.EmployeeId = Id AND pos.OrganizationId = @organizationId ");
            args.Add("@organizationId", organizationId);
        }

        query.Append("WHERE ");

        if (searchQuery != null && searchQuery.Length != 0)
        {
            var search = "%" + searchQuery + "%";
            query.Append("(fullName LIKE @search or phoneNumber LIKE @search)");
            args.Add("@search", search);
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

        if (organizationId != null)
            query.Append("GROUP BY Id ");

        query.Append("ORDER BY FullName ")
            .Append(
               "LIMIT @limit "
             ).Append(
             "OFFSET @offset "
         );

        args.Add("@limit", limit);
        args.Add("@offset", offset);

        return await DBExcutor.QueryAsync<Employee>(
            query.ToString(),
            args
            );
    }


    private async Task<int> Insert(IEnumerable<Employee> employee, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO employee(" + EmployeeColumns + ") VALUES(" + EmployeeValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + EmployeeUpdate, employee, connection);
    }

    private async Task<int> Insert(Employee employee, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO employee(" + EmployeeColumns + ") VALUES(" + EmployeeValues + ") " +
            "ON CONFLICT (Id) " +
            "DO UPDATE SET " + EmployeeUpdate, employee, connection);
    }

    private async Task<int> Insert(IEnumerable<EmployeePosition> positions, NpgsqlConnection connection = null)
    {
        return await DBExcutor.ExecuteAsync(
            "INSERT INTO employee_position(" + EmployeePositionColumns + ") VALUES(" + EmployeePositionValues + ") " +
            "ON CONFLICT (EmployeeId, OrganizationId, SectionId, PositionId) " +
            "DO UPDATE SET " + EmployeePositionUpdate, positions, connection);
    }


    private async Task<Employee> Get(string employeeId)
    {
        return await DBExcutor.QuerySingleOrDefaultAsync<Employee>(
            "SELECT * FROM employee WHERE Id = @employeeId",
            new { employeeId }
            );
    }

    private async Task<IEnumerable<EmployeePosition>> GetPositions(string employeeId, string organizationId)
    {
        return await DBExcutor.QueryAsync<EmployeePosition>(
            "SELECT * FROM employee_position WHERE EmployeeId = @employeeId AND OrganizationId = @organizationId",
            new { employeeId, organizationId }
            );
    }

}

