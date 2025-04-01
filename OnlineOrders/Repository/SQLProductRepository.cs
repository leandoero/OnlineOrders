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
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            return product;
        }
    }

}
