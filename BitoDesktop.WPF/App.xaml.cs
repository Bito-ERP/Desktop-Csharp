using BitoDesktop.Data.Utils;
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

                string message = ex.Message.Contains("message") && ex.Message.Contains("en") 
                    ? JsonConvert.DeserializeObject<dynamic>(ex.Message).message.en 
                    : ex.Message;

                ErrorDialog dialog = new ErrorDialog(message);
                dialog.ShowDialog();

                // Handle the UI-related exception and possibly show a user-friendly message
                args.Handled = true; // Mark the exception as handled to prevent application termination
            };


        }

    }
}
