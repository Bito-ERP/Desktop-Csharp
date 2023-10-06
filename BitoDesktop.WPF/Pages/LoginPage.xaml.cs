using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.Exceptions;
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
        private OrganizatinController organizationController;
        PinCodeController pinCodeController;

        public LoginPage()
        {
            InitializeComponent();
            ci = new CultureInfo("uz-UZ");
            
            authService = new AuthService();
            
            loginController = new LoginController();
            deviceChooserController = new DeviceChooserController();
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

        private async void LoadDeviceChooser()
        {
            LoginStageControl.Items.Clear();
            var res = await authService.GetDevices(loginController.PhoneNumberTxt.Text);
            foreach (var device in res.PageData)
            {
                DeviceController deviceController = new DeviceController();
                deviceController.DeviceNameTxt.Text = device.Name;
                deviceChooserController.DeviceItemsControl.Items.Add(deviceController);
            }
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            RequestLogin request = new RequestLogin()
            {
                PhoneNumber = loginController.PhoneNumberTxt.Text,
                Password = loginController.PasswordTxt.Password,
                Brand = loginController.ServerNameTxt.Text
            };
            try
            {
                await authService.LoginAsync(request);

                LoadDeviceChooser();
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
