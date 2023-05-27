using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {


        }
        //public Store1Context(DbContextOptions<Store1Context> options) : base(options)
        //{ }
        public DbSet<TbItems> TbItems { get; set; }
        public DbSet<TbCategories> TbCategories { get; set; }

        public DbSet<TbItemImages> TbItemImages { get; set; }
        public DbSet<TbItemDiscount> TbItemDiscount { get; set; }   
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=Store1; Trusted_Connection=True;");
            }
        }
    }
}
