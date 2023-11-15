using BitoDesktop.Service.Services;
using System;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Pages.Pos
{
    /// <summary>
    /// Interaction logic for PriceSelectPage.xaml
    /// </summary>
    public partial class PriceSelectPage : Page
    {
        private readonly PriceService priceService;
        public event EventHandler PriceChangeReuest;
        public PriceSelectPage()
        {
            InitializeComponent();
            priceService = new PriceService();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var prices = await priceService.GetAll();

            foreach (var price in prices)
            {
                Grid grid = new Grid();

                grid.Children.Add(new TextBlock() { Text = price.Name });
                grid.Children.Add(new TextBlock() { Text = price.Id, Opacity = 0 });

                PriceCb.Items.Add(grid);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PriceChangeReuest?.Invoke(PriceCb.SelectedItem, new EventArgs());
        }
    }
}
