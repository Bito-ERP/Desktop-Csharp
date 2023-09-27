using AutoMapper;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Data.Repositories;
using BitoDesktop.Domain.Configurations;
using BitoDesktop.Service.Interfaces;
using BitoDesktop.Service.Mappers;
using BitoDesktop.Service.Services;
using BitoDesktop.WPF.Controllers.PosControllers;
using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitoDesktop.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PosPage.xaml
    /// </summary>
    public partial class PosPage : Page
    {
        private readonly IProductService productService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        public PosPage()
        {
            InitializeComponent();
            mapper = new MapperConfiguration(m => { m.AddProfile<MapperProfile>(); }).CreateMapper();
            productRepository = new ProductRepository();
            unitOfWork = new UnitOfWork(productRepository);
            productService = new ProductService(unitOfWork,mapper);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var products = await productService.GetAllAsync(new PaginationParams());
            if(products.Count() > 0)
            {
                foreach(var product in products) 
                {
                    ProductController productController = new ProductController();
                    productController.ProductNameTxt.Text = product.Name;
                    productController.PriceTxt.Text = product.SelectedPriceAmount.ToString();
                    BasketControl.Items.Add(productController);
                }
                EmptyBasketImg.Source = null;
                EmptyBasketTxt.Text = string.Empty;
            }
        }
    }
}
