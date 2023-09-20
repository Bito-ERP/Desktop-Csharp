using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BitoDesktop.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly DispatcherTimer _timer;
        private readonly string dateTimeFormat = "dd MMMM yyyy\nHH:mm:ss";
        private readonly CultureInfo ci;
        public LoginPage()
        {
            InitializeComponent();
            ci = new CultureInfo("uz-UZ");
            _timer = new DispatcherTimer();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTxt.Text = DateTime.Now.ToString(dateTimeFormat, ci);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DateTimeTxt.Text = DateTime.Now.ToString(dateTimeFormat, ci);

            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
        }

    }
}
