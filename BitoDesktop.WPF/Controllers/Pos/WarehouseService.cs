using BitoDesktop.Data.Repositories.WarehouseP;
using BitoDesktop.Domain.Entities.WarehouseP;
using BitoDesktop.Service.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.WPF.Controllers.Pos
{
    public class WarehouseService
    {
        private readonly WarehouseRepository warehouseRepository;
        public WarehouseService()
        {
            warehouseRepository = new WarehouseRepository();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            var warehouses = await warehouseRepository.GetWarehouses(0, 0, "", Client.OrganizationId, "active");

            return warehouses;
        }
    }
}
