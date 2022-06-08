using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class CustomerCarRepository : BaseRepository<CustomerCar>
    {
        public CustomerCarRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
