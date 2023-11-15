using BitoDesktop.Data.Repositories.Finance;
using BitoDesktop.Domain.Entities.Finance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class CurrencyService
    {
        private readonly CurrencyRepository currencyRepository;
        public CurrencyService()
        {
            currencyRepository = new CurrencyRepository();
        }

        public async Task<IEnumerable<Currency>> GetAll()
            => await currencyRepository.GetAll(string.Empty);
    }
}
