using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Service.Exceptions;
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

        public async Task<bool> SaveConfigs(string priceId, string warehouseId, string organizationId, string deviceId, string serverId, string token)
        {
            await repository.PutString("price", priceId);
            await repository.PutString("warehouse", warehouseId);
            await repository.PutString("organization", organizationId);
            await repository.PutString("device", deviceId);
            await repository.PutString("server", serverId);
            await repository.PutString("token", token);

            return true;
        }
        public async Task<bool> SaveCustomConfig(string key, string value)
        {
            await repository.PutString(key, value);

            return true;
        }

        public async Task<string> Get(string key)
        {
            var price = await repository.GetString(key);

            if (price == null)
                throw new MarketException(404, "price not found");
            return price;
        }

        public async Task<bool> IsDataExist()
        {
            var organization = await repository.GetString("organization");
            var price = await repository.GetString("price");
            var warehouse = await repository.GetString("warehouse");
            var device = await repository.GetString("device");
            var server = await repository.GetString("server");
            var token = await repository.GetString("token");
            var employee = await repository.GetString("employee");

            return !string.IsNullOrEmpty(organization) && !string.IsNullOrEmpty(price)
                && !string.IsNullOrEmpty(warehouse) && !string.IsNullOrEmpty(device)
                && !string.IsNullOrEmpty(server) && !string.IsNullOrEmpty(token)
                && !string.IsNullOrEmpty(employee);
        }
    }
}
