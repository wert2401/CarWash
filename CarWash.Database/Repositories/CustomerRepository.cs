using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
