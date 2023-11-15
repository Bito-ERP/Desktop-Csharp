using BitoDesktop.Service.Services;
using System;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Pages.Pos
{
    /// <summary>
    /// Логика взаимодействия для NumberPadPage.xaml
    /// </summary>
    public partial class NumberPadPage : Page
    {
        public string PayMentType { get; set; }
        public event EventHandler HandleSaveAndCloseBtn;
        private readonly CurrencyService currencyService;
        public NumberPadPage()
        {
            currencyService = new CurrencyService();
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var buttonContent = ((Button)sender).Content.ToString();
            PriceTxt.Text += buttonContent;
        }

        private void ClearBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PriceTxt.Text = string.Empty;
        }

        private void BackspaseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PriceTxt.Text))
                PriceTxt.Text = PriceTxt.Text.Remove(PriceTxt.Text.Length - 1);
        }

        private void SaveAndCloseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HandleSaveAndCloseBtn?.Invoke(this, EventArgs.Empty);
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var currencies = await currencyService.GetAll();
            foreach (var currency in currencies)
            {
                CurrenciesCb.Items.Add(currency.Symbol);
            }
        }
    }
}
