using BitoDesktop.Data.Repositories.CustomerP;
using BitoDesktop.Data.Repositories.Hr;
using BitoDesktop.Data.Repositories.WarehouseP;
using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<CustomerAddress>> GetCustomers(string organizationId,
            string customerName,
            string customerPhoneNumber)
        {
            var customers = (await customerRepository.GetCustomers(
                100, 100, 100, 100, organizationId))
                .Where(c => c.Name.Contains(customerName) 
                || c.PhoneNumber.Contains(customerPhoneNumber));

            return customers;
        }
    }
}
