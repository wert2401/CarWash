using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.ViewModels.Interfaces;

namespace CarWash.MVC.ViewModels
{
    public class CustomerCarIndexViewModel : IViewModel<CustomerCar>, ISearchViewModel<CustomerCar>
    {
        public CustomerCar Entity { get; set; } = new CustomerCar();
        public IEnumerable<CustomerCar> Entities { get; set; }
        public ISearchParameters SearchParameters { get; set; }
    }
}
