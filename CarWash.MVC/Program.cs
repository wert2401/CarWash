using CarWash.Database;
using CarWash.Database.Models;
using CarWash.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarWash.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DevelopmentConnection"), b => b.MigrationsAssembly("CarWash.MVC")));

            builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();
            builder.Services.AddScoped<IRepository<Car>, CarRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}