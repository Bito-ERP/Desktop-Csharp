using BitoDesktop.Data.Utils;
using System.Windows;

namespace BitoDesktop.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DataLoader.Init();

            base.OnStartup(e);
        }
    }
}
