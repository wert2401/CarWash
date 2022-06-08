using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class ServiceCategoryRepository : BaseRepository<ServiceCategory>
    {
        public ServiceCategoryRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
