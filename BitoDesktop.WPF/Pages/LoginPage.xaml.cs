using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Hr;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Interfaces;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Login;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BitoDesktop.WPF.Pages
{
    public partial class LoginPage : Page
    {
        private readonly DispatcherTimer _timer;
        private readonly string dateTimeFormat = "dd MMMM yyyy\nHH:mm:ss";
        private readonly CultureInfo ci;

        private readonly IAuthService authService;
        private readonly ConfigurationService configurationService;

        private LoginController loginController;
        private DeviceChooserController deviceChooserController;
        private ServerChooserController serverChooserController;
        private OrganizatinController organizationController;
        private PinCodeController pinCodeController;
        public string OrganizationId { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            ci = new CultureInfo("uz-UZ");

            authService = new AuthService();

            configurationService = new ConfigurationService();
            loginController = new LoginController();
            deviceChooserController = new DeviceChooserController();
            serverChooserController = new ServerChooserController();
            organizationController = new OrganizatinController();
            pinCodeController = new PinCodeController();

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
            LoadLogin();
        }

        private void LoadLogin()
        {
            loginController.LoginBtn.Click += Login;
            LoginStageControl.Items.Add(loginController);
        }

        private async Task LoadDeviceChooser()
        {
            LoginStageControl.Items.Clear();
            var res = await authService.GetDevices(loginController.PhoneNumberTxt.Text);
            if (res.PageData != null)
            {
                foreach (var device in res.PageData)
                {
                    DeviceController deviceController = new DeviceController();
                    deviceController.DeviceId = device.Id;
                    deviceController.DeviceNameTxt.Text = device.Name;
                    deviceController.MouseDown += DeviceChoosen;
                    deviceChooserController.DeviceItemsControl.Items.Add(deviceController);
                }
            }
            LoginStageControl.Items.Add(deviceChooserController);
        }

        private async Task LoadServerChooser()
        {
            LoginStageControl.Items.Clear();
            var res = await authService.GetUsernames(loginController.PhoneNumberTxt.Text, loginController.PasswordTxt.Password);
            foreach (var server in res)
            {
                ServerController serverController = new ServerController();
                serverController.ServerNameTxt.Text = server.Username;
                serverController.MouseDown += ServerChoosen;
                serverChooserController.ServerItemsControl.Items.Add(serverController);
            }
            LoginStageControl.Items.Add(serverChooserController);
        }

        private async void ServerChoosen(object sender, MouseButtonEventArgs e)
        {
            var serverName = (sender as ServerController).ServerNameTxt.Text;
            Client.Username = serverName;

            await LoadDeviceChooser();
        }

        private async void DeviceChoosen(object sender, MouseButtonEventArgs e)
        {
            var deviceId = (sender as DeviceController).DeviceId;
            Client.DeviceId = deviceId;
            await LoadOrganization(); 
        }


        private async Task LoadOrganization()
        {
            var organizations = await authService.GetOrganizations();
            var warhouses = await authService.GetWareHouses();
            var prices = await authService.GetPrices();

            LoginStageControl.Items.Clear();

            foreach (var organization in organizations)
            {
                Grid grid = new Grid();

                TextBlock idTxt = new TextBlock();
                idTxt.Text = organization.Id;
                idTxt.Foreground = new SolidColorBrush(Colors.White);

                TextBlock nameTxt = new TextBlock();
                nameTxt.Text = organization.Name;
                nameTxt.Foreground = new SolidColorBrush(Colors.Black);

                grid.Children.Add(idTxt);
                grid.Children.Add(nameTxt);

                organizationController.OrgCmb.Items.Add(grid);
            }

            foreach (var warehouse in warhouses.PageData)
            {
                Grid grid = new Grid();

                TextBlock idTxt = new TextBlock();
                idTxt.Text = warehouse.Id;
                idTxt.Foreground = new SolidColorBrush(Colors.White);

                TextBlock nameTxt = new TextBlock();
                nameTxt.Text = warehouse.Name;
                nameTxt.Foreground = new SolidColorBrush(Colors.Black);

                grid.Children.Add(idTxt);
                grid.Children.Add(nameTxt);

                organizationController.WarehouseCmb.Items.Add(grid);
            }

            foreach (var price in prices)
            {
                Grid grid = new Grid();

                TextBlock idTxt = new TextBlock();
                idTxt.Text = price.Id;
                idTxt.Foreground = new SolidColorBrush(Colors.White);

                TextBlock nameTxt = new TextBlock();
                nameTxt.Text = price.Name;
                nameTxt.Foreground = new SolidColorBrush(Colors.Black);

                grid.Children.Add(idTxt);
                grid.Children.Add(nameTxt);

                organizationController.PriceCmb.Items.Add(grid);
            }
            LoginStageControl.Items.Add(organizationController);

            organizationController.OrgCmb.SelectionChanged += CheckIfAllSelected;
            organizationController.PriceCmb.SelectionChanged += CheckIfAllSelected;
            organizationController.WarehouseCmb.SelectionChanged += CheckIfAllSelected;

        }

        private void CheckIfAllSelected(object sender, SelectionChangedEventArgs e)
        {
            if (organizationController.OrgCmb.SelectedItem != null &&
                organizationController.PriceCmb.SelectedItem != null &&
                organizationController.WarehouseCmb.SelectedItem != null)
            {
                OrganizationId = ((organizationController.OrgCmb.SelectedItem as Grid).Children[0] as TextBlock).Text;
                var warehouseId = ((organizationController.WarehouseCmb.SelectedItem as Grid).Children[0] as TextBlock).Text;
                var priceId = ((organizationController.PriceCmb.SelectedItem as Grid).Children[0] as TextBlock).Text;

                Client.OrganizationId = OrganizationId;

                var res = configurationService.SaveConfigs(priceId, warehouseId,OrganizationId);

                LoginStageControl.Items.Clear();
                pinCodeController.OkBtn.Click += PincodeOkBtnClick;
                LoginStageControl.Items.Add(pinCodeController);
            }
        }

        private async void PincodeOkBtnClick(object sender, RoutedEventArgs e)
        {
            var res = await authService.EnterByPinCode(pinCodeController.PinCodeTxt.Password);

            Client.UserId = res.Id;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
                mainWindow.NavigateToPosPage();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            RequestLogin request = new RequestLogin()
            {
                PhoneNumber = loginController.PhoneNumberTxt.Text,
                Password = loginController.PasswordTxt.Password,
            };
            var res = await authService.LoginAsync(request);

            Client.Token = res;

            await LoadServerChooser();
        }
    }
}