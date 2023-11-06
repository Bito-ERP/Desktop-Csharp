using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BitoDesktop.WPF.Dialog
{
    /// <summary>
    /// Логика взаимодействия для ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string errorMessage)
        {
            InitializeComponent();
            ErrorMessage.Text = errorMessage;
            StartTimer();
        }

        private async void StartTimer()
        {
            Window parentWindow = Application.Current.MainWindow;

            if (parentWindow != null)
            {
                // Calculate the position for the dialog to appear at the center bottom of the parent window
                double x = (parentWindow.Width - this.Width) / 2;
                double y = (parentWindow.Height - this.Height) / 20;

                // Set the dialog's position
                Left = x;
                Top = y;
            }

            await Task.Delay(3000); // Delay for 3 seconds (3000 milliseconds)

            // Add a fade-out animation
            var fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(1), // Duration for the fade-out effect
            };

            // Hook up a callback to close the window when the animation is finished
            fadeOutAnimation.Completed += (s, e) =>
            {
                Close(); // Close the dialog after the fade-out animation
            };

            // Apply the animation to the window
            BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
        }
    }
}
