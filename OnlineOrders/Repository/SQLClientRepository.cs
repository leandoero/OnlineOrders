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
        public async Task<List<Client>> GetAllAsync(string? filterBy, string? filterQuery, string? sortBy, bool isAscending)
        {
            var clients = dbContext.Clients.Include("Product").Include("OrderStatus").AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterBy) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if(filterBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    clients = clients.Where(x => x.Name.Contains(filterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    clients = isAscending ? clients.OrderBy(x => x.Name):clients.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    clients = isAscending ? clients.OrderBy(x => x.Product.Price) : clients.OrderByDescending(x => x.Product.Price);
                }
            }
            return await clients.ToListAsync();
        }
        public async Task<Client> AddAsync(Client client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return client;
        }
        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await dbContext.Clients.Include("Product").Include("OrderStatus").FirstOrDefaultAsync(w => w.Id == id);   
        }
        public async Task<Client?> UpdateAsync(Guid id, Client client)
        {
            var upgradeСlient = await dbContext.Clients.FindAsync(id);
            if(upgradeСlient == null)
            {
                return null;
            }
            upgradeСlient.Name = client.Name;
            upgradeСlient.Surname = client.Surname;
            upgradeСlient.Address = client.Address;
            upgradeСlient.Description = client.Description;
            upgradeСlient.ProductId = client.ProductId;
            upgradeСlient.OrderStatus = client.OrderStatus;

            await dbContext.SaveChangesAsync();

            return upgradeСlient;
        }

        public async Task<Client?> DeleteAsync(Guid id)
        {
            var client = await dbContext.Clients.FindAsync(id);
            if(client == null)
            {
                return null;
            }
            
            dbContext.Clients.Remove(client);
            await dbContext.SaveChangesAsync();
            return client;
        }

    }
}
