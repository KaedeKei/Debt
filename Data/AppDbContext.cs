using Microsoft.EntityFrameworkCore;
using Shedule.Models;

namespace Shedule.Data
{
	public class AppDbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Seller> Sellers { get; set; }
		public DbSet<SaleEvent> SaleEvents { get; set; }
        public DbSet<PaymentEvent> PaymentEvents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
	}
}
