using System;
using System.Windows;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Controllers.Pos
{
    /// <summary>
    /// Логика взаимодействия для PaymnetMethodAmount.xaml
    /// </summary>
    public partial class PaymentMethodAmount : UserControl
    {
        public event EventHandler DeleteRequested;
        public event EventHandler EditRequested;
        public PaymentMethodAmount()
        {
            InitializeComponent();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
