using BitoDesktop.Data.Repositories.CustomerP;
using BitoDesktop.Data.Repositories.Finance;
using BitoDesktop.Data.Repositories.Hr;
using BitoDesktop.Data.Repositories.Pos;
using BitoDesktop.Data.Repositories.Sale;
using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Data.Repositories.WarehouseP;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Sale;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Http.Warehouse;
using System.Linq;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class SynchroniseService
    {
        #region fields
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
        #endregion

        public string OrganizationId { get; set; }
        public SynchroniseService(string organizationId)
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
            OrganizationId = organizationId;
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
            var invoiseResponce = await InvoiceApi.GetPage(new RequestPage());
            if (invoiseResponce.Message != "Success")
                throw new MarketException(invoiseResponce.Code, invoiseResponce.Message);

            var invoices = invoiseResponce.Data;

            foreach (var invoice in invoices.PageData)
            {
                await invoiceRepository.Insert(invoice.Get(OrganizationId));
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineTax()
        {
            var taxResponce = await TaxApi.GetAll();
            if (taxResponce.Message != "Success")
                throw new MarketException(taxResponce.Code, taxResponce.Message);

            var taxes = taxResponce.Data;

            await taxRepository.Insert(taxes.Select(t => t.GetEntityTax()));


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

        //public async Task<bool> SynchroniceToMachineTicket()
        //{
        //    var ticketResponce = await TicketApi.GetTables();
        //    if (ticketResponce.Message != "Success")
        //        throw new MarketException(ticketResponce.Code, ticketResponce.Message);

        //    var poses = ticketResponce.Data;

        //    foreach (var pos in poses)
        //    {
        //        await ticketRepository.Insert(pos.Get());
        //    }

        //    return true;
        //}

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

            PagingResponse<ReceiptResponse> receiptResponces = receiptResponce.Data;

            var receipts = receiptResponces.PageData.Select(receipt => receipt.Get(OrganizationId));
            var payments = receiptResponces.PageData.SelectMany(receipt => receipt.Payments);
            var installemtns = receiptResponces.PageData.SelectMany(receipt => receipt.InstallmentPlans);
            await receiptRepository.Insert(receipts, null, null, null, null, null);

            return true;
        }

        public async Task<bool> SynchroniseToMachineCashbackSettings()
        {
            var cashbackResponce = await SettingApi.GetCashbackSettings();
            if (cashbackResponce.Message != "Success")
                throw new MarketException(cashbackResponce.Code, cashbackResponce.Message);

            var cashback = cashbackResponce.Data;

            foreach (var receipt in cashback)
            {
                await cashbackSettingRepostiory.Insert(receipt.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineOrganization()
        {
            var organizationResponce = await OrganizationApi.GetAll();
            if (organizationResponce.Message != "Success")
                throw new MarketException(organizationResponce.Code, organizationResponce.Message);

            var organizations = organizationResponce.Data;

            foreach (var organization in organizations)
            {
                await organizationRepository.Insert(organization.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachinePaymentMethod()
        {
            var paymentMethodResponce = await PaymentMethodApi.GetAll();
            if (paymentMethodResponce.Message != "Success")
                throw new MarketException(paymentMethodResponce.Code, paymentMethodResponce.Message);

            var paymentMethods = paymentMethodResponce.Data;

            foreach (var method in paymentMethods.PageData)
            {
                await paymentMethodRepository.Insert(method.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachinePrice()
        {
            var priceResponce = await PriceApi.GetAll();
            if (priceResponce.Message != "Success")
                throw new MarketException(priceResponce.Code, priceResponce.Message);

            var prices = priceResponce.Data;

            foreach (var price in prices)
            {
                await priceRepository.Insert(price.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachinePrinter()
        {
            var printerResponce = await PrinterApi.GetAll();
            if (printerResponce.Message != "Success")
                throw new MarketException(printerResponce.Code, printerResponce.Message);

            var printers = printerResponce.Data;

            foreach (var printer in printers.PageData)
            {
                await printerRepostiory.Insert(printer.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineReason()
        {
            var reasonResponse = await ReasonApi.GetPage(new RequestPage());
            if (reasonResponse.Message != "Success")
                throw new MarketException(reasonResponse.Code, reasonResponse.Message);

            var reasons = reasonResponse.Data;

            foreach (var reason in reasons.PageData)
            {
                await reasonRepostiory.Insert(reason.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineScale()
        {
            var scaleResponse = await SettingApi.GetScales();
            if (scaleResponse.Message != "Success")
                throw new MarketException(scaleResponse.Code, scaleResponse.Message);

            var scales = scaleResponse.Data;

            foreach (var scale in scales)
            {
                await scaleRepostiory.Insert(scale.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineCategory()
        {
            var categoryResponse = await CategoryApi.GetPage(new RequestPage());
            if (categoryResponse.Message != "Success")
                throw new MarketException(categoryResponse.Code, categoryResponse.Message);

            var categories = categoryResponse.Data;

            foreach (var category in categories.PageData)
            {
                await categoryRepository.Insert(category.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineProduct()
        {
            var productResponce = await ProductApi.GetPage(new RequestPage());
            if (productResponce.Message != "Success")
                throw new MarketException(productResponce.Code, productResponce.Message);

            var products = productResponce.Data;

            foreach (var product in products.PageData)
            {
                await productRepository.Insert(product.Get());
            }

            return true;
        }

        public async Task<bool> SynchroniseToMachineWarehouse()
        {
            var warehouseResponce = await WarehouseApi.GetPage(new RequestPage());
            if (warehouseResponce.Message != "Success")
                throw new MarketException(warehouseResponce.Code, warehouseResponce.Message);

            var warehouses = warehouseResponce.Data;

            foreach (var warehouse in warehouses.PageData)
            {
                await warehouseRepository.Insert(warehouse.Get());
            }

            return true;
        }
    }
}
