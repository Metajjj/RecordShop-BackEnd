using Microsoft.EntityFrameworkCore;

using RecordShop_BE.Tables;

namespace RecordShop_BE
{
    public class MyDbContext : DbContext
    {

        public DbSet<Albums> AlbumTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TempDB");
            //optionsBuilder.UseSqlServer("ConnectionString");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
