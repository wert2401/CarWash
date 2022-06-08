using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
