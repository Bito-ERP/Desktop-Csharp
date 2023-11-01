using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class ConfigurationService
    {
        private readonly ConfigurationRepository repository;
        public ConfigurationService()
        {
            repository = new ConfigurationRepository();
        }

        public async Task<bool> SaveConfigs(string priceId, string warehouseId, string organizationId)
        {
            await repository.PutString("price", priceId);
            await repository.PutString("warehouse", warehouseId);
            await repository.PutString("organization",organizationId);
            return true;   
        }

        public async Task<string> GetPrice()
        {
            var price = await repository.GetString("price");
            if (price == null)
                throw new MarketException(404, "price not found");
            return price;
        }

        public async Task<string> GetWarehouse()
        {
            var price = await repository.GetString("warehouse");
            if (price == null)
                throw new MarketException(404, "warehouse not found");
            return price;
        }

        public async Task<string> GetOrganization()
        {
            var organization = await repository.GetString("organization");
            if (organization == null)
                throw new MarketException(404, "organization not found");
            return organization;
        }
    }
}
