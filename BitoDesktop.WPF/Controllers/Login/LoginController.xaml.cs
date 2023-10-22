using BitoDesktop.Service.Interfaces;
using BitoDesktop.Service.Services;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Controllers.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginController.xaml
    /// </summary>
    public partial class LoginController : UserControl
    {
        private readonly IAuthService authService;
        public LoginController()
        {
            InitializeComponent();
            authService = new AuthService();
        }
    }
}
