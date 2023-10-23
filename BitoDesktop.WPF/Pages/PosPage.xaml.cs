using BitoDesktop.Service.Http;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Pos;
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
        public PosPage()
        {
            InitializeComponent();
            productService = new ProductService();
            customerService = new CustomerService();
        }

        private async void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var products = await productService.GetProducts(SearchProduct.Text,Client.DeviceId,);
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
