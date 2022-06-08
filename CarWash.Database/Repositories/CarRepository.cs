using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
