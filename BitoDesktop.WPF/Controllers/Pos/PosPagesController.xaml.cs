using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BitoDesktop.WPF.Controllers.Pos
{
    /// <summary>
    /// Логика взаимодействия для PosPagesController.xaml
    /// </summary>
    public partial class PosPagesController : UserControl
    {
        public event EventHandler ClosePageRequested;
        public event EventHandler ChoosePageRequested;
        public int Id { get; set; }
        public PosPagesController()
        {
            InitializeComponent();
        }

        private void ClosePageBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClosePageRequested?.Invoke(this, e);
        }

        private void TicketChooseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChoosePageRequested?.Invoke(this, e);
        }
    }
}
