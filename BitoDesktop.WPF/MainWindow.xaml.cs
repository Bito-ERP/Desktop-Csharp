using BitoDesktop.WPF.Pages;
using BitoDesktop.WPF.Pages.Baskets;
using BitoDesktop.WPF.Pages.Catalogs;
using BitoDesktop.WPF.Pages.Pos;
using BitoDesktop.WPF.Pages.Products;
using BitoDesktop.WPF.Pages.Settings;
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
            WarehousePage posPage = new WarehousePage();
            MainFrame.Content = posPage;
        }
    }
}
