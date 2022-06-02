using CarWash.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        DataContext context;
        public CarRepository(DataContext dataContext)
        {
            context = dataContext;
        }

        public void Add(Car entity)
        {
            context.Cars.Add(entity);
            context.SaveChanges();
        }

        public ICollection<Car> FindAll()
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            return context.Cars.Where(e => e.CarId == id).First();
        }

        public ICollection<Car> GetAll()
        {
            return context.Cars.ToList();
        }

        public void Remove(Car entity)
        {
            context.Cars.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Car entity)
        {
            context.Cars.Update(entity);
            context.SaveChanges();
        }
    }
}
