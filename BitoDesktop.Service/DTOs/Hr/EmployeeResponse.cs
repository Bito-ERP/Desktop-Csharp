using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Domain.Entities.Hr;
using System;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Hr;

internal class EmployeeResponse
{

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("person")]
    public DataResponse Person { get; set; }

    [JsonPropertyName("acceptance_date")]
    public string AcceptanceDate { get; set; }

    [JsonPropertyName("birth_date")]
    public string? BirthDate { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("pincode")]
    public string Pincode { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("is_boss")]
    public bool IsBoss { get; set; }

    [JsonPropertyName("is_additional_boss")]
    public bool IsAdditionalBoss { get; set; } = false;

    [JsonPropertyName("employment_type")]
    public string EmploymentType { get; set; }

    [JsonPropertyName("work_rate")]
    public double WorkRate { get; set; }

    [JsonPropertyName("holidays")]
    public int Holidays { get; set; }

    [JsonPropertyName("salary")]
    public double Salary { get; set; }

    [JsonPropertyName("boss_id")]
    public string BossId { get; set; } = "";

    [JsonPropertyName("imageUrl")]
    public string? Image { get; set; }

    [JsonPropertyName("device_sign")]
    public string? DeviceSign { get; set; }

    [JsonPropertyName("receipt_counter")]
    public long? ReceiptCounter { get; set; }

    [JsonPropertyName("call_record_counter")]
    public long? CallRecordCounter { get; set; }

    [JsonPropertyName("organizations")]
    public List<Organization> Organizations { get; set; }

    public class Organization
    {
        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("role")]
        public DataResponse Role { get; set; }

        [JsonPropertyName("section")]
        public DataResponse? Section { get; set; }

        [JsonPropertyName("position")]
        public DataResponse? Position { get; set; }
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
