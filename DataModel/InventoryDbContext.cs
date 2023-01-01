using DataModels.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataModels
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StoreHeader> StoreHeaders { get; set; }
        public DbSet<MaterialItem> MaterialItems { get; set; }
    }

}




