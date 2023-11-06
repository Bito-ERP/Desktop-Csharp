using System;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Controllers.PosControllers
{
    /// <summary>
    /// Логика взаимодействия для ProductController.xaml
    /// </summary>

    public partial class ProductController : UserControl
    {
        public event EventHandler DeleteRequested;
        public event EventHandler PriceToPayHandler;

        public ProductController()
        {
            InitializeComponent();
        }

        private void MinusBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (NumberTxt.Text != "1")
            {
                NumberTxt.Text = (int.Parse(NumberTxt.Text) - 1).ToString();
                PriceToPayHandler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void PlusBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NumberTxt.Text = (int.Parse(NumberTxt.Text) + 1).ToString();
            PriceToPayHandler?.Invoke(this, EventArgs.Empty);
        }

        private void NumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceTxt != null && NumberTxt != null && !string.IsNullOrEmpty(NumberTxt.Text))
            {
                TotalPriceTxt.Text = $"{int.Parse(NumberTxt.Text) * int.Parse(PriceTxt.Text)}";
                PriceToPayHandler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteRequested?.Invoke(this,EventArgs.Empty);
            PriceToPayHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
