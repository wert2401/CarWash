using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.Holders
{
    public class RepositoriesHolder : IRepositoriesHolder
    {
        private readonly DataContext dataContext;

        public RepositoriesHolder(DataContext dataContext)
        {
            this.dataContext = dataContext;
            BrandRepository = new BrandRepository(dataContext);
            CarRepository = new CarRepository(dataContext);
            CustomerRepository = new CustomerRepository(dataContext);
            CustomerCarRepository = new CustomerCarRepository(dataContext);
            EmployeeRepository = new EmployeeRepository(dataContext);
            OrderRepository = new OrderRepository(dataContext);
            ServiceRepository = new ServiceRepository(dataContext);
            ServiceCategoryRepository = new ServiceCategoryRepository(dataContext);
        }
        public IRepository<Brand> BrandRepository { get; private set; }

        public IRepository<Car> CarRepository { get; private set; }

        public IRepository<Customer> CustomerRepository { get; private set; }

        public IRepository<CustomerCar> CustomerCarRepository { get; private set; }

        public IRepository<Employee> EmployeeRepository { get; private set; }

        public IRepository<Order> OrderRepository { get; private set; }

        public IRepository<Service> ServiceRepository { get; private set; }

        public IRepository<ServiceCategory> ServiceCategoryRepository { get; private set; }
    }
}
