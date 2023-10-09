using BitoDesktop.Data.Repositories.CustomerP;
using BitoDesktop.Data.Repositories.Finance;
using BitoDesktop.Data.Repositories.Hr;
using BitoDesktop.Data.Repositories.Pos;
using BitoDesktop.Data.Repositories.Sale;
using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Data.Repositories.WarehouseP;
using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Domain.Entities.Finance;
using BitoDesktop.Domain.Entities.Settings;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class SynchroniseService
    {
        private readonly CustomerRepository customerRepository;
        private readonly CurrencyRepository currencyRepository;
        private readonly InvoiceRepository invoiceRepository;
        private readonly TaxRepository taxRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly PosRepository posRepository;
        private readonly TicketRepository ticketRepository;
        private readonly DiscountRepostiory discountRepostiory;
        private readonly ReceiptRepository receiptRepository;
        private readonly CashbackSettingRepostiory cashbackSettingRepostiory;
        private readonly OrganizationRepository organizationRepository;
        private readonly PaymentMethodRepository paymentMethodRepository;
        private readonly PriceRepository priceRepository;
        private readonly PrinterRepostiory printerRepostiory;
        private readonly ReasonRepostiory reasonRepostiory;
        private readonly ScaleRepostiory scaleRepostiory;
        private readonly UnitMeasurementRepository unitMeasurementRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly ProductRepository productRepository;
        private readonly WarehouseRepository warehouseRepository;

        public SynchroniseService()
        {
            customerRepository = new CustomerRepository();
            currencyRepository = new CurrencyRepository();
            invoiceRepository = new InvoiceRepository();
            taxRepository = new TaxRepository();
            employeeRepository = new EmployeeRepository();
            taxRepository = new TaxRepository();
            posRepository = new PosRepository();
            ticketRepository = new TicketRepository();
            discountRepostiory = new DiscountRepostiory();
            receiptRepository = new ReceiptRepository();
            cashbackSettingRepostiory = new CashbackSettingRepostiory();
            organizationRepository = new OrganizationRepository();
            paymentMethodRepository = new PaymentMethodRepository();
            priceRepository = new PriceRepository();
            printerRepostiory = new PrinterRepostiory();
            reasonRepostiory = new ReasonRepostiory();
            scaleRepostiory = new ScaleRepostiory();
            categoryRepository = new CategoryRepository();
            productRepository = new ProductRepository();
            warehouseRepository = new WarehouseRepository();
        }


        public async Task<bool> SynchroniseToMachineCustomers()
        {
            var customerResponce = await CustomerApi.GetPage(new RequestPage());
            if (customerResponce.Message != "Success")
                throw new MarketException(customerResponce.Code, customerResponce.Message);

            var customers = customerResponce.Data;

            foreach (var customer in customers.PageData)
            {
                await customerRepository.Insert(customer.Get(),
                    customer.GetBalanceLists(),
                    customer.GetTotalBalances(),
                    customer.CashbackList.Select(c => c.Get()));
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineCurrency()
        {
            var currencyResponce = await CurrencyApi.GetAll();
            if (currencyResponce.Message != "Success")
                throw new MarketException(currencyResponce.Code, currencyResponce.Message);

            var currencies = currencyResponce.Data;

            foreach (var currency in currencies.PageData)
            {
                await currencyRepository.Insert(currency.Get());
            }

            return true;
        }
        
        public async Task<bool> SynchroniseToMachineInvoise()
        {
            var invoiseResponce = await InvoiseApi.GetAll();
            if (invoiseResponce.Message != "Success")
                throw new MarketException(invoiseResponce.Code, invoiseResponce.Message);

            var currencies = invoiseResponce.Data;

            foreach (var currency in currencies.PageData)
            {
                await currencyRepository.Insert(currency.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineTax()
        {
            var taxResponce = await TaxApi.GetAll();
            if (taxResponce.Message != "Success")
                throw new MarketException(taxResponce.Code, taxResponce.Message);

            var taxes = taxResponce.Data;

            foreach (var tax in taxes)
            {
                await taxRepository.Insert(tax.Get());
            }

            return true;
        }
        
        public async Task<bool> SynchroniseToMachineEmployee()
        {
            var employeeResponce = await EmployeeApi.GetPage(new RequestPage());
            if (employeeResponce.Message != "Success")
                throw new MarketException(employeeResponce.Code, employeeResponce.Message);

            var employees = employeeResponce.Data;

            foreach (var employee in employees.PageData)
            {
                await employeeRepository.Insert(employee.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachinePos()
        {
            var posResponce = await PosApi.GetPages();
            if (posResponce.Message != "Success")
                throw new MarketException(posResponce.Code, posResponce.Message);

            var poses = posResponce.Data;

            foreach (var pos in poses)
            {
                await posRepository.Insert(pos.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniceToMachineTicket()
        {
            var ticketResponce = await TicketApi.GetTables();
            if (ticketResponce.Message != "Success")
                throw new MarketException(ticketResponce.Code, ticketResponce.Message);

            var poses = ticketResponce.Data;

            foreach (var pos in poses)
            {
                await posRepository.Insert(pos.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineDicsount()
        {
            var discountResponce = await DiscountApi.GetAll();
            if (discountResponce.Message != "Success")
                throw new MarketException(discountResponce.Code, discountResponce.Message);

            var discounts = discountResponce.Data;

            foreach (var discount in discounts)
            {
                await discountRepostiory.Insert(discount.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineReceipt()
        {
            var receiptResponce = await ReceiptApi.GetPage(new RequestPage());
            if (receiptResponce.Message != "Success")
                throw new MarketException(receiptResponce.Code, receiptResponce.Message);

            var receipts = receiptResponce.Data;

            foreach (var receipt in receipts.PageData)
            {
                await receiptRepository.Insert(receipt.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineCashbackSettings()
        {
            var organizationResponce = await OrganizationApi.GetAll();
            if (organizationResponce.Message != "Success")
                throw new MarketException(organizationResponce.Code, organizationResponce.Message);

            var organizations = organizationResponce.Data;

            foreach (var organization in organizations)
            {
                await receiptRepository.Insert(organization.Get());
            }

            return true;
        }
        
        public async Task<bool> SynchroniseToMachineOrganization()
        {

            return true;
        }

        public Task<bool> SynchroniseToServer()
        {
            return Task.FromResult(true);
        }
    }
}
