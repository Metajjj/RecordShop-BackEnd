
using System.Runtime.CompilerServices;

using Microsoft.EntityFrameworkCore;

using RecordShop_BE.Repositories;
using RecordShop_BE.Services;
using RecordShop_BE.Tables;

namespace RecordShop_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyDbContext>(
                //Setup in DBcontext - more control for tests!
            /*opt =>
            {
                Console.WriteLine("Inside opts");
                if (builder.Environment.IsDevelopment())
                {
                    Console.WriteLine("IS DEV");
                    opt.UseInMemoryDatabase("TempDB");
                }
                else
                {
                    opt.UseSqlServer("ConnStr");
                    Console.WriteLine("IS SQL");
                }
            }*/
            );

            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

                //Now runs the options and console.WriteLines!
            var db = app.Services.CreateScope().ServiceProvider.GetService<MyDbContext>();
            db.Add<Albums>(new Albums { Id = 2, Title = "ABC" });
            db.SaveChanges();

            Console.WriteLine("NAME: "+db.Database.ProviderName);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}
