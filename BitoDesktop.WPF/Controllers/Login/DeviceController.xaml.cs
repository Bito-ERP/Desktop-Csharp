using System.Windows.Controls;

namespace BitoDesktop.WPF.Controllers.Login
{
    /// <summary>
    /// Логика взаимодействия для DeviceController.xaml
    /// </summary>
    public partial class DeviceController : UserControl
    {
        public string DeviceId { get; set; }
        public DeviceController()
        {
            InitializeComponent();
        }
    }
}
