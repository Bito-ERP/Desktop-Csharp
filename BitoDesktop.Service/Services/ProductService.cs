using BitoDesktop.Data.Repositories.WarehouseP;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;
        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public async Task<Product> GetById(string productId, string organizationId, string warehouseId, string priceId)
        {
            var product = await productRepository
                .GetById(productId, organizationId, warehouseId, priceId, true, true, false);

            if (product == null)
                throw new MarketException(404, "Product not found");

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(string value, string organizationId, string warehouseId, string priceId)
        {
            var product = await productRepository
                .GetProducts(organizationId, warehouseId, null, null, null, true,value, priceId,null,null,false,false,false,false);

            if (product == null)
                throw new MarketException(404, "Product not found");

            return product;
        }
    }
}
