using CarWash.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().Navigation(b => b.Cars).AutoInclude();

            modelBuilder.Entity<Car>().Navigation(c => c.Brand).AutoInclude();

            modelBuilder.Entity<Customer>().Navigation(c => c.CustomerCars).AutoInclude();

            modelBuilder.Entity<CustomerCar>().Navigation(c => c.Car).AutoInclude();
            modelBuilder.Entity<CustomerCar>().Navigation(c => c.Customer).AutoInclude();
            modelBuilder.Entity<CustomerCar>().Navigation(c => c.Orders).AutoInclude();

            modelBuilder.Entity<Employee>().Navigation(e => e.Orders).AutoInclude();

            modelBuilder.Entity<Order>().Navigation(o => o.Service).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.CustomerCar).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.Employee).AutoInclude();

            modelBuilder.Entity<Service>().Navigation(s => s.ServiceCategory).AutoInclude();
            //modelBuilder.Entity<Service>().Navigation(s => s.Orders).AutoInclude();

            modelBuilder.Entity<ServiceCategory>().Navigation(s => s.Services).AutoInclude();

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "Toyota" },
                new Brand { BrandId = 2, Name = "Lada"});

            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, Model = "Camry", BrandId = 1 },
                new Car { CarId = 2, Model = "Corolla", BrandId = 1 },
                new Car { CarId = 3, Model = "Granta", BrandId = 2 });

            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory { ServiceCategoryId = 1, Name = "Clean" },
                new ServiceCategory { ServiceCategoryId = 2, Name = "Wash" });

            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceId = 1, ServiceCategoryId = 1, Name = "Clean dirt" },
                new Service { ServiceId = 2, ServiceCategoryId = 2, Name = "Wash dirt" });
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCar> CustomerCars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
    }
}
