using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;

namespace CarWash.Database.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public override ICollection<Employee> FindAll(ISearchParameters searchParameters)
        {
            EmployeeSearchParameters? parameters = searchParameters as EmployeeSearchParameters;

            IQueryable<Employee> employees = dbSet;

            if (parameters == null)
                return employees.ToList();

            if (parameters.FirstName != null)
            {
                employees = employees.Where(x => x.FirstName.ToLower().Contains(parameters.FirstName.ToLower()));
            }
            if (parameters.LastName != null)
            {
                employees = employees.Where(x => x.LastName.ToLower().Contains(parameters.LastName.ToLower()));
            }
            if (parameters.Patronymic != null) 
            { 
                employees = employees.Where(x => x.Patronymic.ToLower().Contains(parameters.Patronymic.ToLower()));
            }

            return employees.ToList();
        }
    }
}
