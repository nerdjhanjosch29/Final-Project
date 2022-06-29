using Microsoft.EntityFrameworkCore;
using wow.Models;

namespace wow.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
        base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

    }
}