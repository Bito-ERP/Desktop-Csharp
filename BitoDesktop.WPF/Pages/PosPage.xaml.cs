using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Pos;
using System.Linq;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PosPage.xaml
    /// </summary>
    public partial class PosPage : Page
    {
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        private readonly ConfigurationService configurationService;
        public PosPage()
        {   
            InitializeComponent();
            productService = new ProductService();
            configurationService = new ConfigurationService();
            customerService = new CustomerService();
        }

        private async void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchProduct.Text))
            {
                ProductSearchItems.Items.Clear();
                var warehouseId = await configurationService.GetWarehouse();
                var priceId = await configurationService.GetPrice();
                var organizationId = await configurationService.GetOrganization();

                var products = await productService.GetProducts(SearchProduct.Text, organizationId, warehouseId, priceId);

                foreach (var product in products)
                {
                    ProductSearchController productSearchController = new ProductSearchController();
                    productSearchController.NameTxt.Text = product.Name;
                    productSearchController.BarcodeTxt.Text = product.Barcode;
                    productSearchController.CapacityTxt.Text = product.WarehouseAmount.ToString();
                    ProductSearchItems.Items.Add(productSearchController);
                }
            }
            else 
            {
                ProductSearchItems.Items.Clear();
            }
        }

        private async void SearchCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchItems.Items.Clear();
            var customers = await customerService.GetCustomers(Client.OrganizationId,SearchCustomer.Text);

            foreach (var customer in customers) 
            {
                CustomerSearchItemController customerController = new CustomerSearchItemController();
                customerController.CustomerNaeTxt.Text = customer.Name;
                customerController.CustomerPhoneNumber.Text = customer.PhoneNumber;
                SearchItems.Items.Add(customerController);
            }
        }

        private void SearchCustomer_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SearchItems.Items.Clear();
        }
    }
}
