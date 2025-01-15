using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

using RecordShop_BE.Tables;

namespace RecordShop_BE
{
    public class MyDbContext : DbContext
    {
        private IWebHostEnvironment host;

        public MyDbContext(IWebHostEnvironment env)
        {
            host = env;
        }

        public DbSet<Albums> AlbumTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(); //To see key conflicts


            //Check if in development mode ?? run inmemory vs SQL -- this one overwrites, no need for constructor context!
            if (host.IsDevelopment())
            { optionsBuilder.UseInMemoryDatabase("TempDB"); }
            else
            {
                optionsBuilder.UseSqlServer("TODO sql");
                throw new NotImplementedException(); //WORKS !
            }
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        { modelBuilder.Entity<Albums>().HasData(new Albums { Id = 2, Title = "ABC" }); }*/
    }
}
