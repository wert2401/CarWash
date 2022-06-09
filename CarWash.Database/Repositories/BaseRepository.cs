using CarWash.Database.Models.Intefaces;
using CarWash.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Database.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IModel
    {
        protected DataContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(DataContext dataContext)
        {
            context = dataContext;
            dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual ICollection<T> FindAll(ISearchParameters searchParameters)
        {
            throw new NotImplementedException();
        }

        public virtual T? Get(int id)
        {
            var results = dbSet.ToList().Where(e => e.Id == id);
            return results.Any() ? results.First() : null;
        }

        public virtual ICollection<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}
