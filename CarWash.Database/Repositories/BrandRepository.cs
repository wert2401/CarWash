using CarWash.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        DataContext context;

        public BrandRepository(DataContext dataContext)
        {
            context = dataContext;
        }

        public void Add(Brand entity)
        {
            context.Brands.Add(entity);
            context.SaveChanges();
        }

        public ICollection<Brand> FindAll()
        {
            throw new NotImplementedException();
        }

        public Brand? Get(int id)
        {
            var results = context.Brands.Where(e => e.BrandId == id);
            return results.Any() ? results.First() : null;
        }

        public ICollection<Brand> GetAll()
        {
            return context.Brands.ToList();
        }

        public void Remove(Brand entity)
        {
            context.Brands.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Brand entity)
        {
            context.Brands.Update(entity);
            context.SaveChanges();
        }
    }
}
