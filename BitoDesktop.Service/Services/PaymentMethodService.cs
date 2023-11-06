using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class PaymentMethodService
    {
        private readonly PaymentMethodRepository paymentMethodRepository;
        public PaymentMethodService()
        {
            paymentMethodRepository = new PaymentMethodRepository();
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()=>
            await paymentMethodRepository.GetAll();
    }
}
