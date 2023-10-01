using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BitoDesktop.Domain.Entities.CustomerP;
public class Customer
{

    [Required]
    public string Id { get; set; }
    [Required]
    public string Type { get; set; }
    public string PersonId { get; set; }
    public string PersonName { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    [Required]
    public string Name { get; set; }
    public string Inn { get; set; }
    public string PhoneNumber { get; set; }
    public string AgentId { get; set; }
    public string AgentName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string AddressName { get; set; }
    public string Description { get; set; }
    [Required]
    public DateTimeOffset? FirstSale { get; set; }
    [Required]
    public DateTimeOffset? LastSale { get; set; }
    public List<CustomerAmount> TotalSpent { get; set; } = null;
    [Required]
    public double TotalSale { get; set; }
    public List<CustomerAmount> Balance { get; set; } = null;
    [Required]
    public float Point { get; set; }
    [Required]
    public List<string> Organizations { get; set; }


}

public class CustomerCashback
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string CustomerId { get; set; }
    [Required]
    public double Amount { get; set; }
    [Required]
    public string CurrencyId { get; set; }
}

public class CustomerTotalBalance
{
    [Required]
    public string CustomerId { get; set; }
    [Required]
    public string OrganizationId { get; set; }
    [Required]
    public IEnumerable<CustomerAmount> BalanceList { get; set; }
}

public class CustomerBalanceList
{
    [Required]
    public string CustomerId { get; set; }
    [Required]
    public string OrganizationId { get; set; }
    [Required]
    public IEnumerable<CustomerAmount> BalanceList { get; set; }
}

public class CustomerAmount
{
    [Required]
    public string CurrencyId { get; set; }
    [Required]
    public string Amount { get; set; }  
}

public class CustomerAddress {
    public string Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string AddressName { get; set; }
}