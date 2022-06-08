using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
