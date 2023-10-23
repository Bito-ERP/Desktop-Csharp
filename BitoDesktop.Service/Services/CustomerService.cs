using BitoDesktop.Data.Repositories.CustomerP;
using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Service.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public async Task<Customer> GetById(string customerId, string organizationId)
        {
            var customer = await customerRepository
                .GetById(customerId, organizationId, true, true);

            if (customer == null)
                throw new MarketException(404, "Customer not found");

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers(string organizationId,
            string search)
        {
            var customers = (await customerRepository
                .GetCustomers(search, organizationId, false, false, false));

            return customers;
        }
    }
}