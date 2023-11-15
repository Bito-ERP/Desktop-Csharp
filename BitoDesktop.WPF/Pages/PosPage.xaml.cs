using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Pos;
using BitoDesktop.WPF.Controllers.PosControllers;
using BitoDesktop.WPF.Pages.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BitoDesktop.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PosPage.xaml
    /// </summary>
    public partial class PosPage : System.Windows.Controls.Page
    {
        private int CurrentTicketId { get; set; }
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        private readonly PaymentMethodService paymentMethodService;
        private readonly TicketService ticketService;
        private readonly ConfigurationService configurationService;
        private readonly PosService posService;

        public PosPage()
        {
            InitializeComponent();
            productService = new ProductService();
            configurationService = new ConfigurationService();
            ticketService = new TicketService();
            customerService = new CustomerService();
            paymentMethodService = new PaymentMethodService();
            posService = new PosService();
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
                    productSearchController.Id = product.Id;
                    productSearchController.BarcodeTxt.Text = product.Barcode;
                    productSearchController.CapacityTxt.Text = product.WarehouseAmount.ToString();
                    productSearchController.PriceTxt.Text = product.SelectedPriceAmount.ToString();
                    productSearchController.MouseDown += AddToBasket;
                    ProductSearchItems.Items.Add(productSearchController);
                }
            }
            else
            {
                ProductSearchItems.Items.Clear();
            }
        }
        private async void AddToBasket(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as ProductSearchController);

            ProductController productController = new ProductController();
            productController.Id = product.Id;
            productController.ProductNameTxt.Text = product.NameTxt.Text;
            productController.PriceTxt.Text = product.PriceTxt.Text;
            productController.TotalPriceTxt.Text = product.PriceTxt.Text;
            productController.DeleteRequested += RequestDeleteFromBasket;
            productController.PriceToPayHandler += PriceToPayHadler;
            
            var ti = await ticketService.AddTicketItems(product.Id, CurrentTicketId, double.Parse(product.PriceTxt.Text), double.Parse(productController.NumberTxt.Text));
            productController.TicketItemId = ti;

            productController.AmountChangeRequest += AmountChanged;

            BasketControl.Items.Add(productController);
            PriceToPayHadler(productController, EventArgs.Empty);
            ProductSearchItems.Items.Clear();
        }

        private async void AmountChanged(object sender, EventArgs e)
        {
            var product = sender as ProductController;
            await ticketService.UpdateTicketItem(product.TicketItemId,
                product.Id, 
                CurrentTicketId,
                double.Parse(product.TotalPriceTxt.Text),
                double.Parse(product.NumberTxt.Text));
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

        private async void RequestDeleteFromBasket(object sender, EventArgs e)
        {
            var product = sender as ProductController;

            await ticketService.DeleteTicketItem(product.TicketItemId);



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

            var tickets = await ticketService.GetTickets();

            if (tickets.Count() > 0)
            {
                foreach (var ticket in tickets)
                {
                    PosPagesController posPagesController = new PosPagesController();
                    posPagesController.Id = ticket;
                    posPagesController.Margin = new Thickness(2);
                    
                    posPagesController.ChoosePageRequested += TicketChoseBtn_Click;
                    posPagesController.ClosePageRequested += TicketCloseBtn_Click;
                    TabsViewerPanel.Children.Add(posPagesController);
                }
                CurrentTicketId = tickets.First();
                var items = await ticketService.GetItems(CurrentTicketId);
                AddTicketItems(items);
            }
            else
            {
                await ticketService.AddNewTicket();

                var ticket = (await ticketService.GetTickets()).First();

                PosPagesController posPagesController = new PosPagesController();
                posPagesController.Margin = new Thickness(2);
                posPagesController.Id = ticket;
                posPagesController.ChoosePageRequested += TicketChoseBtn_Click;
                posPagesController.ClosePageRequested += TicketCloseBtn_Click;
                TabsViewerPanel.Children.Add(posPagesController);
            }
            AddTicketController addTicketController = new AddTicketController();
            addTicketController.Margin = new Thickness(2);
            addTicketController.AddTicketBtn.Click += AddTicketBtn_Click;
            TabsViewerPanel.Children.Add(addTicketController);
        }

        private void AddTicketItems(IEnumerable<TicketItem> items)
        {
            foreach (var item in items)
            {
                ProductController productController = new ProductController();
                productController.Id = item.ProductId;
                productController.TotalPriceTxt.Text = item.SelectedPriceAmount.ToString();
                productController.ProductNameTxt.Text = item.ProductName;
                productController.NumberTxt.Text = item.Amount.ToString();
                productController.TotalPriceTxt.Text = item.Price.ToString();
                productController.TicketItemId = item.Id;

                productController.DeleteRequested += RequestDeleteFromBasket;
                productController.PriceToPayHandler += PriceToPayHadler;
                productController.AmountChangeRequest += AmountChanged;
                BasketControl.Items.Add(productController);
            }
        }

        private async void TicketCloseBtn_Click(object sender, EventArgs e)
        {
            var ticket = sender as PosPagesController;
            if (ticket.Id == CurrentTicketId && TabsViewerPanel.Children[0] is PosPagesController)
            {
                CurrentTicketId = (TabsViewerPanel.Children[0] as PosPagesController).Id;
            }    
            await ticketService.Delete(ticket.Id);
            TabsViewerPanel.Children.Remove(ticket);
        }

        private void TicketChoseBtn_Click(object sender, EventArgs e)
        {
            CurrentTicketId = (sender as PosPagesController).Id;
        }

        private async void AddTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            TabsViewerPanel.Children.Clear();

            await ticketService.AddNewTicket();
            var tickets = await ticketService.GetTickets();

            foreach (var ticket in tickets)
            {
                PosPagesController posPagesController = new PosPagesController();
                posPagesController.Id = ticket;
                posPagesController.Margin = new Thickness(2);

                posPagesController.ChoosePageRequested += TicketChoseBtn_Click;
                posPagesController.ClosePageRequested += TicketCloseBtn_Click;
                TabsViewerPanel.Children.Add(posPagesController);
            }

            AddTicketController addTicketController = new AddTicketController();
            addTicketController.AddTicketBtn.Click += AddTicketBtn_Click;
            addTicketController.Margin = new Thickness(2);
            TabsViewerPanel.Children.Add(addTicketController);
        }

        private void ChoosenPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if (BasketControl.Items.Count > 0)
            {
                decimal totalPriceLeft = 0;
                foreach (var item in ChoosenPaymentMethodsControl.Items)
                {
                    var paymentMethod = item as PaymentMethodAmount;
                    totalPriceLeft += decimal.Parse(paymentMethod.PriceTxt.Text);
                }

                totalPriceLeft = decimal.Parse(TotalPriceToPayTxt.Text) - totalPriceLeft;
                if (totalPriceLeft > 0)
                {
                    NumberPadPage numberPadPage = new NumberPadPage();
                    numberPadPage.PayMentType = ((sender as Button).Content as TextBlock).Text;
                    numberPadPage.HandleSaveAndCloseBtn += SaveAndClosePaymentClick;
                    MainFrame.Content = numberPadPage;

                    numberPadPage.PriceTxt.Text = totalPriceLeft.ToString();
                    ActualPriceToPayTxt.Text = totalPriceLeft.ToString();
                }
                else
                {
                    throw new MarketException(400, "Price is full");
                }
            }
        }

        private void SaveAndClosePaymentClick(object sender, EventArgs e)
        {
            string type = (sender as NumberPadPage).PayMentType;
            string price = (sender as NumberPadPage).PriceTxt.Text;

            PaymentMethodAmount paymentMethodAmount = new PaymentMethodAmount();
            paymentMethodAmount.PaymentTypeTxt.Text = type;
            paymentMethodAmount.PriceTxt.Text = price;
            paymentMethodAmount.EditRequested += PMAEdit_Click;
            paymentMethodAmount.DeleteRequested += PMADelete_Click;
            ChoosenPaymentMethodsControl.Items.Add(paymentMethodAmount);
            MainFrame.Content = null;
        }

        private void PMADelete_Click(object sender, EventArgs e)
        {
            var payment = sender as PaymentMethodAmount;
            ChoosenPaymentMethodsControl.Items.Remove(payment);
        }

        private void PMAEdit_Click(object sender, EventArgs e)
        {
            var method = (sender as PaymentMethodAmount);

            NumberPadPage numberPadPage = new NumberPadPage();
            numberPadPage.PayMentType = method.PaymentTypeTxt.Text;
            numberPadPage.HandleSaveAndCloseBtn += SaveAndClosePaymentClick;
            MainFrame.Content = numberPadPage;

            numberPadPage.PriceTxt.Text = method.PriceTxt.Text;
            ChoosenPaymentMethodsControl.Items.Remove(method);
        }

        private void WarehouseLb_Selected(object sender, RoutedEventArgs e)
        {
            WarehousePage warehousePage = new WarehousePage();
            warehousePage.WarehouseChangeRequest += WarehouseChanged;
            MainFrame.Content = warehousePage;
        }

        private async void WarehouseChanged(object sender, EventArgs e)
        {
            var warehouseid = ((sender as Grid).Children[1] as TextBlock).Text;
            await configurationService.SaveCustomConfig("warehouse", warehouseid);
            MainFrame.Content = null;
        }

        private void PriceLb_Selected(object sender, RoutedEventArgs e)
        {
            PriceSelectPage priceSelectPage = new PriceSelectPage();
            priceSelectPage.PriceChangeReuest += PriceChanged;
            MainFrame.Content = priceSelectPage;
        }

        private async void PriceChanged(object sender, EventArgs e)
        {
            var priceId = ((sender as Grid).Children[1] as TextBlock).Text;
            await configurationService.SaveCustomConfig("price", priceId);
            MainFrame.Content = null;
        }
    }
}