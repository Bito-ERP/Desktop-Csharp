using BitoDesktop.Data.Utils;
using BitoDesktop.Service.Http;
using BitoDesktop.WPF.Dialog;
using Newtonsoft.Json;
using System;
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

            this.DispatcherUnhandledException += (sender, args) =>
            {
                Exception ex = args.Exception;

                string message = ex.Message.Contains("message")
                    ? JsonConvert.DeserializeObject<dynamic>(ex.Message).message
                    : ex.Message;

                if (message.ToLower() == "unauthorized user") 
                {
                    Client.Token = null;
                    Client.DeviceId = null;
                    Client.PriceId = null;
                    Client.Username = "dev";
                    Client.OrganizationId = null;
                    Client.WarehouseId = null;
                    Client.UserId = null;
                    Client.ServerId = null;
                    
                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow.SideBarFrame = null;
                    mainWindow.NavigateToLoginPage();
                }
                else
                {
                    ErrorDialog dialog = new ErrorDialog(message);
                    dialog.ShowDialog();
                }

                // Handle the UI-related exception and possibly show a user-friendly message
                args.Handled = true; // Mark the exception as handled to prevent application termination
            };


        }

    }
}
