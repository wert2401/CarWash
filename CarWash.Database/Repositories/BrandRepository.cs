using CarWash.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Database.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
