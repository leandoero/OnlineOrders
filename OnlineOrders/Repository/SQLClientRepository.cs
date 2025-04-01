using Microsoft.EntityFrameworkCore;
using OnlineOrders.Data;
using OnlineOrders.Models.Domain;

namespace OnlineOrders.Repository
{
    public class SQLClientRepository:IClientRepository
    {
        private readonly OnlineOrdersDbContext dbContext;

        public SQLClientRepository(OnlineOrdersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await dbContext.Clients.Include("Product").Include("OrderStatus").ToListAsync();
        }

        public async Task<Client> AddAsync(Client client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return client;
        }

    }
}
