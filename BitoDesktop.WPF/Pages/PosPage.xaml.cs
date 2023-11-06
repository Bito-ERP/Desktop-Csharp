using BitoDesktop.Domain.Entities.CustomerP;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Pos;
using BitoDesktop.WPF.Controllers.PosControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BitoDesktop.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PosPage.xaml
    /// </summary>
    public partial class PosPage : Page
    {
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        private readonly PaymentMethodService paymentMethodService;
        private readonly ConfigurationService configurationService;

        public PosPage()
        {   
            InitializeComponent();
            productService = new ProductService();
            configurationService = new ConfigurationService();
            customerService = new CustomerService();
            paymentMethodService = new PaymentMethodService();
        }

        private async void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchProduct.Text))
            {
                ProductSearchItems.Items.Clear();
                var warehouseId = await configurationService.Get("warehouse");
                var priceId = await configurationService.Get("price");
                var organizationId = await configurationService.Get("organization");

                var products = await productService.GetProducts(SearchProduct.Text, organizationId, warehouseId, priceId);

                foreach (var product in products)
                {
                    ProductSearchController productSearchController = new ProductSearchController();
                    productSearchController.NameTxt.Text = product.Name;
                    productSearchController.BarcodeTxt.Text = product.Barcode;
                    productSearchController.CapacityTxt.Text = product.WarehouseAmount.ToString();
                    productSearchController.PriceTxt.Text  = product.SelectedPriceAmount.ToString();
                    productSearchController.MouseDown += AddToBasket;
                    ProductSearchItems.Items.Add(productSearchController);
                }
            }
            else
            {
                ProductSearchItems.Items.Clear();
            }
        }
        private void AddToBasket(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as ProductSearchController);

            ProductController productController = new ProductController();
            productController.ProductNameTxt.Text = product.NameTxt.Text;
            productController.PriceTxt.Text = product.PriceTxt.Text;
            productController.TotalPriceTxt.Text = product.PriceTxt.Text;
            productController.DeleteRequested += RequestDeleteFromBasket;
            productController.PriceToPayHandler += PriceToPayHadler;
            BasketControl.Items.Add(productController);
            PriceToPayHadler(productController, EventArgs.Empty);
        }

        private void PriceToPayHadler(object sender, EventArgs e)
        {
            decimal totalPrice = 0;
            foreach (var item in BasketControl.Items)
            {
                var product = item as ProductController;
                totalPrice += decimal.Parse(product.TotalPriceTxt.Text);
            }
            TotalPriceToPayTxt.Text = totalPrice.ToString();
        }

        private void RequestDeleteFromBasket(object sender, EventArgs e)
        {
            var product = sender as ProductController;
            BasketControl.Items.Remove(product);
        }

        private void SearchCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchCustomer.Text))
            {
                SearchItems.Items.Clear();

                string query = SearchCustomer.Text.ToLower();

                var thread = new Task(async () =>
                {
                    var customers = await customerService.GetCustomers(Client.OrganizationId, query);

                    foreach (var customer in customers)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            CustomerSearchItemController customerController = new CustomerSearchItemController();
                            customerController.CustomerNaeTxt.Text = customer.Name;
                            customerController.CustomerPhoneNumber.Text = customer.PhoneNumber;
                            SearchItems.Items.Add(customerController);
                        });
                    }
                });
                thread.Start();
            }
            else
            {
                SearchItems.Items.Clear();
            }
        }

        private void SearchCustomer_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SearchItems.Items.Clear();
        }

        private void ClearBasketBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BasketControl.Items.Clear();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var methods = await paymentMethodService.GetAll();

            foreach (var method in methods)
            {
                if (method.IsEnabled)
                {
                    PaymentMethodController paymentMethodController = new PaymentMethodController();
                    paymentMethodController.MethodNameTxt.Text = method.Name;
                    paymentMethodController.Margin = new Thickness(3);
                    paymentMethodController.PaymentMethodBtn.Click += ChoosenPaymentMethod_Click;
                    PaymentMethodPanel.Children.Add(paymentMethodController);
                }
            }
        }

        private void ChoosenPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if (BasketControl.Items.Count > 0)
            {
                string type = ((sender as Button).Content as TextBlock).Text;

                PaymentMethodAmount paymentMethodAmount = new PaymentMethodAmount();
                paymentMethodAmount.PaymentTypeTxt.Text = type;
                paymentMethodAmount.PriceTxt.Text = TotalPriceToPayTxt.Text;
                ChoosenPaymentMethodsControl.Items.Add(paymentMethodAmount);
            }
        }
    }
}
