using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class ServiceRepository : BaseRepository<Service>
    {
        public ServiceRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
