using BitoDesktop.Data.Repositories.Pos;
using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Service.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class PosService
    {
        private readonly PosRepository posRepository;

        public PosService()
        {
            posRepository = new PosRepository();
        }

        public async Task<IEnumerable<Page>> GetPages() =>
            await posRepository.GetPages(Client.OrganizationId);
    }
}
