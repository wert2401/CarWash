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

            modelBuilder.Entity<Service>().Navigation(s => s.ServiceCategory).AutoInclude();
            modelBuilder.Entity<Service>().Navigation(s => s.Orders).AutoInclude();

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

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Ivan", LastName = "Ivanov", Email = "sdf@gmail.com", Sex = false, IsSendNotify = false });

            modelBuilder.Entity<CustomerCar>().HasData(
                new CustomerCar { CustomerCarId = 1, Number = "nums", Year = 2010, CarId = 1, CustomerId = 1, Image= "images/customercars/c5b886b2-e8d5-4eec-b9a8-3f99f992f70f.jpg" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Vanya", LastName = "Vanyov" });

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerCarId = 1, EmployeeId = 1, ServiceId = 1, Status = 0, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                new Order { OrderId = 2, CustomerCarId = 1, EmployeeId = 1, ServiceId = 2, Status = 0, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) });
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
