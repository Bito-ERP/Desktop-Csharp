using BitoDesktop.WPF.Pages;
using BitoDesktop.WPF.Pages.Catalogs;
using System;
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
            PosPage loginPage = new PosPage();
            MainFrame.Content = loginPage;
        }

        public void NavigateToPosPage()
        {
            MainFrame.Content = new PosPage();
        }
    }
}
