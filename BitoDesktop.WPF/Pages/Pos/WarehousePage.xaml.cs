using BitoDesktop.WPF.Controllers.Pos;
using System;
using System.Windows.Controls;

namespace BitoDesktop.WPF.Pages.Pos
{
    /// <summary>
    /// Interaction logic for WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        private readonly WarehouseService warehouseService;
        public event EventHandler WarehouseChangeRequest;
        public WarehousePage()
        {
            InitializeComponent();
            warehouseService = new WarehouseService();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var warehouses = await warehouseService.GetAll();

            foreach (var warehouse in warehouses)
            {
                Grid grid = new Grid();

                grid.Children.Add(new TextBlock() { Text = warehouse.Name });
                grid.Children.Add(new TextBlock() { Text = warehouse.Id, Opacity = 0 });

                WarehouseCb.Items.Add(grid);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WarehouseChangeRequest?.Invoke(WarehouseCb.SelectedItem, EventArgs.Empty);
        }
    }
}
