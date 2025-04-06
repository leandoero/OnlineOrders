using Microsoft.EntityFrameworkCore;
using OnlineOrders.Models.Domain;

namespace OnlineOrders.Data
{
    public class OnlineOrdersDbContext : DbContext
    {
        public OnlineOrdersDbContext(DbContextOptions<OnlineOrdersDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var orderStatuses = new List<OrderStatus>
            {
                new OrderStatus
                {
                    Id = Guid.Parse("a76aaf14-e9b5-4b89-b802-41d8805c9e78"),
                    Name = "Processing"
                },
                new OrderStatus
                {
                    Id = Guid.Parse("7187bed7-1f93-40d1-8fd5-e9f28badfb70"),
                    Name = "Sent"
                },
                new OrderStatus
                {
                    Id = Guid.Parse("64e000ba-6a33-452d-87cd-e35164073e59"),
                    Name = "Delivered"
                }
            };
            modelBuilder.Entity<OrderStatus>().HasData(orderStatuses);
        }
    }
}
