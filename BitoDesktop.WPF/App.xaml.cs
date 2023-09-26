using System.Windows;
using BitoDesktop.Data.Utils;

namespace BitoDesktop.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DataLoader.init();

            base.OnStartup(e);
        }
    }
}
