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
            var settings = new PosPage();
            MainFrame.Content = settings;
            PosPage posPage = new PosPage();
            MainFrame.Content = posPage;
            MainFrame2.Content = new CatalogPage();
        }
    }
}
