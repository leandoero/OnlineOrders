using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineOrders.Data;
using OnlineOrders.Models.Domain;
using OnlineOrders.Models.DTO;

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
            if (product == null)
            {
                return null;
            }
            return product;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> UpdateAsync(Guid id, Product product)
        {
            var productDomain = await dbContext.Products.FindAsync(id);
            if (productDomain == null)
            {
                return null;
            }
            productDomain.Name = product.Name;
            productDomain.Price = product.Price;
            productDomain.Description = product.Description;

            await dbContext.SaveChangesAsync();

            return productDomain;
        }
        public async Task<Product?> DeleteAsync(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
