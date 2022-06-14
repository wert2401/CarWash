using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;

namespace CarWash.Database.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override ICollection<Customer> FindAll(ISearchParameters searchParameters)
        {
            CustomerSearchParameters? parameters = searchParameters as CustomerSearchParameters;

            IQueryable<Customer> customers = dbSet;

            if (parameters == null)
                return customers.ToList();

            if (parameters.FirstName != null)
            {
                customers = customers.Where(x => x.FirstName.ToLower().Contains(parameters.FirstName.ToLower()));
            }
            if (parameters.LastName != null)
            {
                customers = customers.Where(x => x.LastName.ToLower().Contains(parameters.LastName.ToLower()));
            }
            if (parameters.Patronymic != null)
            {
                customers = customers.Where(x => x.Patronymic.ToLower().Contains(parameters.Patronymic.ToLower()));
            }
            if (parameters.Email != null)
            {
                customers = customers.Where(x => x.Email.ToLower().Contains(parameters.Email.ToLower()));
            }
            if (parameters.Sex != null)
            {
                customers = customers.Where(x => x.Sex == parameters.Sex);
            }
            if (parameters.IsSendNotify != null)
            {
                customers = customers.Where(x => x.IsSendNotify == parameters.IsSendNotify);
            }

            return customers.ToList();
        }
    }
}
