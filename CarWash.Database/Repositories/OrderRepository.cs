using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;

namespace CarWash.Database.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override ICollection<Order> FindAll(ISearchParameters searchParameters)
        {
            OrderSearchParameters? parametes = searchParameters as OrderSearchParameters;

            IQueryable<Order> orders = dbSet;

            if (parametes == null)
                return orders.ToList();

            if (parametes.Employee != null)
            {
                orders = orders.Where(x => (x.Employee.FirstName + x.Employee.LastName).ToLower().Contains(parametes.Employee.ToLower()));
            }
            if (parametes.CustomerCar != null)
            {
                orders = orders.Where(x => x.CustomerCar.Car.Model.ToLower().Contains(parametes.CustomerCar.ToLower()));
            }
            if (parametes.Service != null)
            {
                orders = orders.Where(x => x.Service.Name.ToLower().Contains(parametes.Service.ToLower()));
            }
            if (parametes.Status != null)
            {
                orders = orders.Where(x => x.Status == parametes.Status);
            }
            if (parametes.StartDate != null)
            {
                orders = orders.Where(x => x.StartDate == parametes.StartDate);
            }
            if (parametes.EndDate != null)
            {
                orders = orders.Where(x => x.EndDate == parametes.EndDate);
            }

            return orders.ToList();
        }
    }
}
