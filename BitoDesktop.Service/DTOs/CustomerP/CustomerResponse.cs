using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Service.DTOs.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.CustomerP;
public class CustomerResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("person")]
    public DataResponse Person { get; set; }
    [JsonProperty("category")]
    public DataResponse Category { get; set; }
    [JsonProperty("name")]
    [Required]
    public string Name { get; set; }
    [JsonProperty("inn")]
    public string Inn { get; set; }
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonProperty("agent")]
    public UserResponse Agent { get; set; }
    [JsonProperty("delivery_address")]
    public LocationResponse DeliveryAddress { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("first_sale_at")]
    [Required]
    public string FirstSale { get; set; }
    [JsonProperty("last_sale_at")]
    [Required]
    public string LastSale { get; set; }
    [JsonProperty("total_sale")]
    [Required]
    public double TotalSale { get; set; }
    [JsonProperty("point")]
    [Required]
    public float Point { get; set; }
    [JsonProperty("organization_ids")]
    [Required]
    public List<string> Organizations { get; set; }
    [JsonProperty("total_balance")]
    public List<TotalBalance> TotalBalanceList { get; set; }
    [JsonProperty("balance_list")]
    public List<BalanceListResponse> BalanceList { get; set; }
    [JsonProperty("cashback_list")]
    public List<Cashback> CashbackList { get; set; }

    public Customer Get()
    {
        return new Customer
        {
            Id = Id,
            Type = Type,
            PersonId = Person?.Id,
            PersonName = Person?.Name,
            CategoryId = Category?.Id,
            CategoryName = Category?.Name,
            Name = Name,
            Inn = Inn,
            PhoneNumber = PhoneNumber,
            AgentId = Agent?.Id,
            AgentName = Agent?.FullName,
            Latitude = DeliveryAddress?.Lat,
            Longitude = DeliveryAddress?.Long,
            AddressName = DeliveryAddress?.Address?.Name,
            Description = Description,
            FirstSale = FirstSale == null ? null : DateTimeOffset.Parse(FirstSale),
            LastSale = LastSale == null ? null : DateTimeOffset.Parse(LastSale),
            TotalSale = TotalSale,
            Point = Point,
            Organizations = Organizations,
        };

    }

    public void AddTotalBalances(List<CustomerTotalBalance> data)
    {
        data.Add(new CustomerTotalBalance
        {
            CustomerId = Id,
            OrganizationId = "",
            BalanceList = TotalBalanceList.Select(balance => new CustomerAmount
            {
                Amount = balance.Amount.ToString(),
                CurrencyId = balance.CurrencyId,
            }).ToList(),
        });
    }

    public void AddBalanceList(List<CustomerBalanceList> data)
    {
        var groupedBalanceList = BalanceList.GroupBy(balance => balance.OrganizationId);
        foreach (var group in groupedBalanceList)
        {
            data.Add(new CustomerBalanceList
            {
                CustomerId = Id,
                OrganizationId = group.Key,
                BalanceList = group.Select(balance => new CustomerAmount
                {
                    Amount = balance.Amount.ToString(),
                    CurrencyId = balance.CurrencyId,
                }).ToList(),
            });
        }
    }

    public List<CustomerTotalBalance> GetTotalBalances()
    {
        return new List<CustomerTotalBalance>
        {
            new CustomerTotalBalance
            {
                CustomerId = Id,
                OrganizationId = "",
                BalanceList = TotalBalanceList.Select(balance => new CustomerAmount
                {
                    Amount = balance.Amount.ToString(),
                    CurrencyId = balance.CurrencyId,
                }).ToList(),
            }
        };
    }

    public List<CustomerBalanceList> GetBalanceLists()
    {
        var groupedBalanceList = BalanceList.GroupBy(balance => balance.OrganizationId);
        return groupedBalanceList.Select(group => new CustomerBalanceList
        {
            CustomerId = Id,
            OrganizationId = group.Key,
            BalanceList = group.Select(balance => new CustomerAmount
            {
                Amount = balance.Amount.ToString(),
                CurrencyId = balance.CurrencyId,
            }).ToList(),
        }).ToList();
    }

    public class TotalBalance
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class BalanceListResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class Cashback
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        public CustomerCashback Get()
        {
            return new CustomerCashback
            {
                Id = Id,
                CustomerId = CustomerId,
                Amount = Amount,
                CurrencyId = CurrencyId
            };
        }
    }
}

public class CustomerResponseByInn
{
    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}