using Microsoft.EntityFrameworkCore;
using OnlineOrders.Data;
using OnlineOrders.Models.Domain;

namespace OnlineOrders.Repository
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly OnlineOrdersDbContext dbContext;

        public SQLProductRepository(OnlineOrdersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }
    }

}
