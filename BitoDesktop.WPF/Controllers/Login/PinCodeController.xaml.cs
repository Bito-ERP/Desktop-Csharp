using System.Windows.Controls;

namespace BitoDesktop.WPF.Controllers.Login
{
    /// <summary>
    /// Логика взаимодействия для PinCodeController.xaml
    /// </summary>
    public partial class PinCodeController : UserControl
    {
        public PinCodeController()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var buttonContent = ((Button)sender).Content.ToString();
            PinCodeTxt.Password += buttonContent;
        }
    }
}
