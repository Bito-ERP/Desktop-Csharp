﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                double x = (parentWindow.Width - ActualWidth) / 2.3;
                double y = (parentWindow.Height - ActualHeight) / 1.2;

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