using BitoDesktop.Data.Repositories.Pos;
using BitoDesktop.Domain.Entities.Pos;
using BitoDesktop.Service.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class TicketService
    {
        private readonly TicketRepository ticketRepository;

        public TicketService()
        {
            ticketRepository = new TicketRepository();
        }

        public async Task<int> AddNewTicket(string customerId = null)
        {
            Ticket ticket = new Ticket()
            {
                Name = "Sotuv",
                WarehouseId = Client.WarehouseId,
                PriceId = Client.PriceId,
                OrganizationId = Client.OrganizationId,
                CreatedAt = DateTime.UtcNow,
                CustomerId = customerId,
            };

            return await ticketRepository.Insert(ticket);
        }

        public async Task<int> AddTicketItems(string productId, int ticketId, double price, double amount)
        {
            TicketItem item = new TicketItem();
            item.ProductId = productId;
            item.TicketId = ticketId;
            item.Price = price;
            item.Amount = amount;

            var res = await ticketRepository.InsertAndReturnId(item);

            return res;
        }

        public async Task UpdateTicketItem(int id, string productId, int ticketId, double price, double amount)
        {
            TicketItem item = new TicketItem();
            item.ProductId = productId;
            item.TicketId = ticketId;
            item.Price = price;
            item.Amount = amount;

            await ticketRepository.Update(id, ticketId,item);
        }

        public async Task<IEnumerable<TicketItem>> GetItems(int ticketId)
        {
            return await ticketRepository.GetItems(ticketId,Client.PriceId,Client.OrganizationId,Client.WarehouseId);
        }

        public async Task DeleteTicketItem(int id)
        {
            await ticketRepository.DeleteItem(id);
        }

        public async Task<Ticket> GetTicket(int id) =>
            await ticketRepository.Get(id);

        public async Task<IEnumerable<int>> GetTickets()
        {
            var tickets = await ticketRepository.GetTickets(Client.OrganizationId);

            return tickets.Select(ticket => ticket.Id);
        }

        public async Task Delete(int id)
        {
            await ticketRepository.Delete(id);
        }
    }
}
