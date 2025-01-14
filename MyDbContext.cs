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
            //Check if in development mode ?? run inmemory vs SQL -- this one overwrites, no need for constructor!
            if(host.IsDevelopment())
            {
                optionsBuilder.UseInMemoryDatabase("TempDB");
            }
            else
            {
                optionsBuilder.UseSqlServer("TODO sql");
                throw new NotImplementedException();
            }
            
            //optionsBuilder.UseInMemoryDatabase("TempDB");
            //optionsBuilder.UseSqlServer("ConnectionString");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        { modelBuilder.Entity<Albums>().HasData(new Albums { Id = 2, Title = "ABC" }); }*/
    }
}
