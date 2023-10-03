using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitoDesktop.Domain.Entities.Hr;

public class EmployeePosition
{
    [Required]
    public string EmployeeId { get; set; }

    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string RoleId { get; set; }

    [Required]
    public string RoleName { get; set; }

    [Required]
    public string SectionId { get; set; }

    public string SectionName { get; set; }

    [Required]
    public string PositionId { get; set; }

    public string PositionName { get; set; }
}

public class Employee
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string PersonId { get; set; }
    public string PersonName { get; set; }
    public bool IsBoss { get; set; }
    public string EmploymentType { get; set; }
    public double WorkRate { get; set; }
    public int Holidays { get; set; }
    public double Salary { get; set; }
    public string PhoneNumber { get; set; }
    public string BossId { get; set; }
    public string Address { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public DateTimeOffset AcceptanceDate { get; set; }
    [Required]
    public string Pincode { get; set; }
    public string Image { get; set; }
    public string Comment { get; set; }
    public IEnumerable<EmployeePosition> Positions { get; set; } = null;


}
