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
        public async Task<List<Product>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000)
        {
            var products = dbContext.Products.AsQueryable();

            if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = products.Where(x => x.Name.Contains(filterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = isAscending ? products.OrderBy(x => x.Name) : products.OrderByDescending(x => x.Name); 
                }
                else if(sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    products = isAscending ? products.OrderBy(x => x.Price) : products.OrderByDescending(x => x.Price);
                }
            }

            var skip = (pageNumber - 1) * pageSize;

            return await products.Skip(skip).Take(pageSize).ToListAsync();
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
