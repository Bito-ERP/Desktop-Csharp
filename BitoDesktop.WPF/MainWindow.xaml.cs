using BitoDesktop.WPF.Pages;
<<<<<<< HEAD
=======
using BitoDesktop.WPF.Pages.Baskets;
>>>>>>> 7d842f5303d3a1a71c27ff5cad4eb13605b367f8
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
            PosPage posPage = new PosPage();
            MainFrame.Content = posPage;
            MainFrame2.Content = new CatalogPage();
        }
    }
}
