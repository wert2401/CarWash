using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;

namespace CarWash.Database.Repositories
{
    public class CustomerCarRepository : BaseRepository<CustomerCar>
    {
        public CustomerCarRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override ICollection<CustomerCar> FindAll(ISearchParameters searchParameters)
        {
            CustomerCarSearchParameters? parameters = searchParameters as CustomerCarSearchParameters;

            IQueryable<CustomerCar> customerCars = dbSet;

            if (parameters == null)
                return customerCars.ToList();

            if (parameters.CarModel != null)
            {
                customerCars = customerCars.Where(x => x.Car.Model.ToLower().Contains(parameters.CarModel.ToLower()));
            }
            if (parameters.CustomerName != null)
            {
                customerCars = customerCars.Where(x => x.Customer.FirstName.ToLower().Contains(parameters.CustomerName.ToLower()) | x.Customer.LastName.Contains(parameters.CustomerName.ToLower()));
            }
            if (parameters.Year != null)
            {
                customerCars = customerCars.Where(x => x.Year == parameters.Year);
            }
            if (parameters.Number != null)
            {
                customerCars = customerCars.Where(x => x.Number.ToLower().Contains(parameters.Number.ToLower()));
            }

            return customerCars.ToList();
        }
    }
}
