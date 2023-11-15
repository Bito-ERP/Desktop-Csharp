using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Domain.Entities.Settings;
using BitoDesktop.Service.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class PriceService
    {
        private readonly PriceRepository priceRepository;
        public PriceService()
        {
            priceRepository = new PriceRepository();
        }

        public async Task<IEnumerable<Price>> GetAll()
        {
            var prices = await priceRepository.GetPrices(Client.UserId);

            return prices;
        }
    }
}
