using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineOrders.Data
{
    public class OnlineOrdersAuthDbContext : IdentityDbContext
    {
        public OnlineOrdersAuthDbContext(DbContextOptions<OnlineOrdersAuthDbContext> options):base(options) { }
    }
}
