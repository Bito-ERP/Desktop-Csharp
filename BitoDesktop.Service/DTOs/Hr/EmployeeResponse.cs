using BitoDesktop.Domain.Entities.Hr;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitoDesktop.Service.DTOs.Hr;

public class EmployeeResponse
{

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("person")]
    public DataResponse Person { get; set; }

    [JsonProperty("acceptance_date")]
    public string AcceptanceDate { get; set; }

    [JsonProperty("birth_date")]
    public string BirthDate { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("pincode")]
    public string Pincode { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("is_boss")]
    public bool IsBoss { get; set; }

    [JsonProperty("is_additional_boss")]
    public bool IsAdditionalBoss { get; set; } = false;

    [JsonProperty("employment_type")]
    public string EmploymentType { get; set; }

    [JsonProperty("work_rate")]
    public double WorkRate { get; set; }

    [JsonProperty("holidays")]
    public int Holidays { get; set; }

    [JsonProperty("salary")]
    public double Salary { get; set; }

    [JsonProperty("boss_id")]
    public string BossId { get; set; } = "";

    [JsonProperty("imageUrl")]
    public string Image { get; set; }

    [JsonProperty("device_sign")]
    public string DeviceSign { get; set; }

    [JsonProperty("receipt_counter")]
    public long? ReceiptCounter { get; set; }

    [JsonProperty("call_record_counter")]
    public long? CallRecordCounter { get; set; }

    [JsonProperty("organizations")]
    public List<Organization> Organizations { get; set; }

    public class Organization
    {
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("role")]
        public DataResponse Role { get; set; }

        [JsonProperty("section")]
        public DataResponse Section { get; set; }

        [JsonProperty("position")]
        public DataResponse Position { get; set; }
    }

    public Employee Get() => new()
    {
        Id = Id,
        FullName = FullName,
        PersonId = Person?.Id,
        PersonName = Person?.Name,
        IsBoss = IsBoss || IsAdditionalBoss,
        EmploymentType = EmploymentType,
        WorkRate = WorkRate,
        Holidays = Holidays,
        Salary = Salary,
        PhoneNumber = PhoneNumber,
        BossId = BossId,
        Address = Address,
        BirthDate = BirthDate == null ? null : DateTimeOffset.Parse(BirthDate),
        AcceptanceDate = DateTimeOffset.Parse(AcceptanceDate),
        Pincode = Pincode,
        Image = Image,
        Comment = Comment,
        Positions = Organizations.Select(org => new EmployeePosition
        {
            EmployeeId = Id,
            OrganizationId = org.OrganizationId,
            RoleId = org.Role.Id,
            RoleName = org.Role.Name,
            SectionId = org.Section?.Id ?? "",
            SectionName = org.Section?.Name,
            PositionId = org.Position?.Id ?? "",
            PositionName = org.Position?.Name
        }).ToList()
    };
}
