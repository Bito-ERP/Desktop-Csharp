using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Interfaces;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.Login;
using BitoDesktop.WPF.Dialog;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private readonly IAuthService authService;

        private LoginController loginController;
        private DeviceChooserController deviceChooserController ;
        private ServerChooserController serverChooserController ;
        private OrganizatinController organizationController;
        PinCodeController pinCodeController;

        public LoginPage()
        {
            InitializeComponent();
            ci = new CultureInfo("uz-UZ");
            
            authService = new AuthService();
            
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
            foreach (var device in res.PageData)
            {
                DeviceController deviceController = new DeviceController();
                deviceController.DeviceNameTxt.Text = device.Name;
                deviceController.MouseDown += DeviceChoosen;
                deviceChooserController.DeviceItemsControl.Items.Add(deviceController);
            }
            LoginStageControl.Items.Add(deviceChooserController);
        }

        private async Task LoadServerChooser()
        {
            LoginStageControl.Items.Clear();
            var res = await authService.GetUsernames(loginController.PhoneNumberTxt.Text,loginController.PasswordTxt.Password);
            foreach (var server in res)
            {
                ServerController serverController = new ServerController();
                serverController.ServerNameTxt.Text = server.Username;
                serverController.MouseDown += DeviceChoosen;
                serverChooserController.ServerItemsControl.Items.Add(serverController);
            }
            LoginStageControl.Items.Add(serverChooserController);
        }

        private void DeviceChoosen(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("good");
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            RequestLogin request = new RequestLogin()
            {
                PhoneNumber = loginController.PhoneNumberTxt.Text,
                Password = loginController.PasswordTxt.Password,
            };
            try
            {
                var res = await authService.LoginAsync(request);

                Client.Token = res;

                
                await LoadServerChooser();
            }
            catch(MarketException ex) 
            {
                string message = JsonConvert.DeserializeObject<dynamic>(ex.Message).messages.uz;
                ErrorDialog dialog = new ErrorDialog(message);
                dialog.ShowDialog();   
            }
        }
    }
}
