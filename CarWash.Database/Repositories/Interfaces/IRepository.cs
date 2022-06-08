using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public void Remove(T entity);
        public void Update(T entity);
        public T? Get(int id);
        public ICollection<T> GetAll();
        public ICollection<T> FindAll();

    }
}
