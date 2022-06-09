using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.ViewModels.Interfaces;

namespace CarWash.MVC.ViewModels
{
    public class CustomerIndexViewModel : ISearchViewModel<Customer>, IViewModel<Customer>
    {
        public Customer Entity { get; set; } = new Customer();
        public IEnumerable<Customer> Entities { get; set; }
        public ISearchParameters SearchParameters { get; set; }
    }
}
