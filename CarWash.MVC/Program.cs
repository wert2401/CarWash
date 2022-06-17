using CarWash.Database;
using CarWash.Database.Models;
using CarWash.Database.Repositories;
using CarWash.Database.Repositories.Holders;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.Services.ImageService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CarWash.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DevelopmentConnection"), options =>
                {
                    options.MigrationsAssembly("CarWash.MVC");
                    options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });

            builder.Services.AddScoped<IRepositoriesHolder, RepositoriesHolder>();
            builder.Services.AddScoped<IImageService, ImageService>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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