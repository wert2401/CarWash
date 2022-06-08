using CarWash.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.Interfaces
{
    public interface IRepositoriesHolder
    {
        public IRepository<Brand> BrandRepository { get; }
        public IRepository<Car> CarRepository { get; }
        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<CustomerCar> CustomerCarRepository { get; }
        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public IRepository<Service> ServiceRepository { get; }
        public IRepository<ServiceCategory> ServiceCategoryRepository { get; }
    }
}
