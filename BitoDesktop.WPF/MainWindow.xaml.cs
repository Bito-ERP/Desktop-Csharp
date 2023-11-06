using BitoDesktop.Data.IRepositories;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Login;
using BitoDesktop.WPF.Dialog;
using BitoDesktop.WPF.Pages;
using BitoDesktop.WPF.Pages.Pos;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
        private readonly ConfigurationService configurationService;
        private readonly EmployeeService employeeService;

        private PinCodeController pinCodeController;

        public MainWindow()
        {
            InitializeComponent();

            employeeService = new EmployeeService();
            configurationService = new ConfigurationService();
            sidebarPage = new SideBarPage();
            posPage = new PosPage();
        }

        private async void SynchroniseBtnClick(object sender, RoutedEventArgs e)
        {

            var methods = new Func<Task>[]
            {
                synchroniseService.SynchroniseToMachineCashbackSettings,
                synchroniseService.SynchroniseToMachineOrganization,
                synchroniseService.SynchroniseToMachineReceipt,
                synchroniseService.SynchroniseToMachineReason,
                synchroniseService.SynchroniseToMachineScale,
                synchroniseService.SynchroniseToMachineCategory,
                synchroniseService.SynchroniseToMachineCurrency,
                synchroniseService.SynchroniseToMachineCustomers,
                synchroniseService.SynchroniseToMachineDicsount,
                synchroniseService.SynchroniseToMachineTax,
                synchroniseService.SynchroniseToMachineInvoise,
                synchroniseService.SynchroniseToMachineEmployee,
                synchroniseService.SynchroniseToMachinePos,
                synchroniseService.SynchroniseToMachinePaymentMethod,
                synchroniseService.SynchroniseToMachinePrice,
                synchroniseService.SynchroniseToMachineProduct,
                synchroniseService.SynchroniseToMachineWarehouse,
            };

            Client.CheckForInternetConnection();
            SynchroniseProgress synchroniseProgress = new SynchroniseProgress();
            OtherPagesFrame.Content = synchroniseProgress;
            
            

            foreach (var method in methods)
            {
                var animation = new DoubleAnimation
                {
                    To = synchroniseProgress.SynchPb.Value + 1,
                    Duration = TimeSpan.FromMilliseconds(100) // You can adjust the duration
                };
                animation.To = synchroniseProgress.SynchPb.Value + 1;
                await method();

                synchroniseProgress.SynchPb.BeginAnimation(ProgressBar.ValueProperty, animation);
                await Task.Delay(100);
            }

            await Task.Delay(400);

            OtherPagesFrame.Content = null;
            new SuccessSynch().ShowDialog();
        }

        public void NavigateToPosPage()
        {
            synchroniseService = new SynchroniseService(Client.OrganizationId);
            SideBarFrame.Content = sidebarPage;
            MainFrame.Content = posPage;
        }

        public void NavigateToLoginPage()
        {
            MainFrame.Content = loginPage;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sidebarPage.SynchroniseBtn.Click += SynchroniseBtnClick;
            if (await configurationService.IsDataExist())
            {
                pinCodeController = new PinCodeController();
                pinCodeController.OkBtn.Click += PincodeOkBtnClick;

                MainFrame.Content = pinCodeController;
            }
            
            else
            {
                if (Client.CheckForInternetConnection())
                {
                    loginPage = new LoginPage();

                    NavigateToLoginPage();
                }
                else
                {
                    ErrorDialog errorDialog = new ErrorDialog("Iltimos Internetga ulaning");
                    errorDialog.ShowDialog();
                }
            }
        }

        private async void PincodeOkBtnClick(object sender, RoutedEventArgs e)
        {
            await employeeService.CheckPinCode(pinCodeController.PinCodeTxt.Password);

            Client.OrganizationId = await configurationService.Get("organization");
            Client.PriceId = await configurationService.Get("price");
            Client.WarehouseId = await configurationService.Get("warehouse");
            Client.DeviceId = await configurationService.Get("device");
            Client.ServerId = await configurationService.Get("server");
            Client.Token = await configurationService.Get("token");
            Client.UserId = await configurationService.Get("employee");

            NavigateToPosPage();
        }
    }
}