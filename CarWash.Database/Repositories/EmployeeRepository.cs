using CarWash.Database.Models;

namespace CarWash.Database.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
