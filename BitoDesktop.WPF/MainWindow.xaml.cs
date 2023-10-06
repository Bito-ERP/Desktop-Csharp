using BitoDesktop.WPF.Pages;
using BitoDesktop.WPF.Pages.Catalogs;
using System.Windows;

namespace BitoDesktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginPage loginPage = new LoginPage();
            MainFrame.Content = loginPage;
        }
    }
}
