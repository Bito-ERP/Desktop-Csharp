using BitoDesktop.Service.Services;
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
        private PosPage posPage;
        private LoginPage loginPage;
        public MainWindow()
        {
            InitializeComponent();
            loginPage = new LoginPage();
            posPage = new PosPage();
            NavigateToLoginPage();
        }

        public async void NavigateToPosPage()
        {
            MainFrame.Content = posPage;
            SynchroniseService synchroniseService = new SynchroniseService();
            await synchroniseService.SynchroniseToMachineCustomers();
        }

        public void NavigateToLoginPage() 
        {
            MainFrame.Content = loginPage;
        }
    }
}