using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.ViewModels.Interfaces;

namespace CarWash.MVC.ViewModels
{
    public class EmployeeIndexViewModel : IViewModel<Employee>, ISearchViewModel<Employee>
    {
        public Employee Entity { get; set; } = new Employee();
        public IEnumerable<Employee> Entities { get; set; }
        public ISearchParameters SearchParameters { get; set; }
    }
}
