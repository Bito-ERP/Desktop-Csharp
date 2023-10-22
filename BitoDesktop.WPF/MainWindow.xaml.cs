using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Pages;
using System.Threading.Tasks;
using System.Windows;

namespace BitoDesktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginPage loginPage;
        private PosPage posPage;
        private SideBarPage sidebarPage;
        private SynchroniseService synchroniseService;

        public MainWindow()
        {
            InitializeComponent();

            loginPage = new LoginPage();

            NavigateToLoginPage();

            sidebarPage = new SideBarPage();
            posPage = new PosPage();
        }

        private void SynchroniseBtnClick(object sender, RoutedEventArgs e)
        {
            Task task = new Task(async () =>
            {
                await synchroniseService.SynchroniseToMachineCashbackSettings();
                await synchroniseService.SynchroniseToMachineOrganization();
                await synchroniseService.SynchroniseToMachineReceipt();
                await synchroniseService.SynchroniseToMachineReason();
                await synchroniseService.SynchroniseToMachineScale();
                await synchroniseService.SynchroniseToMachineCategory();
                await synchroniseService.SynchroniseToMachineCurrency();
                await synchroniseService.SynchroniseToMachineCustomers();
                await synchroniseService.SynchroniseToMachineDicsount();
                await synchroniseService.SynchroniseToMachineTax();
                await synchroniseService.SynchroniseToMachineInvoise();
                await synchroniseService.SynchroniseToMachineEmployee();
                await synchroniseService.SynchroniseToMachinePos();
                await synchroniseService.SynchroniseToMachinePaymentMethod();
                await synchroniseService.SynchroniseToMachinePrice();
                await synchroniseService.SynchroniseToMachinePrinter();
                await synchroniseService.SynchroniseToMachineProduct();
                await synchroniseService.SynchroniseToMachineWarehouse();
            });
            task.Start();
        }

        public void NavigateToPosPage()
        {
            synchroniseService = new SynchroniseService(loginPage.OrganizationId);
            SideBarFrame.Content = sidebarPage;
            MainFrame.Content = posPage;
        }

        public void NavigateToLoginPage()
        {
            MainFrame.Content = loginPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sidebarPage.SynchroniseBtn.Click += SynchroniseBtnClick;
        }
    }
}
